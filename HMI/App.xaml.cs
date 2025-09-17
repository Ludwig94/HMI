using HMI.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace HMI;

public partial class App : Application
{
    private IHost? _host;

 public App()
    {
        var builder = Host.CreateApplicationBuilder();

        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddTransient<AlertViewModel>();
        builder.Services.AddTransient<HomeViewModel>();

        builder.Services.AddSingleton<MainWindow>();
        _host = builder.Build();
        

    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _host!.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _host?.Dispose();
        base.OnExit(e);
    }
}
