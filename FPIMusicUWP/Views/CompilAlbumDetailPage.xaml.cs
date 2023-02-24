using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.DependencyInjection;
using FPIMusicUWP.Core.Models;
using FPIMusicUWP.Helpers;
using FPIMusicUWP.Services;
using FPIMusicUWP.ViewModels;
using FPIMusicUWP.ViewModels.ObservableObj;
using Microsoft.Toolkit.Uwp.UI.Animations;

using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace FPIMusicUWP.Views
{
    public sealed partial class CompilAlbumDetailPage : Page
    {
        public CompilAlbumDetailViewModel ViewModel { get; set; }// = new CompilAlbumDetailViewModel();

        public CompilAlbumDetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel = Ioc.Default.GetRequiredService<CompilAlbumDetailViewModel>();
            await ViewModel.LoadDataAsync();
            ViewModel.Initialize(int.Parse(e.Parameter.ToString()), e.NavigationMode);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(ViewModel.SelectedCompilAlbum);
                ImagesNavigationHelper.RemoveImageId(CompilAlbumViewModel.CompilAlbumSelectedIdKey);
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

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //foreach (var selectedItem in e.AddedItems)
            //{
            //    ViewModel.SelectedAlbSongs.Add(selectedItem as ObsSong);
            //}
            //foreach (var unSelectedItem in e.RemovedItems)
            //{
            //    ViewModel.SelectedAlbSongs.Remove(unSelectedItem as ObsSong);
            //}
        }
    }
}
