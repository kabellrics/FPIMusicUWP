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
using FPIMusicUWP.ViewModels.ObservableObj;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using FPIMusicUWP.Core.Extension;
using FPIMusicUWP.Services.Player;

namespace FPIMusicUWP.ViewModels
{
    public class DeezerPlaylistDetailViewModel : ObservableObject
    {
        private ObsDeezerPlaylist _selectedDeezerPlaylist;
        private IService _service;
        private ISettingService _settingservice;
        private IPlayerService _playerService;
        private ICommand _SelectAllCommand;
        private ICommand _PlayCommand;
        private ICommand _PrioritizeCommand;
        private ICommand _AddToPlayCommand;
        public ICommand PlayCommand => _PlayCommand ?? (_PlayCommand = new RelayCommand(Play));
        public ICommand PrioritizeCommand => _PrioritizeCommand ?? (_PrioritizeCommand = new RelayCommand(Prioritize));
        public ICommand AddToPlayCommand => _AddToPlayCommand ?? (_AddToPlayCommand = new RelayCommand(AddToPlay));
        public ICommand SelectAllCommand => _SelectAllCommand ?? (_SelectAllCommand = new RelayCommand(OnSelectAll));

        private void OnSelectAll()
        {
            Songs.ForEach(x => x.Selected = !x.Selected);
        }
        private void Play()
        {
            var songtoplay = Songs.Where(x => x.Selected).ToList();
            var firstsong = songtoplay.FirstOrDefault();
            songtoplay.RemoveAt(0);
            _playerService.PlaySongAsync(firstsong.Id, (int)firstsong.Song.SongType);
            foreach (var song in songtoplay)
            {
                _playerService.AddSongAsync(song.Id, (int)song.Song.SongType);
            }
            Songs.ForEach(x => x.Selected = false);
        }
        private void Prioritize()
        {
            var songtoplay = Songs.Where(x => x.Selected).Reverse().ToList();
            Songs.ForEach(x => x.Selected = false);
            foreach (var song in songtoplay)
            {
                _playerService.AddPrioritizeSongAsync(song.Id, (int)song.Song.SongType);
            }
            Songs.ForEach(x => x.Selected = false);
        }
        private void AddToPlay()
        {
            var songtoplay = Songs.Where(x => x.Selected).ToList();
            Songs.ForEach(x => x.Selected = false);
            foreach (var song in songtoplay)
            {
                _playerService.AddSongAsync(song.Id, (int)song.Song.SongType);
            }
            Songs.ForEach(x => x.Selected = false);
        }

        public ObsDeezerPlaylist SelectedDeezerPlaylist
        {
            get => _selectedDeezerPlaylist;
            set
            {
                SetProperty(ref _selectedDeezerPlaylist, value);
                ImagesNavigationHelper.UpdateImageId(DeezerPlaylistViewModel.DeezerPlaylistSelectedIdKey, ((ObsDeezerPlaylist)SelectedDeezerPlaylist)?.Id.ToString());
            }
        }

        public ObservableCollection<ObsSong> Songs { get; } = new ObservableCollection<ObsSong>();

        public DeezerPlaylistDetailViewModel()
        {
            _service = Ioc.Default.GetRequiredService<IService>();
            _settingservice = Ioc.Default.GetRequiredService<ISettingService>();
            _playerService = Ioc.Default.GetRequiredService<IPlayerService>();
        }

        public async Task LoadDataAsync()
        {
            Songs.Clear();

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
                var data = await _service.Deezer.Songs.SongByPlaylist(SelectedDeezerPlaylist.Id);
                foreach (var song in data)
                {
                    Songs.Add(new ObsSong(song, _settingservice.APIURLEndpoint));
                }
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
