using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using plc_wpf.Infrastructure;
using plc_wpf.Model;
using plc_wpf.View;
using plc_wpf.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace plc_wpf
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
            services.AddSingleton<MainWindowVM>();
            

            services.AddSingleton<PlcComponentVM>();
            services.AddSingleton<PlcConectionVM>();

            services.AddTransient<DataWorker>();
            services.AddSingleton<FabricCreatorPlc>();
            
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();
            var fabricCreatorPlc = _host.Services.GetRequiredService<FabricCreatorPlc>();
            fabricCreatorPlc.CreatePlcList();
            
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            var mainWindowVM = _host.Services.GetRequiredService<MainWindowVM>();
                  
            mainWindow.DataContext = mainWindowVM;
            mainWindow.Show();
            base.OnStartup(e);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }
            base.OnExit(e);
        }
    }
}

