using System;
using System.Threading.Tasks;
using FPIMusicUWP.Services;
using FPIMusicUWP.Services.Settings;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using FPIMusicUWP.ViewModels.ObservableObj.Mediatheque;
using FPIMusicUWP.ViewModels.ObservableObj.Deezer;
using System.Linq;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using FPIMusicUWP.Views;

namespace FPIMusicUWP.ViewModels
{
    public class HomeDeezerViewModel : ObservableObject
    {
        private IService _service;
        private ISettingService _settingservice;
        private ICommand _SelectedFirstMostSongCommand;
        private ICommand _SelectedSecondMostSongCommand;
        private ICommand _SelectedThirdMostSongCommand;
        private ICommand _SelectedFirstMostAlbumCommand;
        private ICommand _SelectedSecondMostAlbumCommand;
        private ICommand _SelectedThirdMostAlbumCommand;
        private ICommand _SelectedFirstMostPlaylistCommand;
        private ICommand _SelectedSecondMostPlaylistCommand;
        private ICommand _SelectedThirdMostPlaylistCommand;

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
        public ICommand ItemSelectedFirstSongCommand => _SelectedFirstMostSongCommand ?? (_SelectedFirstMostSongCommand = new RelayCommand(SelectedFirstMostSong));
        public ICommand ItemSelectedSecondSongCommand => _SelectedSecondMostSongCommand ?? (_SelectedSecondMostSongCommand = new RelayCommand(SelectedSecondMostSong));
        public ICommand ItemSelectedThirdSongCommand => _SelectedThirdMostSongCommand ?? (_SelectedThirdMostSongCommand = new RelayCommand(SelectedThirdMostSong));
        public ICommand ItemSelectedFirstAlbumCommand => _SelectedFirstMostAlbumCommand ?? (_SelectedFirstMostAlbumCommand = new RelayCommand(SelectedFirstMostAlbum));
        public ICommand ItemSelectedSecondAlbumCommand => _SelectedSecondMostAlbumCommand ?? (_SelectedSecondMostAlbumCommand = new RelayCommand(SelectedSecondMostAlbum));
        public ICommand ItemSelectedThirdAlbumCommand => _SelectedThirdMostAlbumCommand ?? (_SelectedThirdMostAlbumCommand = new RelayCommand(SelectedThirdMostAlbum));
        public ICommand ItemSelectedFirstPlaylistCommand => _SelectedFirstMostPlaylistCommand ?? (_SelectedFirstMostPlaylistCommand = new RelayCommand(SelectedFirstMostPlaylist));
        public ICommand ItemSelectedSecondPlaylistCommand => _SelectedSecondMostPlaylistCommand ?? (_SelectedSecondMostPlaylistCommand = new RelayCommand(SelectedSecondMostPlaylist));
        public ICommand ItemSelectedThirdPlaylistCommand => _SelectedThirdMostPlaylistCommand ?? (_SelectedThirdMostPlaylistCommand = new RelayCommand(SelectedThirdMostPlaylist));
        public HomeDeezerViewModel()
        {
            _service = Ioc.Default.GetRequiredService<IService>();
            _settingservice = Ioc.Default.GetRequiredService<ISettingService>();
        }
        private void SelectedFirstMostSong()
        {
            NavigationService.Navigate<DeezerArtistesDetailPage>(FirstMostSong.Id);
        }
        private void SelectedSecondMostSong()
        {
            NavigationService.Navigate<DeezerArtistesDetailPage>(SecondMostSong.Id);
        }
        private void SelectedThirdMostSong()
        {
            NavigationService.Navigate<DeezerArtistesDetailPage>(ThirdMostSong.Id);
        }
        private void SelectedFirstMostAlbum()
        {
            NavigationService.Navigate<DeezerArtistesDetailPage>(FirstMostAlbum.Id);
        }
        private void SelectedSecondMostAlbum()
        {
            NavigationService.Navigate<DeezerArtistesDetailPage>(SecondMostAlbum.Id);
        }
        private void SelectedThirdMostAlbum()
        {
            NavigationService.Navigate<DeezerArtistesDetailPage>(ThirdMostAlbum.Id);
        }
        private void SelectedFirstMostPlaylist()
        {
            NavigationService.Navigate<DeezerArtistesDetailPage>(FirstMostPlaylist.Id);
        }
        private void SelectedSecondMostPlaylist()
        {
            NavigationService.Navigate<DeezerArtistesDetailPage>(SecondMostPlaylist.Id);
        }
        private void SelectedThirdMostPlaylist()
        {
            NavigationService.Navigate<DeezerArtistesDetailPage>(ThirdMostPlaylist.Id);
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
