using System;
using System.Threading.Tasks;
using FPIMusicUWP.Services;
using FPIMusicUWP.Services.Settings;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace FPIMusicUWP.ViewModels
{
    public class HomeCompilViewModel : ObservableObject
    {
        private IService _service;
        public HomeCompilViewModel()
        {
            _service = Ioc.Default.GetRequiredService<IService>();
        }
        public async Task InitializeAsync()
        {
        }
    }
}
