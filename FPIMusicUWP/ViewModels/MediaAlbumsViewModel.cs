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
using CommunityToolkit.Mvvm.DependencyInjection;
using FPIMusicUWP.ViewModels.ObservableObj.Mediatheque;

namespace FPIMusicUWP.ViewModels
{
    public class MediaAlbumsViewModel : ObservableObject
    {
        public const string MediaAlbumsSelectedIdKey = "MediaAlbumsSelectedIdKey";
        private IService _service;
        private ISettingService _settingservice;

        private ICommand _itemSelectedCommand;

        //public ObservableCollection<SampleImage> Source { get; } = new ObservableCollection<SampleImage>();
        public ObservableCollection<ObsGroupedMediaAlbum> GrpAlbums { get; } = new ObservableCollection<ObsGroupedMediaAlbum>();

        public ICommand ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<ItemClickEventArgs>(OnItemSelected));

        public MediaAlbumsViewModel()
        {
            _service = Ioc.Default.GetRequiredService<IService>();
            _settingservice = Ioc.Default.GetRequiredService<ISettingService>();
        }

        public async Task LoadDataAsync()
        {
            GrpAlbums.Clear();
            var arts = await _service.Mediatheque.Albums.groupedAlbums();
            foreach (var art in arts)
            {
                var obsitem = new ObsGroupedMediaAlbum(art, _settingservice.APIURLEndpoint);
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
            //ImagesNavigationHelper.AddImageId(MediaAlbumsSelectedIdKey, selected.ID);
            //NavigationService.Frame.SetListDataItemForNextConnectedAnimation(selected);
            //NavigationService.Navigate<MediaAlbumsDetailPage>(selected.ID);
        }
    }
}
