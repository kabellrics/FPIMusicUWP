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
using FPIMusicUWP.ViewModels.ObservableObj.Deezer;
using FPIMusicUWP.Services.Settings;
using CommunityToolkit.Mvvm.DependencyInjection;
using FPIMusicUWP.ViewModels.ObservableObj.Mediatheque;

namespace FPIMusicUWP.ViewModels
{
    public class DeezerArtistesViewModel : ObservableObject
    {
        public const string DeezerArtistesSelectedIdKey = "DeezerArtistesSelectedIdKey";

        private IService _service;
        private ISettingService _settingservice;
        private ICommand _itemSelectedCommand;

        //public ObservableCollection<SampleImage> Source { get; } = new ObservableCollection<SampleImage>();
        public ObservableCollection<ObsGroupedDeezerArtiste> GrpArtistes { get; } = new ObservableCollection<ObsGroupedDeezerArtiste>();

        public ICommand ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<ItemClickEventArgs>(OnItemSelected));

        public DeezerArtistesViewModel()
        {
            _service = Ioc.Default.GetRequiredService<IService>();
            _settingservice = Ioc.Default.GetRequiredService<ISettingService>();
        }

        public async Task LoadDataAsync()
        {
            //Source.Clear();
            GrpArtistes.Clear();
            var arts = await _service.Deezer.Artistes.GroupedArtistes();
            foreach (var art in arts)
            {
                var obsitem = new ObsGroupedDeezerArtiste(art, _settingservice.APIURLEndpoint);
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
            //var selected = args.ClickedItem as SampleImage;
            //ImagesNavigationHelper.AddImageId(DeezerArtistesSelectedIdKey, selected.ID);
            //NavigationService.Frame.SetListDataItemForNextConnectedAnimation(selected);
            //NavigationService.Navigate<DeezerArtistesDetailPage>(selected.ID);
        }
    }
}
