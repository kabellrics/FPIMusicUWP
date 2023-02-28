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
using Microsoft.Toolkit.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace FPIMusicUWP.ViewModels
{
    public class MediaAlbumsViewModel : ObservableObject
    {
        public const string MediaAlbumsSelectedIdKey = "MediaAlbumsSelectedIdKey";
        private IService _service;
        private ISettingService _settingservice;

        private ICommand _itemSelectedCommand;

        //public ObservableCollection<SampleImage> Source { get; } = new ObservableCollection<SampleImage>();
        //public List<ObsGroupedMediaAlbum> GrpAlbums { get; } = new List<ObsGroupedMediaAlbum>();
        public ObservableCollection<ObsGroupedMediaAlbum> GrpAlbums { get; } = new ObservableCollection<ObsGroupedMediaAlbum>();
        public ReadOnlyObservableGroupedCollection<string, ObsMediaAlbum> ObsGrpAlbums { get; set; }
        public ObservableCollection<ObsMediaAlbum> LastAlbums { get; } = new ObservableCollection<ObsMediaAlbum>();

        public ICommand ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<ItemClickEventArgs>(OnItemSelected));

        public MediaAlbumsViewModel()
        {
            _service = Ioc.Default.GetRequiredService<IService>();
            _settingservice = Ioc.Default.GetRequiredService<ISettingService>();
        }

        public async Task LoadDataAsync()
        {
            GrpAlbums.Clear();
            LastAlbums.Clear();
            var arts = await _service.Mediatheque.Albums.groupedAlbums();
            var lastitems = arts.SelectMany(x => x.Items).OrderByDescending(x => x.Id).Take(5);
            foreach (var art in lastitems)
            {
                var obsitem = new ObsMediaAlbum(art, _settingservice.APIURLEndpoint);
                LastAlbums.Add(obsitem);
            }
            var albSource = new ObservableGroupedCollection<String, ObsMediaAlbum>();
            foreach (var art in arts)
            {
                var obsitem = new ObsGroupedMediaAlbum(art, _settingservice.APIURLEndpoint);
                albSource.AddGroup(obsitem.Key, obsitem.Items);
                GrpAlbums.Add(obsitem);
            }
            ObsGrpAlbums = new ReadOnlyObservableGroupedCollection<string, ObsMediaAlbum>(albSource);

        }

        private void OnItemSelected(ItemClickEventArgs args)
        {
            var selected = args.ClickedItem as ObsMediaAlbum;
            //ImagesNavigationHelper.AddImageId(MediaAlbumsSelectedIdKey, selected.ID);
            NavigationService.Frame.SetListDataItemForNextConnectedAnimation(selected);
            NavigationService.Navigate<MediaAlbumsDetailPage>(selected.Id);
        }
    }
}
