using System;

using FPIMusicUWP.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FPIMusicUWP.Views
{
    public sealed partial class MediaAlbumsPage : Page
    {
        public MediaAlbumsViewModel ViewModel { get; } = new MediaAlbumsViewModel();

        public MediaAlbumsPage()
        {
            InitializeComponent();
            Loaded += MediaAlbumsPage_Loaded;
        }

        private async void MediaAlbumsPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync();
        }
    }
}
