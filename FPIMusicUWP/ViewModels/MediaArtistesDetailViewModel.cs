using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using FPIMusicUWP.Core.Models;
using FPIMusicUWP.Core.Services;
using FPIMusicUWP.Helpers;

using CommunityToolkit.Mvvm.ComponentModel;

using Windows.UI.Xaml.Navigation;
using FPIMusicUWP.Services.Settings;
using FPIMusicUWP.Services;
using CommunityToolkit.Mvvm.DependencyInjection;
using FPIMusicUWP.ViewModels.ObservableObj.Mediatheque;
using FPIMusicUWP.ViewModels.ObservableObj;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Windows.UI.Xaml.Controls;
using FPIMusicUWP.Views;
using Microsoft.Toolkit.Uwp.UI.Animations;
using FPIMusicUWP.Core.Model;

namespace FPIMusicUWP.ViewModels
{
    public class MediaArtistesDetailViewModel : ObservableObject
    {
        private ObsMediaArtiste _selectedMediaArtiste;
        private IService _service;
        private ISettingService _settingservice;
        private ICommand _itemSelectedCommand;

        public ObsMediaArtiste SelectedMediaArtiste
        {
            get => _selectedMediaArtiste;
            set
            {
                SetProperty(ref _selectedMediaArtiste, value);
                ImagesNavigationHelper.UpdateImageId(MediaArtistesViewModel.MediaArtistesSelectedIdKey, ((ObsMediaArtiste)SelectedMediaArtiste)?.Id.ToString());
            }
        }
        public ICommand ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<ItemClickEventArgs>(OnItemSelected));

        public ObservableCollection<ObsMediaAlbum> Albums { get; } = new ObservableCollection<ObsMediaAlbum>();
        public ObservableCollection<ObsMediaAlbum> SelectedAlbums { get; } = new ObservableCollection<ObsMediaAlbum>();
        public MediaArtistesDetailViewModel()
        {
            _service = Ioc.Default.GetRequiredService<IService>();
            _settingservice = Ioc.Default.GetRequiredService<ISettingService>();
        }

        private void OnItemSelected(ItemClickEventArgs args)
        {
            var selected = args.ClickedItem as ObsMediaAlbum;
            //ImagesNavigationHelper.AddImageId(MediaArtistesSelectedIdKey, selected.Id.ToString());
            NavigationService.Frame.SetListDataItemForNextConnectedAnimation(selected);
            NavigationService.Navigate<MediaAlbumsDetailPage>(selected.Id);
        }
        public async Task LoadDataAsync()
        {
            Albums.Clear();
            if (SelectedMediaArtiste != null)
            {
                Initialize(SelectedMediaArtiste.Id, NavigationMode.New); 
            }
            //// Replace this with your actual data
            //var data = await SampleDataService.GetImageGalleryDataAsync("ms-appx:///Assets");

            //foreach (var item in data)
            //{
            //    Source.Add(item);
            //}
        }

        public async void Initialize(int selectedImageID, NavigationMode navigationMode)
        {
            if (selectedImageID !=-1 && navigationMode == NavigationMode.New)
            {
                Albums.Clear();
                var items = await _service.Mediatheque.Artistes.Artistes();
                var item = items.FirstOrDefault(x=>x.Id == selectedImageID);
                SelectedMediaArtiste =new ObsMediaArtiste(item,_settingservice.APIURLEndpoint);
                var data = await _service.Mediatheque.Albums.AlbumByArtiste(SelectedMediaArtiste.Id);
                foreach (var alb in data)
                {
                    Albums.Add(new ObsMediaAlbum(alb, _settingservice.APIURLEndpoint));
                }
            }
            //else
            //{
            //    selectedImageID = ImagesNavigationHelper.GetImageId(MediaArtistesViewModel.MediaArtistesSelectedIdKey);
            //    if (!string.IsNullOrEmpty(selectedImageID))
            //    {
            //        SelectedMediaArtiste = Source.FirstOrDefault(i => i.ID == selectedImageID);
            //    }
            //}
        }
    }
}
