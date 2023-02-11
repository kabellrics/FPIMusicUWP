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
using FPIMusicUWP.ViewModels.ObservableObj.Mediatheque;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Windows.UI.Xaml.Controls;

namespace FPIMusicUWP.ViewModels
{
    public class CompilArtistesDetailViewModel : ObservableObject
    {
        private ObsCompilArtiste _selectedCompilArtiste;
        private IService _service;
        private ISettingService _settingservice;

        public ObsCompilArtiste SelectedCompilArtiste
        {
            get => _selectedCompilArtiste;
            set
            {
                SetProperty(ref _selectedCompilArtiste, value);
                ImagesNavigationHelper.UpdateImageId(CompilArtistesViewModel.CompilArtistesSelectedIdKey, ((ObsCompilArtiste)SelectedCompilArtiste)?.Id.ToString());
            }
        }

        public ObservableCollection<ObsCompilSong> ArtSongs { get; } = new ObservableCollection<ObsCompilSong>();
        public ObservableCollection<ObsCompilSong> SelectedArtSongs { get; } = new ObservableCollection<ObsCompilSong>();

        public CompilArtistesDetailViewModel()
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
                var items = await _service.Compilation.Artistes.Artistes();
                var item = items.FirstOrDefault(x => x.Id == selectedImageID);
                SelectedCompilArtiste = new ObsCompilArtiste(item, _settingservice.APIURLEndpoint);
                var data = await _service.Compilation.Song.SongByArtiste(SelectedCompilArtiste.Id);
                foreach (var song in data)
                {
                    ArtSongs.Add(new ObsCompilSong(song, _settingservice.APIURLEndpoint));
                }
            }
            //else
            //{
            //    selectedImageID = ImagesNavigationHelper.GetImageId(CompilArtistesViewModel.CompilArtistesSelectedIdKey);
            //    if (!string.IsNullOrEmpty(selectedImageID))
            //    {
            //        SelectedImage = Source.FirstOrDefault(i => i.ID == selectedImageID);
            //    }
            //}
        }
    }
}
