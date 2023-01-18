using System;

using FPIMusicUWP.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FPIMusicUWP.Views
{
    public sealed partial class DeezerPlaylistPage : Page
    {
        public DeezerPlaylistViewModel ViewModel { get; } = new DeezerPlaylistViewModel();

        public DeezerPlaylistPage()
        {
            InitializeComponent();
            Loaded += DeezerPlaylistPage_Loaded;
        }

        private async void DeezerPlaylistPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync();
        }
    }
}
