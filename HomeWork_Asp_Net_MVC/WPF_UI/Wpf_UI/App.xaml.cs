using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyNoteProcessor;
using NoteContracs;
using System.Windows;
using Wpf_UI.Infrastructure;
using Wpf_UI.View;
using Wpf_UI.ViewModel;
using Wpf_UI.ViewModel.Elements;

namespace Wpf_UI
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
            string projectDirectory = System.IO.Path.GetFullPath(@"..\..\..\..\..\");
            string myDir = "Data\\MyNoteDatabase.db";
            string path = "Data Source ="+ System.IO.Path.Combine(projectDirectory, myDir);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(path);
            });

            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<INoteProcessor, NoteProcessor>();
            services.AddTransient<IDataWorker<MyNote>, DataWorker>();

            services.AddTransient<NoteViewModel>();
            services.AddSingleton<CreatorNotes>(); 

        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            var mainWindowVM = _host.Services.GetRequiredService<MainWindowViewModel>();
            
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
