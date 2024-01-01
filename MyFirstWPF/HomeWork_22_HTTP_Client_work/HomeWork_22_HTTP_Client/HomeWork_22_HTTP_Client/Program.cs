using HomeWork_22_HTTP_Client;
using HomeWork_22_HTTP_Client.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;


var services = new ServiceCollection();
var goLoop = true;
services.AddSingleton<IRemoteData, MyHttpDataClient>();
services.AddSingleton<ILoger, LogerToConsole>();
services.AddTransient<DataWorker>();
services.AddHttpClient();
using var serviceProvider = services.BuildServiceProvider();

//var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>(); - Для меня чтоб не забыть
var httpClient = serviceProvider.GetRequiredService<IRemoteData>();
var dataWorker = serviceProvider.GetRequiredService<DataWorker>();

 async Task<IEnumerable<CurrencyAndTime>> ReadFromDb()
{

    using (var myDB = new AppDbContext())
    {
        var data = await myDB.Currencys
            .AsQueryable()
            .Where(item => item.Date > DateTime.Now.AddDays(-1))
            .OrderBy(item => item.Date)
            .ToListAsync();
        return data.TakeLast(100); ;
    }

}

var dataFromServer = await ReadFromDb();
var PriceDataEuro = dataFromServer
               .Where(item => item.Ccy == "EUR")
               .Select(item => item.Buy);

httpClient.Enable=true;

foreach (var item in PriceDataEuro)
{
    var test = double.Parse(item, CultureInfo.InvariantCulture);
}

while (true)
{
    Thread.Sleep(10000);
    httpClient.Enable = false;
    Console.WriteLine("finish");
}
   
