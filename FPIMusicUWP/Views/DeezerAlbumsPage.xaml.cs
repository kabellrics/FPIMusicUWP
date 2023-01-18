using System;

using FPIMusicUWP.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FPIMusicUWP.Views
{
    public sealed partial class DeezerAlbumsPage : Page
    {
        public DeezerAlbumsViewModel ViewModel { get; } = new DeezerAlbumsViewModel();

        public DeezerAlbumsPage()
        {
            InitializeComponent();
            Loaded += DeezerAlbumsPage_Loaded;
        }

        private async void DeezerAlbumsPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync();
        }
    }
}
