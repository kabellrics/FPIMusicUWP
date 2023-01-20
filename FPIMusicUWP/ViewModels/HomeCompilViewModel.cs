using System;
using System.Threading.Tasks;
using FPIMusicUWP.Services;
using FPIMusicUWP.Services.Settings;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using FPIMusicUWP.ViewModels.ObservableObj.Deezer;
using FPIMusicUWP.ViewModels.ObservableObj.Compilation;
using System.Linq;

namespace FPIMusicUWP.ViewModels
{
    public class HomeCompilViewModel : ObservableObject
    {
        private IService _service;
        private ISettingService _settingservice;

        private ObsCompilArtiste _firstMostSong;
        private ObsCompilArtiste _secondMostSong;
        private ObsCompilArtiste _thirdMostSong;
        private ObsCompilArtiste _firstMostAlbum;
        private ObsCompilArtiste _secondMostAlbum;
        private ObsCompilArtiste _thirdMostAlbum;

        public ObsCompilArtiste FirstMostSong
        {
            get => _firstMostSong;
            set
            {
                SetProperty(ref _firstMostSong, value);
            }
        }
        public ObsCompilArtiste SecondMostSong
        {
            get => _secondMostSong;
            set
            {
                SetProperty(ref _secondMostSong, value);
            }
        }
        public ObsCompilArtiste ThirdMostSong
        {
            get => _thirdMostSong;
            set
            {
                SetProperty(ref _thirdMostSong, value);
            }
        }
        public ObsCompilArtiste FirstMostAlbum
        {
            get => _firstMostAlbum;
            set
            {
                SetProperty(ref _firstMostAlbum, value);
            }
        }
        public ObsCompilArtiste SecondMostAlbum
        {
            get => _secondMostAlbum;
            set
            {
                SetProperty(ref _secondMostAlbum, value);
            }
        }
        public ObsCompilArtiste ThirdMostAlbum
        {
            get => _thirdMostAlbum;
            set
            {
                SetProperty(ref _thirdMostAlbum, value);
            }
        }
        public HomeCompilViewModel()
        {
            _service = Ioc.Default.GetRequiredService<IService>();
            _settingservice = Ioc.Default.GetRequiredService<ISettingService>();
        }
        public async Task InitializeAsync()
        {
            await InitializeMostSongArtisteAsync();
            await InitializeMostAlbumArtisteAsync();
        }
        private async Task InitializeMostSongArtisteAsync()
        {
            var mostSongs = await _service.Compilation.Artistes.ArtisteWithMostSongs();
            if (mostSongs != null && mostSongs.Any())
            {
                FirstMostSong = new ObsCompilArtiste(mostSongs.ElementAtOrDefault(0), _settingservice.APIURLEndpoint);
                SecondMostSong = new ObsCompilArtiste(mostSongs.ElementAtOrDefault(1), _settingservice.APIURLEndpoint);
                ThirdMostSong = new ObsCompilArtiste(mostSongs.ElementAtOrDefault(2), _settingservice.APIURLEndpoint);
            }
        }

        private async Task InitializeMostAlbumArtisteAsync()
        {
            var mostAlb = await _service.Compilation.Artistes.ArtisteWithMostAlbums();
            if (mostAlb != null && mostAlb.Any())
            {
                FirstMostAlbum = new ObsCompilArtiste(mostAlb.ElementAtOrDefault(0), _settingservice.APIURLEndpoint);
                SecondMostAlbum = new ObsCompilArtiste(mostAlb.ElementAtOrDefault(1), _settingservice.APIURLEndpoint);
                ThirdMostAlbum = new ObsCompilArtiste(mostAlb.ElementAtOrDefault(2), _settingservice.APIURLEndpoint);
            }
        }
    }
}
