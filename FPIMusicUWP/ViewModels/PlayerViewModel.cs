using System;

using CommunityToolkit.Mvvm.ComponentModel;
using FPIMusicUWP.Services.Settings;
using FPIMusicUWP.Services;

namespace FPIMusicUWP.ViewModels
{
    public class PlayerViewModel : ObservableObject
    {
        private IService _service;
        private ISettingService _settingservice;
        public PlayerViewModel()
        {
        }
    }
}
