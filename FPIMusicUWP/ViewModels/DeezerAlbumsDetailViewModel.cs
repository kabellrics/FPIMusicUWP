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
using FPIMusicUWP.ViewModels.ObservableObj.Deezer;
using FPIMusicUWP.ViewModels.ObservableObj.Compilation;

namespace FPIMusicUWP.ViewModels
{
    public class DeezerAlbumsDetailViewModel : ObservableObject
    {
        private ObsDeezerAlbum _selectedDeezerAlbum;
        private IService _service;
        private ISettingService _settingservice;

        public ObsDeezerAlbum SelectedDeezerAlbum
        {
            get => _selectedDeezerAlbum;
            set
            {
                SetProperty(ref _selectedDeezerAlbum, value);
                ImagesNavigationHelper.UpdateImageId(DeezerAlbumsViewModel.DeezerAlbumsSelectedIdKey, ((ObsDeezerAlbum)SelectedDeezerAlbum)?.Id.ToString());
            }
        }

        public ObservableCollection<ObsDeezerSong> Songs { get; } = new ObservableCollection<ObsDeezerSong>();
        public ObservableCollection<ObsDeezerSong> SelectedSongs { get; } = new ObservableCollection<ObsDeezerSong>();

        public DeezerAlbumsDetailViewModel()
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
            if (selectedImageID != -1 && navigationMode == NavigationMode.New)
            {
                var items = await _service.Deezer.Albums.Albums();
                var item = items.FirstOrDefault(x => x.Id == selectedImageID);
                SelectedDeezerAlbum = new ObsDeezerAlbum(item, _settingservice.APIURLEndpoint);
                var data = await _service.Deezer.Songs.SongByAlbum(SelectedDeezerAlbum.Id);
                foreach (var song in data)
                {
                    Songs.Add(new ObsDeezerSong(song, _settingservice.APIURLEndpoint));
                }
            }
            //else
            //{
            //    selectedImageID = ImagesNavigationHelper.GetImageId(DeezerAlbumsViewModel.DeezerAlbumsSelectedIdKey);
            //    if (!string.IsNullOrEmpty(selectedImageID))
            //    {
            //        SelectedImage = Source.FirstOrDefault(i => i.ID == selectedImageID);
            //    }
            //}
        }
    }
}
