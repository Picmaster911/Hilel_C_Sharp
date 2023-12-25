using HomeWork_22_HTTP_Client;
using HomeWork_22_HTTP_Client.Models;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var goLoop = true;
services.AddSingleton<IRemoteData, HttpDataProvider>();
services.AddSingleton<ILoger, LogerToConsole>();
services.AddTransient<DataWorker>();
services.AddHttpClient();
using var serviceProvider = services.BuildServiceProvider();

//var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>(); - Для меня чтоб не забыть
var httpClient = serviceProvider.GetRequiredService<IRemoteData>();
var dataWorker = serviceProvider.GetRequiredService<DataWorker>();

while (goLoop)
{
    var allCurencyFromServer = await httpClient.GetData();
    dataWorker.AddToDb(allCurencyFromServer);
    Thread.Sleep(2000);
}

