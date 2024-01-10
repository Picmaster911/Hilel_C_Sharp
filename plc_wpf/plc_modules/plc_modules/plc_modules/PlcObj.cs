﻿using S7.Net;
using S7.Net.Types;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Input;
using System.Xml.Linq;

namespace plc_modules
{
    public class PlcObj
    {
        private bool _enable;
        private Plc _plc;
        #region Connection variable
        private CpuType _cpuType;
        private string _plcName;
        public string PlcName { get => _plcName; set => _plcName = value; }
        public string IpAdress { get => _ipAdress; set => _ipAdress = value; }
        private string _ipAdress;
        public int Slot { get => _slot; set => _slot = value; }
        private int _slot;
        public int Rack { get => _rack; set => _rack = value; }
        private int _rack;
        public int TimeCycle { get => _timeCycle; set => _timeCycle = value; }
        private int _timeCycle = 1000;
        public bool ErroConection { get => _erroConection; }
        private bool _erroConection = false;
        public bool Available { get => _available; }
        private bool _available;
        private CancellationTokenSource cancelTokenSource;
        #endregion
        private bool _requestLight;
        public bool RequestLight { get => _requestLight; }

        private List<DataItem> _dataForRequest = new List<DataItem>();

        private List<DataItem> _dataRespone;
        public event Action<List<DataItem>> EventResponeReady;
        public List<DataItem> DataForRequest { get => _dataForRequest; set => _dataForRequest = value; }
       
        public event Action EventFromPLC;

        public PlcObj(string cpuName, CpuType cpuType, string ipAdress, int rack,int slot, int timeCycle)
        {
            _plcName= cpuName;
            _cpuType = cpuType;
            _ipAdress = ipAdress;
            _rack = rack;
            _slot = slot;
            _timeCycle = timeCycle;
        }
        public bool Enable
        {
            get => _enable;
            set
            {
                if (value) StartPlcConnect();
                else StopPlcConnect();
                _enable = value;
            }
        }
        private void StopPlcConnect()
        {
            cancelTokenSource.Cancel();
            _enable = false;
        }
        private void StartPlcConnect()
        {
            if (_enable)
                return;
            _enable = true;
            _erroConection = false;
            cancelTokenSource = new CancellationTokenSource();
            Task pingPlc = PingPlc(cancelTokenSource.Token);
            Task backgroundTask = GetData(cancelTokenSource.Token);
        }

        async Task PingPlc (CancellationToken cancellationToken)
        {
            await Task.Run((Func<Task?>)(async () =>
            {
                Ping ping = new Ping();
                while (!cancellationToken.IsCancellationRequested)
                {
                    EventFromPLC?.Invoke();
                    var Status = ping.Send("192.168.0.10", 1);
                    if (Status.Status == IPStatus.Success)
                    {
                        _available = (Status.Status == IPStatus.Success);
                        Console.WriteLine($"ping = {Status.Status == IPStatus.Success} error = {this._erroConection}");
                        if (this._erroConection && _enable)
                        {
                            Thread.Sleep(1000);
                            StopPlcConnect();
                            StartPlcConnect();
                        }
                    }
                    else Console.WriteLine($"ping = {Status.Status == IPStatus.Success} error = {this._erroConection} ");
                    Thread.Sleep(1000);
                }

            }), cancellationToken);

        }
        async Task CreatePlc()
        {
            DataForRequest.Add( new DataItem 
            { DataType = DataType.DataBlock, DB = 1, StartByteAdr = 0, VarType = VarType.Int});
            DataForRequest.Add(new DataItem
            { DataType = DataType.DataBlock, DB = 2, StartByteAdr = 0, VarType = VarType.Int });
            DataForRequest.Add(new DataItem
            { DataType = DataType.DataBlock, DB = 2, StartByteAdr = 2, VarType = VarType.Bit });
            DataForRequest.Add(new DataItem
            { DataType = DataType.DataBlock, DB = 2, StartByteAdr = 4, VarType = VarType.S7WString, Count = 10 });

                
             

            try
            {
                _plc = new Plc(_cpuType,_ipAdress, (short)_rack, (short)_slot);
                await _plc.OpenAsync();

                if (_plc.IsConnected)
                {
                    _erroConection = false;
                    Console.WriteLine("Plc is Connected");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred, include the stack trace when copying:");
                Console.WriteLine(e.ToString());
            };
        }

        public async Task GetData(CancellationToken cancellationToken)
        {
            await Task.Run((Func<Task?>)(async () =>
            {
                await Task.Run(() => CreatePlc());

                while (!cancellationToken.IsCancellationRequested && !this._erroConection)
                {
                    Console.WriteLine("TASK RUN");

                    try
                    {
                        _dataRespone = await _plc.ReadMultipleVarsAsync(_dataForRequest);
                        var t = 1;
                    }
                    catch (Exception e)
                    {
                        this._erroConection = true;
                        Console.WriteLine("An error occurred, include the stack trace when copying:");
                        Console.WriteLine(e.ToString());
                    }

                    if (_dataRespone != null)
                    {
                        var test = _dataRespone.Select<DataItem, string>((i) => i.Value.ToString());
                        test.ToList<string>().ForEach(x => Console.WriteLine(x));
                        //_dataworker.AddToDb(json);
                        //_requestLight = !_requestLight;
                        Thread.Sleep(2000);
                        //EventRequestLight?.Invoke(json);
                    }
                    else
                    {
                        throw new ArgumentException("Server API not aviable");
                    }
                    Thread.Sleep(2000);
                }
            }), cancellationToken);

            
        }
    }
}
