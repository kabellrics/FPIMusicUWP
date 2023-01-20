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
using System.Linq;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.Collections;

namespace FPIMusicUWP.ViewModels
{
    public class MediaArtistesViewModel : ObservableObject
    {
        public const string MediaArtistesSelectedIdKey = "MediaArtistesSelectedIdKey";

        private IService _service;
        private ISettingService _settingservice;
        private ICommand _itemSelectedCommand;

        //public ObservableCollection<SampleImage> Source { get; } = new ObservableCollection<SampleImage>();
        public ObservableCollection<ObsGroupedMediaArtiste> GrpArtistes{ get; } = new ObservableCollection<ObsGroupedMediaArtiste>();
        public ICommand ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<ItemClickEventArgs>(OnItemSelected));

        public MediaArtistesViewModel()
        {
            _service = Ioc.Default.GetRequiredService<IService>();
            _settingservice = Ioc.Default.GetRequiredService<ISettingService>();
        }

        public async Task LoadDataAsync()
        {
            //Source.Clear();
            GrpArtistes.Clear();
            var arts = await _service.Mediatheque.Artistes.groupedArtistes();
            foreach (var art in arts)
            {
                var obsitem = new ObsGroupedMediaArtiste(art, _settingservice.APIURLEndpoint);
                GrpArtistes.Add(obsitem);
            }

            // Replace this with your actual data
            //var data = await SampleDataService.GetImageGalleryDataAsync("ms-appx:///Assets");

            //foreach (var item in data)
            //{
            //    Source.Add(item);
            //}
        }

        private void OnItemSelected(ItemClickEventArgs args)
        {
            var selected = args.ClickedItem as ObsMediaArtiste;
            //ImagesNavigationHelper.AddImageId(MediaArtistesSelectedIdKey, selected.Id.ToString());
            NavigationService.Frame.SetListDataItemForNextConnectedAnimation(selected);
            NavigationService.Navigate<MediaArtistesDetailPage>(selected.Id);
        }
    }
}
