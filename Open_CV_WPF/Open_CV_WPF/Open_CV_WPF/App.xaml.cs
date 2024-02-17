using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Open_CV_WPF.Service;
using Open_CV_WPF.View;
using Open_CV_WPF.ViewModel;
using System.Windows;

namespace Open_CV_WPF
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
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<CameraFirstViewModel>();            
            services.AddSingleton<CameraService>();

        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            var mainWindowVM = _host.Services.GetRequiredService<MainWindowViewModel>();

            mainWindow.DataContext = mainWindowVM;
            mainWindow.Show();
            //var сameraService = _host.Services.GetRequiredService<CameraService>();
            //сameraService.InitCamera();
            //сameraService.EventFromVideoCams += mainWindowVM.EventFromCamera;
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

