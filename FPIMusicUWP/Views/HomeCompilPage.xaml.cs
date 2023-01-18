using System;

using FPIMusicUWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace FPIMusicUWP.Views
{
    public sealed partial class HomeCompilPage : Page
    {
        public HomeCompilViewModel ViewModel { get; } = new HomeCompilViewModel();

        public HomeCompilPage()
        {
            InitializeComponent();
        }
    }
}
