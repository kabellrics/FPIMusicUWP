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

namespace FPIMusicUWP.ViewModels
{
    public class DeezerPlaylistDetailViewModel : ObservableObject
    {
        private ObsDeezerPlaylist _selectedDeezerPlaylist;
        private IService _service;
        private ISettingService _settingservice;

        public ObsDeezerPlaylist SelectedDeezerPlaylist
        {
            get => _selectedDeezerPlaylist;
            set
            {
                SetProperty(ref _selectedDeezerPlaylist, value);
                ImagesNavigationHelper.UpdateImageId(DeezerPlaylistViewModel.DeezerPlaylistSelectedIdKey, ((ObsDeezerPlaylist)SelectedDeezerPlaylist)?.Id.ToString());
            }
        }

        //public ObservableCollection<SampleImage> Source { get; } = new ObservableCollection<SampleImage>();

        public DeezerPlaylistDetailViewModel()
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
                var items = await _service.Deezer.Playlists.Playlists();
                var item = items.FirstOrDefault(x => x.Id == selectedImageID);
                SelectedDeezerPlaylist = new ObsDeezerPlaylist(item, _settingservice.APIURLEndpoint);
            }
            //else
            //{
            //    selectedImageID = ImagesNavigationHelper.GetImageId(DeezerPlaylistViewModel.DeezerPlaylistSelectedIdKey);
            //    if (!string.IsNullOrEmpty(selectedImageID))
            //    {
            //        SelectedImage = Source.FirstOrDefault(i => i.ID == selectedImageID);
            //    }
            //}
        }
    }
}
