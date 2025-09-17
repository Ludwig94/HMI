using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMI.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;

        public MainViewModel(IServiceProvider serviceProvider)
        {
           _serviceProvider = serviceProvider;

            CurrentViewModel = _serviceProvider.GetRequiredService<HomeViewModel>();

            
        }


        [ObservableProperty]
        private ObservableObject _currentViewModel = null!;

        
    }
}
