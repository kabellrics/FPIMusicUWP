using System;
using System.Threading.Tasks;
using FPIMusicUWP.Services;
using FPIMusicUWP.Services.Settings;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using FPIMusicUWP.ViewModels.ObservableObj.Mediatheque;
using FPIMusicUWP.ViewModels.ObservableObj.Deezer;
using System.Linq;

namespace FPIMusicUWP.ViewModels
{
    public class HomeDeezerViewModel : ObservableObject
    {
        private IService _service;
        private ISettingService _settingservice;

        private ObsDeezerArtiste _firstMostSong;
        private ObsDeezerArtiste _secondMostSong;
        private ObsDeezerArtiste _thirdMostSong;
        private ObsDeezerArtiste _firstMostAlbum;
        private ObsDeezerArtiste _secondMostAlbum;
        private ObsDeezerArtiste _thirdMostAlbum;
        private ObsDeezerArtiste _firstMostPlaylist;
        private ObsDeezerArtiste _secondMostPlaylist;
        private ObsDeezerArtiste _thirdMostPlaylist;

        public ObsDeezerArtiste FirstMostSong
        {
            get => _firstMostSong;
            set
            {
                SetProperty(ref _firstMostSong, value);
            }
        }
        public ObsDeezerArtiste SecondMostSong
        {
            get => _secondMostSong;
            set
            {
                SetProperty(ref _secondMostSong, value);
            }
        }
        public ObsDeezerArtiste ThirdMostSong
        {
            get => _thirdMostSong;
            set
            {
                SetProperty(ref _thirdMostSong, value);
            }
        }
        public ObsDeezerArtiste FirstMostAlbum
        {
            get => _firstMostAlbum;
            set
            {
                SetProperty(ref _firstMostAlbum, value);
            }
        }
        public ObsDeezerArtiste SecondMostAlbum
        {
            get => _secondMostAlbum;
            set
            {
                SetProperty(ref _secondMostAlbum, value);
            }
        }
        public ObsDeezerArtiste ThirdMostAlbum
        {
            get => _thirdMostAlbum;
            set
            {
                SetProperty(ref _thirdMostAlbum, value);
            }
        }
        public ObsDeezerArtiste FirstMostPlaylist
        {
            get => _firstMostPlaylist;
            set
            {
                SetProperty(ref _firstMostPlaylist, value);
            }
        }
        public ObsDeezerArtiste SecondMostPlaylist
        {
            get => _secondMostPlaylist;
            set
            {
                SetProperty(ref _secondMostPlaylist, value);
            }
        }
        public ObsDeezerArtiste ThirdMostPlaylist
        {
            get => _thirdMostPlaylist;
            set
            {
                SetProperty(ref _thirdMostPlaylist, value);
            }
        }
        public HomeDeezerViewModel()
        {
            _service = Ioc.Default.GetRequiredService<IService>();
            _settingservice = Ioc.Default.GetRequiredService<ISettingService>();
        }
        public async Task InitializeAsync()
        {
            await InitializeMostSongArtisteAsync();
            await InitializeMostAlbumArtisteAsync();
            await InitializeMostPlaylistArtisteAsync();
        }
        private async Task InitializeMostSongArtisteAsync()
        {
            var mostSongs = await _service.Deezer.Artistes.ArtisteWithMostSong();
            if (mostSongs != null && mostSongs.Any())
            {
                FirstMostSong = new ObsDeezerArtiste(mostSongs.ElementAtOrDefault(0), _settingservice.APIURLEndpoint);
                SecondMostSong = new ObsDeezerArtiste(mostSongs.ElementAtOrDefault(1), _settingservice.APIURLEndpoint);
                ThirdMostSong = new ObsDeezerArtiste(mostSongs.ElementAtOrDefault(2), _settingservice.APIURLEndpoint);
            }
        }

        private async Task InitializeMostAlbumArtisteAsync()
        {
            var mostAlb = await _service.Deezer.Artistes.ArtisteWithMostAlbum();
            if (mostAlb != null && mostAlb.Any())
            {
                FirstMostAlbum = new ObsDeezerArtiste(mostAlb.ElementAtOrDefault(0), _settingservice.APIURLEndpoint);
                SecondMostAlbum = new ObsDeezerArtiste(mostAlb.ElementAtOrDefault(1), _settingservice.APIURLEndpoint);
                ThirdMostAlbum = new ObsDeezerArtiste(mostAlb.ElementAtOrDefault(2), _settingservice.APIURLEndpoint);
            }
        }
        private async Task InitializeMostPlaylistArtisteAsync()
        {
            var mostPlaylist = await _service.Deezer.Artistes.ArtisteWithMostPlaylist();
            if (mostPlaylist != null && mostPlaylist.Any())
            {
                FirstMostPlaylist = new ObsDeezerArtiste(mostPlaylist.ElementAtOrDefault(0), _settingservice.APIURLEndpoint);
                SecondMostPlaylist = new ObsDeezerArtiste(mostPlaylist.ElementAtOrDefault(1), _settingservice.APIURLEndpoint);
                ThirdMostPlaylist = new ObsDeezerArtiste(mostPlaylist.ElementAtOrDefault(2), _settingservice.APIURLEndpoint);
            }
        }
    }
}
