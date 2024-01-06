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
        private PlcObj _plc;

        public bool _error;

        public bool _enable;

        private string _ipAdress;
        public string IpAdress 
        {
            get => _plc.IpAdress;
            set
            {
                _ipAdress = value;
                OnPropertyChanged();
            }
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
                _plc.Enable = true;
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
            _plc = plc;
            _plc.EventFromPLC += CallBackFromPLC;
        }

        private void Blink(bool _requestLight)
        {
            ChangeColor = (_requestLight == true) ? "Green" : "#FFFFFFFF";
        }

        void CallBackFromPLC ()
        {
            Enable = _plc.Enable;
            ErroConection = _plc.ErroConection;
        }
    }
}
