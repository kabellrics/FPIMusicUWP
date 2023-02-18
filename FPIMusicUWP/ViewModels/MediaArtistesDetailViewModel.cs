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

namespace FPIMusicUWP.ViewModels
{
    public class MediaArtistesDetailViewModel : ObservableObject
    {
        private ObsMediaArtiste _selectedMediaArtiste;
        private IService _service;
        private ISettingService _settingservice;

        public ObsMediaArtiste SelectedMediaArtiste
        {
            get => _selectedMediaArtiste;
            set
            {
                SetProperty(ref _selectedMediaArtiste, value);
                ImagesNavigationHelper.UpdateImageId(MediaArtistesViewModel.MediaArtistesSelectedIdKey, ((ObsMediaArtiste)SelectedMediaArtiste)?.Id.ToString());
            }
        }

        public ObservableCollection<ObsMediaAlbum> Albums { get; } = new ObservableCollection<ObsMediaAlbum>();
        public ObservableCollection<ObsMediaAlbum> SelectedAlbums { get; } = new ObservableCollection<ObsMediaAlbum>();
        public MediaArtistesDetailViewModel()
        {
            _service = Ioc.Default.GetRequiredService<IService>();
            _settingservice = Ioc.Default.GetRequiredService<ISettingService>();
        }

        public async Task LoadDataAsync()
        {
            //Source.Clear();

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
