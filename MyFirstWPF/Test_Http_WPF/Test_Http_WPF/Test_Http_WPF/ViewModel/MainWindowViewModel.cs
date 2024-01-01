using HomeWork_22_HTTP_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Http_WPF.ViewModel
{
    internal class MainWindowViewModel: ViewModelBase
    {
        public HttpCientViewModel HttpCientVM { get; }
        public CurrencyChartViewModel CurrencyChartVM { get; }
        public MainWindowViewModel (HttpCientViewModel httpCientVM,DataWorker dataworker)
        {
            CurrencyChartVM = CurrencyChartViewModel.LoadVW (dataworker);
            HttpCientVM = httpCientVM;
            
        }
        private string _title;
        public string Title
        {
            get => _title;
            set => Set (ref _title, value);
        }
    }
}
