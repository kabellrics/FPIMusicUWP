using System;

using FPIMusicUWP.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FPIMusicUWP.Views
{
    public sealed partial class HomeMediaPage : Page
    {
        public HomeMediaViewModel ViewModel { get; } = new HomeMediaViewModel();

        public HomeMediaPage()
        {
            InitializeComponent();
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.InitializeAsync();
        }
    }
}
