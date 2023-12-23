using HomeWork_22_HTTP_Client.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_22_HTTP_Client.DataProvider
{
    internal class HttpDataProvider : IDataProvider
    {
        private IHttpClientFactory _httpClientFactory;
        public HttpDataProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
         async Task <IEnumerable<Currency>> IDataProvider.GetData()
        {
            
            var httpClient =  _httpClientFactory.CreateClient();
            var json = await httpClient.GetFromJsonAsync<List<Currency>>("\r\nhttps://api.privatbank.ua/p24api/pubinfo?exchange&coursid=5");
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
