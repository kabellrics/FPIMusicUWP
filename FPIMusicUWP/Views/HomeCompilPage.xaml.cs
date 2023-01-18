using System;

using FPIMusicUWP.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FPIMusicUWP.Views
{
    public sealed partial class HomeCompilPage : Page
    {
        public HomeCompilViewModel ViewModel { get; } = new HomeCompilViewModel();

        public HomeCompilPage()
        {
            InitializeComponent();
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.InitializeAsync();
        }
    }
}
