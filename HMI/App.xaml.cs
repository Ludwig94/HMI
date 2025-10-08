using HMI.Services;
using HMI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace HMI
{
    public partial class App : Application
    {
        private IHost? _host;

        public App()
        {
            var builder = Host.CreateApplicationBuilder();

            // Register services
            builder.Services.AddSingleton<FanService>();

            // Register ViewModels as singletons
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<HomeViewModel>();

            // Register MainWindow
            builder.Services.AddSingleton<MainWindow>();

            _host = builder.Build();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _host!.Services.GetRequiredService<MainWindow>();
            mainWindow.DataContext = _host!.Services.GetRequiredService<MainViewModel>();
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host?.Dispose();
            base.OnExit(e);
        }
    }
}