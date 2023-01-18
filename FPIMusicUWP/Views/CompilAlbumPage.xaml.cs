using System;

using FPIMusicUWP.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FPIMusicUWP.Views
{
    public sealed partial class CompilAlbumPage : Page
    {
        public CompilAlbumViewModel ViewModel { get; } = new CompilAlbumViewModel();

        public CompilAlbumPage()
        {
            InitializeComponent();
            Loaded += CompilAlbumPage_Loaded;
        }

        private async void CompilAlbumPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync();
        }
    }
}
