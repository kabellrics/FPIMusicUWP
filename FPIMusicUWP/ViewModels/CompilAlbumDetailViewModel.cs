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
using FPIMusicUWP.ViewModels.ObservableObj.Compilation;
using FPIMusicUWP.ViewModels.ObservableObj;
using System.Windows.Input;

namespace FPIMusicUWP.ViewModels
{
    public class CompilAlbumDetailViewModel : ObservableObject
    {
        private ObsCompilAlbum _selectedCompilAlbum;
        private IService _service;
        private ISettingService _settingservice;

        public ObsCompilAlbum SelectedCompilAlbum
        {
            get => _selectedCompilAlbum;
            set
            {
                SetProperty(ref _selectedCompilAlbum, value);
                ImagesNavigationHelper.UpdateImageId(CompilAlbumViewModel.CompilAlbumSelectedIdKey, ((ObsCompilAlbum)SelectedCompilAlbum)?.Id.ToString());
            }
        }

        public ObservableCollection<ObsSong> AlbSongs { get; } = new ObservableCollection<ObsSong>();
        public ObservableCollection<ObsSong> SelectedAlbSongs { get; } = new ObservableCollection<ObsSong>();

        public CompilAlbumDetailViewModel()
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
                var items = await _service.Compilation.Albums.Albums();
                var item = items.FirstOrDefault(x => x.Id == selectedImageID);
                SelectedCompilAlbum = new ObsCompilAlbum(item, _settingservice.APIURLEndpoint);
                var data = await _service.Compilation.Song.SongByAlbum(SelectedCompilAlbum.Id);
                foreach (var song in data)
                {
                    AlbSongs.Add(new ObsSong(song, _settingservice.APIURLEndpoint));
                }
            }
            //else
            //{
            //    selectedImageID = ImagesNavigationHelper.GetImageId(CompilAlbumViewModel.CompilAlbumSelectedIdKey);
            //    if (!string.IsNullOrEmpty(selectedImageID))
            //    {
            //        SelectedImage = Source.FirstOrDefault(i => i.ID == selectedImageID);
            //    }
            //}
        }
    }
}
