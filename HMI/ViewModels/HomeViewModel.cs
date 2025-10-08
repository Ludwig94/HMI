using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HMI.Services;
using System.Threading.Tasks;

namespace HMI.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly FanService _fanService;

        public HomeViewModel(FanService fanService)
        {
            _fanService = fanService;
        }

        [ObservableProperty]
        private bool _isRunning;

        [ObservableProperty]
        private decimal _speed;

        [ObservableProperty]
        private string _buttonText = "Start";

        [RelayCommand]
        private async Task ToggleFanAsync()
        {
            if (IsRunning)
            {
                await _fanService.StopFanAsync();
                IsRunning = false;
                ButtonText = "Start";
            }
            else
            {
                await _fanService.StartFanAsync();
                IsRunning = true;
                ButtonText = "Stop";
            }
        }

        partial void OnSpeedChanged(decimal value)
        {
            // Kör kommandot när Speed ändras
            _ = SetSpeedAsync();
        }

        [RelayCommand]
        private async Task SetSpeedAsync()
        {
            await _fanService.SetSpeedAsync(Speed);
        }

        [RelayCommand]
        private async Task RefreshStatusAsync()
        {
            var status = await _fanService.GetStatusAsync();
            if (status != null)
            {
                IsRunning = status.IsRunning;
                Speed = status.CurrentSpeed;
            }
        }
    }
}