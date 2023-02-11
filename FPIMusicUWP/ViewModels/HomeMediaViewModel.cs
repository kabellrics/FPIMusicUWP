using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using FPIMusicUWP.Core.ModelDTO;
using FPIMusicUWP.Services;
using FPIMusicUWP.Services.Settings;
using FPIMusicUWP.ViewModels.ObservableObj.Compilation;
using FPIMusicUWP.ViewModels.ObservableObj.Mediatheque;
using FPIMusicUWP.Views;
using Microsoft.Toolkit.Uwp.UI.Animations;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace FPIMusicUWP.ViewModels
{
    public class HomeMediaViewModel : ObservableObject
    {
        private IService _service;
        private ISettingService _settingservice;
        private ICommand _SelectedFirstMostSongCommand;
        private ICommand _SelectedSecondMostSongCommand;
        private ICommand _SelectedThirdMostSongCommand;
        private ICommand _SelectedFirstMostAlbumCommand;
        private ICommand _SelectedSecondMostAlbumCommand;
        private ICommand _SelectedThirdMostAlbumCommand;

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
        public ICommand ItemSelectedFirstSongCommand => _SelectedFirstMostSongCommand ?? (_SelectedFirstMostSongCommand = new RelayCommand(SelectedFirstMostSong));
        public ICommand ItemSelectedSecondSongCommand => _SelectedSecondMostSongCommand ?? (_SelectedSecondMostSongCommand = new RelayCommand(SelectedSecondMostSong));
        public ICommand ItemSelectedThirdSongCommand => _SelectedThirdMostSongCommand ?? (_SelectedThirdMostSongCommand = new RelayCommand(SelectedThirdMostSong));
        public ICommand ItemSelectedFirstAlbumCommand => _SelectedFirstMostAlbumCommand ?? (_SelectedFirstMostAlbumCommand = new RelayCommand(SelectedFirstMostAlbum));
        public ICommand ItemSelectedSecondAlbumCommand => _SelectedSecondMostAlbumCommand ?? (_SelectedSecondMostAlbumCommand = new RelayCommand(SelectedSecondMostAlbum));
        public ICommand ItemSelectedThirdAlbumCommand => _SelectedThirdMostAlbumCommand ?? (_SelectedThirdMostAlbumCommand = new RelayCommand(SelectedThirdMostAlbum));
        public HomeMediaViewModel()
        {
            _service = Ioc.Default.GetRequiredService<IService>();
            _settingservice = Ioc.Default.GetRequiredService<ISettingService>();
        }
        private void SelectedFirstMostSong()
        {
            NavigationService.Navigate<MediaArtistesDetailPage>(FirstMostSong.Id);
        }
        private void SelectedSecondMostSong()
        {
            NavigationService.Navigate<MediaArtistesDetailPage>(SecondMostSong.Id);
        }
        private void SelectedThirdMostSong()
        {
            NavigationService.Navigate<MediaArtistesDetailPage>(ThirdMostSong.Id);
        }
        private void SelectedFirstMostAlbum()
        {
            NavigationService.Navigate<MediaArtistesDetailPage>(FirstMostAlbum.Id);
        }
        private void SelectedSecondMostAlbum()
        {
            NavigationService.Navigate<MediaArtistesDetailPage>(SecondMostAlbum.Id);
        }
        private void SelectedThirdMostAlbum()
        {
            NavigationService.Navigate<MediaArtistesDetailPage>(ThirdMostAlbum.Id);
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
