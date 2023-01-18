using System;
using System.Threading.Tasks;
using FPIMusicUWP.Services;
using FPIMusicUWP.Services.Settings;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace FPIMusicUWP.ViewModels
{
    public class HomeDeezerViewModel : ObservableObject
    {
        private IService _service;
        public HomeDeezerViewModel()
        {
            _service = Ioc.Default.GetRequiredService<IService>();
        }
        public async Task InitializeAsync()
        {
        }
    }
}
