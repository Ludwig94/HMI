using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HMI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;

        // Konstruktor tar in service provider
        public MainViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            // Sätt initial ViewModel till HomeViewModel
            CurrentViewModel = _serviceProvider.GetRequiredService<HomeViewModel>();
        }

        // Den ViewModel som visas i ContentControl
        [ObservableProperty]
        private ObservableObject _currentViewModel = null!;

        // Optional: Metod för att byta ViewModel
        public void NavigateTo<TViewModel>() where TViewModel : ObservableObject
        {
            CurrentViewModel = _serviceProvider.GetRequiredService<TViewModel>();
        }
    }
}