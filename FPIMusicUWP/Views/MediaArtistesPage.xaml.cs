using System;

using FPIMusicUWP.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FPIMusicUWP.Views
{
    public sealed partial class MediaArtistesPage : Page
    {
        public MediaArtistesViewModel ViewModel { get; } = new MediaArtistesViewModel();

        public MediaArtistesPage()
        {
            InitializeComponent();
            Loaded += MediaArtistesPage_Loaded;
        }

        private async void MediaArtistesPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync();
        }
    }
}
