using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using FPIMusicUWP.Core.Models;
using FPIMusicUWP.Core.Services;
using FPIMusicUWP.Helpers;
using FPIMusicUWP.Services;
using FPIMusicUWP.Views;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Toolkit.Uwp.UI.Animations;

using Windows.UI.Xaml.Controls;
using FPIMusicUWP.Services.Settings;
using FPIMusicUWP.ViewModels.ObservableObj.Deezer;
using CommunityToolkit.Mvvm.DependencyInjection;
using FPIMusicUWP.ViewModels.ObservableObj.Mediatheque;

namespace FPIMusicUWP.ViewModels
{
    public class DeezerAlbumsViewModel : ObservableObject
    {
        public const string DeezerAlbumsSelectedIdKey = "DeezerAlbumsSelectedIdKey";
        private IService _service;
        private ISettingService _settingservice;

        private ICommand _itemSelectedCommand;

        //public ObservableCollection<SampleImage> Source { get; } = new ObservableCollection<SampleImage>();
        public ObservableCollection<ObsGroupedDeezerAlbum> GrpAlbums { get; } = new ObservableCollection<ObsGroupedDeezerAlbum>();

        public ICommand ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<ItemClickEventArgs>(OnItemSelected));

        public DeezerAlbumsViewModel()
        {
            _service = Ioc.Default.GetRequiredService<IService>();
            _settingservice = Ioc.Default.GetRequiredService<ISettingService>();
        }

        public async Task LoadDataAsync()
        {
            GrpAlbums.Clear();
            var arts = await _service.Deezer.Albums.GroupedAlbums();
            foreach (var art in arts)
            {
                var obsitem = new ObsGroupedDeezerAlbum(art, _settingservice.APIURLEndpoint);
                GrpAlbums.Add(obsitem);
            }
            //    Source.Clear();

            //    // Replace this with your actual data
            //    var data = await SampleDataService.GetImageGalleryDataAsync("ms-appx:///Assets");

            //    foreach (var item in data)
            //    {
            //        Source.Add(item);
            //    }
        }

        private void OnItemSelected(ItemClickEventArgs args)
        {
            //var selected = args.ClickedItem as SampleImage;
            //ImagesNavigationHelper.AddImageId(DeezerAlbumsSelectedIdKey, selected.ID);
            //NavigationService.Frame.SetListDataItemForNextConnectedAnimation(selected);
            //NavigationService.Navigate<DeezerAlbumsDetailPage>(selected.ID);
        }
    }
}
