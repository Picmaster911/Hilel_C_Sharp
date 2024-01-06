﻿using S7.Net;
using S7.Net.Types;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.NetworkInformation;

namespace plc_modules
{
    public class PlcObj
    {
        private bool _enable;
        private Plc _plc;
        #region Connection variable
        public string IpAdress { get => _ipAdress; set => _ipAdress = value; }
        private string _ipAdress;
        public int Slot { get => _slot; set => _slot = value; }
        private int _slot;
        public string Rack { get => _rack; set => _rack = value; }
        private string _rack;
        public int TimeCycle { get => _timeCycle; set => _timeCycle = value; }
        private int _timeCycle = 1000;
        public bool ErroConection { get => _erroConection; }
        private bool _erroConection;
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
        private bool erorConnection = false;
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
            erorConnection = false;
            cancelTokenSource = new CancellationTokenSource();
            Task pingPlc = PingPlc(cancelTokenSource.Token);
            Task backgroundTask = GetData(cancelTokenSource.Token);
        }

        async Task PingPlc(CancellationToken cancellationToken)
        {
            await Task.Run(async () =>
            {
                Ping ping = new Ping();
                while (!cancellationToken.IsCancellationRequested)
                {
                    var Status = ping.Send("192.168.0.10", 1);
                    if (Status.Status == IPStatus.Success)
                    {
                        _available = (Status.Status == IPStatus.Success);
                        Console.WriteLine($"ping = {Status.Status == IPStatus.Success} error = {erorConnection}");
                        if (erorConnection && _enable)
                        {
                            StopPlcConnect();
                            StartPlcConnect();
                        }
                    }
                    else Console.WriteLine($"ping = {Status.Status == IPStatus.Success} error = {erorConnection} ");
                    Thread.Sleep(1000);
                }

            }, cancellationToken);

        }
        async Task CreatePlc()
        {
            string ip = "192.168.0.10";
            try
            {
                _plc = new Plc(CpuType.S71200, ip, 0, 1);
                await _plc.OpenAsync();

                if (_plc.IsConnected)
                {
                    erorConnection = false;
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
            await Task.Run(async () =>
            {
                await Task.Run(() => CreatePlc());

                while (!cancellationToken.IsCancellationRequested && !erorConnection)
                {
                    Console.WriteLine("TASK RUN");

                    try
                    {
                        _dataRespone = await _plc.ReadMultipleVarsAsync(_dataForRequest);
                    }
                    catch (Exception e)
                    {
                        erorConnection = true;
                        Console.WriteLine("An error occurred, include the stack trace when copying:");
                        Console.WriteLine(e.ToString());
                    }

                    if (_dataRespone != null)
                    {
                        var test = _dataRespone.Select((i) => i.Value.ToString());
                        test.ToList().ForEach(x => Console.WriteLine(x));
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
            }, cancellationToken);
        }

    }
}
