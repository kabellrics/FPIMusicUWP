using System;
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
    public sealed partial class CompilArtistesDetailPage : Page
    {
        public CompilArtistesDetailViewModel ViewModel { get; set; }// = new CompilArtistesDetailViewModel();

        public CompilArtistesDetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel = Ioc.Default.GetRequiredService<CompilArtistesDetailViewModel>();
            await ViewModel.LoadDataAsync();
            ViewModel.Initialize(int.Parse(e.Parameter.ToString()), e.NavigationMode);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(ViewModel.SelectedCompilArtiste);
                ImagesNavigationHelper.RemoveImageId(CompilArtistesViewModel.CompilArtistesSelectedIdKey);
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
            //foreach (var selectedItem in e.AddedItems)
            //{
            //    ViewModel.SelectedArtSongs.Add(selectedItem as ObsSong);
            //}
            //foreach (var unSelectedItem in e.RemovedItems)
            //{
            //    ViewModel.SelectedArtSongs.Remove(unSelectedItem as ObsSong);
            //}
        }
    }
}
