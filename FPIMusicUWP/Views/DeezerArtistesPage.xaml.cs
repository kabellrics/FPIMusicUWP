using System;

using FPIMusicUWP.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FPIMusicUWP.Views
{
    public sealed partial class DeezerArtistesPage : Page
    {
        public DeezerArtistesViewModel ViewModel { get; } = new DeezerArtistesViewModel();

        public DeezerArtistesPage()
        {
            InitializeComponent();
            Loaded += DeezerArtistesPage_Loaded;
        }

        private async void DeezerArtistesPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync();
        }
    }
}
