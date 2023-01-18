using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using FPIMusicUWP.Core.ModelDTO;
using FPIMusicUWP.Services;
using FPIMusicUWP.Services.Settings;
using FPIMusicUWP.ViewModels.ObservableObj.Mediatheque;

namespace FPIMusicUWP.ViewModels
{
    public class HomeMediaViewModel : ObservableObject
    {
        private IService _service;
        private ISettingService _settingservice;

        private ObsMediaArtiste _firstMostSong;
        private ObsMediaArtiste _secondMostSong;
        private ObsMediaArtiste _thirdMostSong;
        private ObsMediaArtiste _firstMostAlbum;
        private ObsMediaArtiste _secondMostAlbum;
        private ObsMediaArtiste _thirdMostAlbum;
        public ObsMediaArtiste FirstMostSong
        {
            get => _firstMostSong;
            set
            {
                SetProperty(ref _firstMostSong, value);
            }
        }
        public ObsMediaArtiste SecondMostSong
        {
            get => _secondMostSong;
            set
            {
                SetProperty(ref _secondMostSong, value);
            }
        }
        public ObsMediaArtiste ThirdMostSong
        {
            get => _thirdMostSong;
            set
            {
                SetProperty(ref _thirdMostSong, value);
            }
        }
        public ObsMediaArtiste FirstMostAlbum
        {
            get => _firstMostAlbum;
            set
            {
                SetProperty(ref _firstMostAlbum, value);
            }
        }
        public ObsMediaArtiste SecondMostAlbum
        {
            get => _secondMostAlbum;
            set
            {
                SetProperty(ref _secondMostAlbum, value);
            }
        }
        public ObsMediaArtiste ThirdMostAlbum
        {
            get => _thirdMostAlbum;
            set
            {
                SetProperty(ref _thirdMostAlbum, value);
            }
        }
        public HomeMediaViewModel()
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
            var mostSongs = await _service.Mediatheque.Artistes.ArtisteWithMostSongs();
            if(mostSongs != null && mostSongs.Any())
            {
                FirstMostSong = new ObsMediaArtiste(mostSongs.ElementAtOrDefault(0), _settingservice.APIURLEndpoint);
                SecondMostSong = new ObsMediaArtiste(mostSongs.ElementAtOrDefault(1),_settingservice.APIURLEndpoint);
                ThirdMostSong = new ObsMediaArtiste(mostSongs.ElementAtOrDefault(2), _settingservice.APIURLEndpoint);
            }
        }

        private async Task InitializeMostAlbumArtisteAsync()
        {
            var mostAlb = await _service.Mediatheque.Artistes.ArtisteWithMostAlbums();
            if (mostAlb != null && mostAlb.Any())
            {
                FirstMostAlbum = new ObsMediaArtiste(mostAlb.ElementAtOrDefault(0), _settingservice.APIURLEndpoint);
                SecondMostAlbum = new ObsMediaArtiste(mostAlb.ElementAtOrDefault(1), _settingservice.APIURLEndpoint);
                ThirdMostAlbum = new ObsMediaArtiste(mostAlb.ElementAtOrDefault(2), _settingservice.APIURLEndpoint);
            }
        }
    }
}
