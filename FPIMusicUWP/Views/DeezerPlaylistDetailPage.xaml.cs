using System;

using FPIMusicUWP.Core.Models;
using FPIMusicUWP.Helpers;
using FPIMusicUWP.Services;
using FPIMusicUWP.ViewModels;
using FPIMusicUWP.ViewModels.ObservableObj.Deezer;
using Microsoft.Toolkit.Uwp.UI.Animations;

using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace FPIMusicUWP.Views
{
    public sealed partial class DeezerPlaylistDetailPage : Page
    {
        public DeezerPlaylistDetailViewModel ViewModel { get; } = new DeezerPlaylistDetailViewModel();

        public DeezerPlaylistDetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await ViewModel.LoadDataAsync();
            ViewModel.Initialize(int.Parse(e.Parameter.ToString()), e.NavigationMode);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(ViewModel.SelectedDeezerPlaylist);
                ImagesNavigationHelper.RemoveImageId(DeezerPlaylistViewModel.DeezerPlaylistSelectedIdKey);
            }
        }

        private void OnPageKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Escape && NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
                e.Handled = true;
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            foreach (var selectedItem in e.AddedItems)
            {
                ViewModel.SelectedSongs.Add(selectedItem as ObsDeezerSong);
            }
            foreach (var unSelectedItem in e.RemovedItems)
            {
                ViewModel.SelectedSongs.Remove(unSelectedItem as ObsDeezerSong);
            }
        }
    }
}
