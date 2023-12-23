using System.Net.Http.Json;
using HomeWork_22_HTTP_Client.Models;

namespace HomeWork_22_HTTP_Client
{
    class HttpModels : IRemoteData
    {
        private IHttpClientFactory _httpClientFactory;
        public HttpModels(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        async Task<IEnumerable<Currency>> IRemoteData.GetData()
        {
            var url = "\r\nhttps://api.privatbank.ua/p24api/pubinfo?exchange&coursid=5";
            var httpClient = _httpClientFactory.CreateClient();
            var json = await httpClient.GetFromJsonAsync<List<Currency>>(url);
            if (json != null)
            {
                return json;
            }
            else
            {
                throw new ArgumentException("Server API not aviable");
            }
        }

    }
}
