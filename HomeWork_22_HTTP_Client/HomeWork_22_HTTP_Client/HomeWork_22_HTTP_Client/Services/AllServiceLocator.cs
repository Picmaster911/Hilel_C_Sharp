using DevExpress.Mvvm.POCO;
using HomeWork_22_HTTP_Client.DataProvider;
using HomeWork_22_HTTP_Client.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_22_HTTP_Client.Services
{
    internal class AllServiceLocator
    {
        private static ServiceProvider _provider;

        public static void Init ()
        {
            var services = new ServiceCollection();

            services.AddTransient <MainWindowViewModel>();
            services.AddSingleton<IDataProvider, HttpDataProvider>();
            services.AddHttpClient();

            _provider = services.BuildServiceProvider ();

            //foreach (var service in services) 
            //{
            //    _provider.GetRequiredService(service.ServiceType);
            //}
           
        }

        public MainWindowViewModel MainWindowViewModel => _provider.GetRequiredService<MainWindowViewModel> ();
        public IHttpClientFactory httpClientFactory = _provider.GetRequiredService<IHttpClientFactory>();
        public IDataProvider dataProvider = _provider.GetRequiredService<IDataProvider>();
    }
}
