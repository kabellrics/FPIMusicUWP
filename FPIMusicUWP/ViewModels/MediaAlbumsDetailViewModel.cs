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

namespace FPIMusicUWP.ViewModels
{
    public class MediaAlbumsDetailViewModel : ObservableObject
    {
        private ObsMediaAlbum _selectedMediaAlbum;
        private IService _service;
        private ISettingService _settingservice;

        public ObsMediaAlbum SelectedMediaAlbum
        {
            get => _selectedMediaAlbum;
            set
            {
                SetProperty(ref _selectedMediaAlbum, value);
                ImagesNavigationHelper.UpdateImageId(MediaAlbumsViewModel.MediaAlbumsSelectedIdKey, ((ObsMediaAlbum)SelectedMediaAlbum)?.Id.ToString());
            }
        }

        //public ObservableCollection<SampleImage> Source { get; } = new ObservableCollection<SampleImage>();

        public MediaAlbumsDetailViewModel()
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
                var items = await _service.Mediatheque.Albums.Albums();
                var item = items.FirstOrDefault(x => x.Id == selectedImageID);
                SelectedMediaAlbum = new ObsMediaAlbum(item, _settingservice.APIURLEndpoint);
            }
            //else
            //{
            //    selectedImageID = ImagesNavigationHelper.GetImageId(MediaAlbumsViewModel.MediaAlbumsSelectedIdKey);
            //    if (!string.IsNullOrEmpty(selectedImageID))
            //    {
            //        SelectedImage = Source.FirstOrDefault(i => i.ID == selectedImageID);
            //    }
            //}
        }
    }
}
