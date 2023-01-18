using System;

using FPIMusicUWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace FPIMusicUWP.Views
{
    public sealed partial class HomeMediaPage : Page
    {
        public HomeMediaViewModel ViewModel { get; } = new HomeMediaViewModel();

        public HomeMediaPage()
        {
            InitializeComponent();
        }
    }
}
