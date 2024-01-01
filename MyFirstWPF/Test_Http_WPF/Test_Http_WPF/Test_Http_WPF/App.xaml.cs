using HomeWork_22_HTTP_Client;

using System.Windows;
using Test_Http_WPF.View;
using Test_Http_WPF.ViewModel;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HomeWork_22_HTTP_Client.Models;

namespace Test_Http_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) => {
                   ConfigureServices(services);
               })
               .Build();
        }
        private void ConfigureServices(IServiceCollection services)
        {          
            services.AddSingleton<MainWindow>();
            services.AddSingleton<CurrencyChartViewModel>();
            services.AddSingleton<MainWindowViewModel>();

            services.AddHttpClient();
            services.AddSingleton<IRemoteData, MyHttpDataClient>();
            services.AddSingleton<ILoger, LogerToConsole>();
            services.AddTransient<DataWorker>();
            services.AddSingleton<HttpCientViewModel>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            var mainWindowViewModel =_host.Services.GetRequiredService<MainWindowViewModel>();
            mainWindow.DataContext = mainWindowViewModel;
            mainWindow.Show();
            base.OnStartup(e);
        }
        protected override async void OnExit (ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();    
            }
            base.OnExit(e);    
        }
    }
}
