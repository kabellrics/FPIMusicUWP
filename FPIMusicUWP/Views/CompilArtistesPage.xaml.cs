using System;

using FPIMusicUWP.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FPIMusicUWP.Views
{
    public sealed partial class CompilArtistesPage : Page
    {
        public CompilArtistesViewModel ViewModel { get; } = new CompilArtistesViewModel();

        public CompilArtistesPage()
        {
            InitializeComponent();
            Loaded += CompilArtistesPage_Loaded;
        }

        private async void CompilArtistesPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync();
        }
    }
}
