using System;
using System.Threading.Tasks;
using FPIMusicUWP.Services;
using FPIMusicUWP.Services.Settings;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using FPIMusicUWP.ViewModels.ObservableObj.Deezer;
using FPIMusicUWP.ViewModels.ObservableObj.Compilation;
using System.Linq;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using FPIMusicUWP.Views;

namespace FPIMusicUWP.ViewModels
{
    public class HomeCompilViewModel : ObservableObject
    {
        private IService _service;
        private ISettingService _settingservice;
        private ICommand _SelectedFirstMostSongCommand;
        private ICommand _SelectedSecondMostSongCommand;
        private ICommand _SelectedThirdMostSongCommand;
        private ICommand _SelectedFirstMostAlbumCommand;
        private ICommand _SelectedSecondMostAlbumCommand;
        private ICommand _SelectedThirdMostAlbumCommand;

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
        public ICommand ItemSelectedFirstSongCommand => _SelectedFirstMostSongCommand ?? (_SelectedFirstMostSongCommand = new RelayCommand(SelectedFirstMostSong));
        public ICommand ItemSelectedSecondSongCommand => _SelectedSecondMostSongCommand ?? (_SelectedSecondMostSongCommand = new RelayCommand(SelectedSecondMostSong));
        public ICommand ItemSelectedThirdSongCommand => _SelectedThirdMostSongCommand ?? (_SelectedThirdMostSongCommand = new RelayCommand(SelectedThirdMostSong));
        public ICommand ItemSelectedFirstAlbumCommand => _SelectedFirstMostAlbumCommand ?? (_SelectedFirstMostAlbumCommand = new RelayCommand(SelectedFirstMostAlbum));
        public ICommand ItemSelectedSecondAlbumCommand => _SelectedSecondMostAlbumCommand ?? (_SelectedSecondMostAlbumCommand = new RelayCommand(SelectedSecondMostAlbum));
        public ICommand ItemSelectedThirdAlbumCommand => _SelectedThirdMostAlbumCommand ?? (_SelectedThirdMostAlbumCommand = new RelayCommand(SelectedThirdMostAlbum));
        public HomeCompilViewModel()
        {
            _service = Ioc.Default.GetRequiredService<IService>();
            _settingservice = Ioc.Default.GetRequiredService<ISettingService>();
        }
        private void SelectedFirstMostSong()
        {
            NavigationService.Navigate<CompilArtistesDetailPage>(FirstMostSong.Id);
        }
        private void SelectedSecondMostSong()
        {
            NavigationService.Navigate<CompilArtistesDetailPage>(SecondMostSong.Id);
        }
        private void SelectedThirdMostSong()
        {
            NavigationService.Navigate<CompilArtistesDetailPage>(ThirdMostSong.Id);
        }
        private void SelectedFirstMostAlbum()
        {
            NavigationService.Navigate<CompilArtistesDetailPage>(FirstMostAlbum.Id);
        }
        private void SelectedSecondMostAlbum()
        {
            NavigationService.Navigate<CompilArtistesDetailPage>(SecondMostAlbum.Id);
        }
        private void SelectedThirdMostAlbum()
        {
            NavigationService.Navigate<CompilArtistesDetailPage>(ThirdMostAlbum.Id);
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
