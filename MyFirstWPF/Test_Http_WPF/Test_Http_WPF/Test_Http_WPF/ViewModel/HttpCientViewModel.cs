using HomeWork_22_HTTP_Client;
using HomeWork_22_HTTP_Client.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Test_Http_WPF.Commands;

namespace Test_Http_WPF.ViewModel
{
    internal class HttpCientViewModel : ViewModelBase
    {
        IRemoteData _myHttpClient;
        private bool _requestLight;
        private List<Currency> _responeCurrency = new List<Currency>();
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
        public List<Currency> ResponeCurrency
        {
            get
            {
                return _responeCurrency;
            }

            set
            {
                _responeCurrency = value;
                OnPropertyChanged();
            }
        }
        public HttpCientViewModel(IRemoteData myHttpClient)
        {
            #region Commands
            OnEnableHttpCommand = new LambdaCommand(
                OnEnableHttpCommandExecuted,
                CanOnEnableHttpCommandExecuted
                );

            OffEnableHttpCommand = new LambdaCommand(
                   OffEnableHttpCommandExecuted,
                   CanOffEnableHttpCommandExecuted
                   );
            #endregion
            _myHttpClient = myHttpClient;
            _myHttpClient.EventRequestLight += callBackMyHttpClient;
        }

        public bool RequestLight 
        {
            get
            {
                return _requestLight;
            }
            set
            {
                _requestLight = value;
                OnPropertyChanged();
            }
           
        }
        public bool Enable
        {
            get
            {
                return _myHttpClient.Enable;
            }
            set
            {
                _myHttpClient.Enable = value;
                OnPropertyChanged();
            }
        }

        private void BlinkConection (bool _requestLight)
        {
            ChangeColor = (_requestLight == true && _myHttpClient.Enable) ? "Green" :"#FFFFFFFF";
        }
        private void callBackMyHttpClient( List<Currency> respone)
        {
            _requestLight = _myHttpClient.RequestLight;
            ResponeCurrency = respone;
            BlinkConection(_requestLight);
        }

        #region Commands
        #region OnEnableHttpCommand
        public ICommand OnEnableHttpCommand { get; }

        private void OnEnableHttpCommandExecuted(object p)
        {
            _myHttpClient.Enable = true;
        }
        private bool CanOnEnableHttpCommandExecuted(object p)
        {
            return true;
        }
        #endregion
        #region OnEnableHttpCommand
        public ICommand OffEnableHttpCommand { get; }

        private void OffEnableHttpCommandExecuted(object p)
        {
            _myHttpClient.Enable = false;
            BlinkConection(_requestLight);
        }
        private bool CanOffEnableHttpCommandExecuted(object p)
        {
            return true;
        }
        #endregion
        #endregion
    }
}
