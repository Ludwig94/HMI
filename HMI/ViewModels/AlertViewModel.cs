using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace HMI.ViewModels
{
    public partial class AlertViewModel : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;

        public AlertViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [ObservableProperty]
        private string _title = "Alerts";

        [RelayCommand]
        private void NavigateToHome()
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<HomeViewModel>();
        }
    }
}
