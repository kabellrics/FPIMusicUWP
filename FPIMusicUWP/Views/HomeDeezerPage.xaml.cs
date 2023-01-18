using System;

using FPIMusicUWP.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FPIMusicUWP.Views
{
    public sealed partial class HomeDeezerPage : Page
    {
        public HomeDeezerViewModel ViewModel { get; } = new HomeDeezerViewModel();

        public HomeDeezerPage()
        {
            InitializeComponent();
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.InitializeAsync();
        }
    }
}
