using System;
using CommunityToolkit.Mvvm.DependencyInjection;
using FPIMusicUWP.Core.Models;
using FPIMusicUWP.Helpers;
using FPIMusicUWP.Services;
using FPIMusicUWP.ViewModels;

using Microsoft.Toolkit.Uwp.UI.Animations;

using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace FPIMusicUWP.Views
{
    public sealed partial class MediaArtistesDetailPage : Page
    {
        public MediaArtistesDetailViewModel ViewModel { get; set; }// = new MediaArtistesDetailViewModel();

        public MediaArtistesDetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel = Ioc.Default.GetRequiredService<MediaArtistesDetailViewModel>();
            //await ViewModel.LoadDataAsync();
            ViewModel.Initialize(int.Parse(e.Parameter.ToString()), e.NavigationMode);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(ViewModel.SelectedMediaArtiste);
                ImagesNavigationHelper.RemoveImageId(MediaArtistesViewModel.MediaArtistesSelectedIdKey);
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
    }
}
