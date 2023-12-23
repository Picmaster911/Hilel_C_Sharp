
using HomeWork_20_CRUD_HTTP;
using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

await GetInfoDNS();
await GetInfoFromServer();
static async Task GetInfoDNS ()
{
    var serverIpFromDNS = await Dns.GetHostEntryAsync("privatbank.ua");
    Console.WriteLine(serverIpFromDNS.HostName);
    serverIpFromDNS.AddressList.ToList().ForEach(dns => Console.WriteLine(dns));
}
static async Task GetInfoFromServer()
{

    var test = new Delegatecs();
    test.MyName += SuperMegapuper;
    test.Go();
    var privatUri = new Uri("\r\nhttps://api.privatbank.ua/p24api/pubinfo?exchange&coursid=5");
 
    using (var httpClient = new HttpClient()) 
    {
        var respone = await httpClient.GetAsync(privatUri);
        var content = await respone.Content.ReadAsStringAsync();
    }

    using (var httpClient = new HttpClient())
    {
        using var respone = await httpClient.GetAsync(privatUri);
        var json = await httpClient.GetFromJsonAsync<List<Currernsy>>("\r\nhttps://api.privatbank.ua/p24api/pubinfo?exchange&coursid=5");
        Console.WriteLine(json);
    }


   void SuperMegapuper (string s)
    {
        Console.WriteLine(s);
    }
   
    
}