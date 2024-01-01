using HomeWork_22_HTTP_Client.Models;
using System.Net.Http.Json;


namespace HomeWork_22_HTTP_Client
{
    public class MyHttpDataClient : IRemoteData
    {
        private IHttpClientFactory _httpClientFactory;
        private bool _enable;
        private DataWorker _dataworker;
        private bool _requestLight;
        public bool RequestLight { get => _requestLight; }
        private readonly object _syncRoot = new object();

        public event Action <List<Currency>> EventRequestLight;
        public bool Enable
        {
            get => _enable;
            set
            {
                if (value) StartHttpClient();
                else StopHttpClient();
                _enable = value;
            }
        }

        private CancellationTokenSource cancelTokenSource;
        public MyHttpDataClient (DataWorker dataworker, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _dataworker= dataworker;
        }
      
        private void StopHttpClient()
        {
             cancelTokenSource.Cancel();
             _enable = false;
        }
        private void StartHttpClient()
        {
            if (_enable)
                return;
            cancelTokenSource= new CancellationTokenSource();
            Task backgroundTask = GetData (cancelTokenSource.Token);
        }


        public async Task  GetData(CancellationToken cancellationToken)
        {
            await Task.Run(async() =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var url = "\r\nhttps://api.privatbank.ua/p24api/pubinfo?exchange&coursid=5";
                    var httpClient = _httpClientFactory.CreateClient();
                    var json = await httpClient.GetFromJsonAsync<List<Currency>>(url);
                    if (json != null)
                    {
                        _dataworker.AddToDb(json);
                        _requestLight = !_requestLight;
                        Thread.Sleep(2000);
                        EventRequestLight?.Invoke(json);
                    }
                    else
                    {
                        throw new ArgumentException("Server API not aviable");
                    }
                }
            }, cancellationToken);


        }

    }
}
