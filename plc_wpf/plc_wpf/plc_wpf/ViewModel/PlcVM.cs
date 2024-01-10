using plc_modules;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plc_wpf.ViewModel
{
   public class PlcVM: ViewModelBase
    {
        public PlcObj Plc;

        public bool _error;

        public bool _enable;

        private string _ipAdress;
        public string IpAdress 
        {
            get => Plc.IpAdress;
            set
            {
                _ipAdress = value;
                OnPropertyChanged();
            }
        }

        public string PlcName
        {
            get => Plc.PlcName; 
        }

        public bool ErroConection
        {
            get => _error;
            set
            {
                _error = value;
                OnPropertyChanged();
            }
        }

        public bool Enable
        {
            get => _enable;
            set
            {
                Plc.Enable = true;
                _enable = value;
                OnPropertyChanged();
            }
        }

        private string _changeColor;
        public string ChangeColor
        {
            get
            {
                return _changeColor;
            }
            set
            {
                _changeColor = value;
                OnPropertyChanged();
            }
        }
        public PlcVM(PlcObj plc)
        {
            Plc = plc;
            Plc.EventFromPLC += CallBackFromPLC;
        }

        private void Blink(bool _requestLight)
        {
            ChangeColor = (_requestLight == true) ? "Green" : "#FFFFFFFF";
        }

        void CallBackFromPLC ()
        {
            Enable = Plc.Enable;
            ErroConection = Plc.ErroConection;
        }
    }
}
