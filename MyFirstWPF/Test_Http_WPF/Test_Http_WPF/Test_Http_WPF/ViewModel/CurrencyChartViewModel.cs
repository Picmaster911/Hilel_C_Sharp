using HomeWork_22_HTTP_Client.Models;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Test_Http_WPF.Commands;

namespace Test_Http_WPF.ViewModel
{
    public class CurrencyChartViewModel : ViewModelBase
    {
        public IEnumerable <CurrencyAndTime> CurrencyChartColection { get; set; }   
        private DataWorker _dataworker;
        public ChartValues <double> PriceDataUsd { get; set; }
        public ChartValues<double> PriceDataEuro { get; set; }
        public SeriesCollection SeriesCollection { get; set; }  
        public Func<double, string> YFormatter { get; set; }
        public string [] DateGetData { get; set; }
        public CurrencyChartViewModel(DataWorker dataworker)
        {
            _dataworker = dataworker;

            #region Commands
            GetFromDB = new LambdaCommand(
                OnGetFromDBCommandExecuted,
                CanGetFromDBCommandExecuted
                );
            #endregion
        }

        public static CurrencyChartViewModel LoadVW ( DataWorker dataworker, Action<Task> onLoadet = null)
        {
            CurrencyChartViewModel viewModel = new CurrencyChartViewModel(dataworker);
            viewModel.LoadDataWromDB().ContinueWith( t=> onLoadet?.Invoke(t));
            return viewModel;
        }
        private async Task LoadDataWromDB()
        {
            var dataFromServer = await _dataworker.ReadFromDb();
            PriceDataUsd = new ChartValues<double>(dataFromServer
                .Where(item => item.Ccy == "USD")
                .Select(item => double.Parse(item.Buy, CultureInfo.InvariantCulture)));

            PriceDataEuro = new ChartValues<double>(dataFromServer
               .Where(item => item.Ccy == "EUR")
               .Select(item => double.Parse(item.Buy, CultureInfo.InvariantCulture)));

            var listDate = new List<string>(dataFromServer
                .Select(item => item.Date.ToString(("yyyy-MM-dd H:mm")))
                );
            DateGetData = listDate.ToArray();

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "USD",
                    Values = PriceDataUsd
                },
                new LineSeries
                {
                    Title = "EUR",
                    Values = PriceDataEuro
                },
            };
            YFormatter = value => value.ToString("C");
        }
        #region Commands
        #region OnEnableHttpCommand
        public ICommand GetFromDB { get; }


        //Button for TEST
        private async void OnGetFromDBCommandExecuted(object p)
        {
            var test = "SET";
        }
        private bool CanGetFromDBCommandExecuted(object p)
        {
            return true;
        }
        #endregion
        #endregion
    }
}
