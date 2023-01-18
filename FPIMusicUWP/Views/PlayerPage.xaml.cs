using System;

using FPIMusicUWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace FPIMusicUWP.Views
{
    public sealed partial class PlayerPage : Page
    {
        public PlayerViewModel ViewModel { get; } = new PlayerViewModel();

        public PlayerPage()
        {
            InitializeComponent();
        }
    }
}
