using System;

using CommunityToolkit.Mvvm.ComponentModel;
using FPIMusicUWP.Services.Settings;
using FPIMusicUWP.Services;
using FPIMusicUWP.ViewModels.ObservableObj.Compilation;
using FPIMusicUWP.Helpers;
using FPIMusicUWP.ViewModels.ObservableObj;
using FPIMusicUWP.ViewModels.ObservableObj.Deezer;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.AspNetCore.SignalR.Client;
using FPIMusicUWP.Services.Player;
using System.Threading.Tasks;
using FPIMusicUWP.Core.ModelDTO;
using FPIMusicUWP.Core.Model;
using CommunityToolkit.Mvvm.Messaging;
using Windows.UI.Core;
using System.Timers;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace FPIMusicUWP.ViewModels
{
    public class PlayerViewModel : ObservableObject
    {
        private ISettingService _settingservice;
        private IPlayerService _playerservice;
        private IService _service;
        private HubConnection connection;
        private bool _Playing;
        private bool _Pausing;
        private bool _IsShuffle;
        private bool _IsLoop;
        private int _defilement;
        private int _volume;
        private string _artisteAlbumLabel;
        private ObsSong _Song;
        public bool IsShuffle
        {
            get => _IsShuffle;
            set
            {
                SetProperty(ref _IsShuffle, value);
            }
        }
        public bool IsLoop
        {
            get => _IsLoop;
            set
            {
                SetProperty(ref _IsLoop, value);
            }
        }
        public bool Pausing
        {
            get => _Pausing;
            set
            {
                SetProperty(ref _Pausing, value);
            }
        }
        public bool Playing
        {
            get => _Playing;
            set
            {
                SetProperty(ref _Playing, value);
            }
        }
        public int Volume
        {
            get => _volume;
            set
            {
                if(value != _volume)
                {
                    SetProperty(ref _volume, value);
                    VolumeChanged();
                }
            }
        }
        public string ArtisteAlbumLabel
        {
            get => _artisteAlbumLabel;
            set
            {
                SetProperty(ref _artisteAlbumLabel, value);
                if (value.Length > 50)
                {
                    _defilement = 0;
                    SetDefilement();
                }
            }
        }

        private ICommand _PlayPauseCommand;
        private ICommand _StopCommand;
        private ICommand _NextCommand;
        private ICommand _PreviousCommand;
        private ICommand _VolumeCommand;
        private ICommand _VolumeUpCommand;
        private ICommand _VolumeDownCommand;
        private ICommand _LoopCommand;
        private ICommand _ShuffleCommand;
        public ICommand PlayPauseCommand => _PlayPauseCommand ?? (_PlayPauseCommand = new RelayCommand(PlayPauseChanged));
        public ICommand StopCommand => _StopCommand ?? (_StopCommand = new RelayCommand(StopChanged));
        public ICommand NextCommand => _NextCommand ?? (_NextCommand = new RelayCommand(NextChanged));
        public ICommand PreviousCommand => _PreviousCommand ?? (_PreviousCommand = new RelayCommand(PreviousChanged));
        public ICommand VolumeCommand => _VolumeCommand ?? (_VolumeCommand = new RelayCommand(VolumeChanged));
        public ICommand VolumeUpCommand => _VolumeUpCommand ?? (_VolumeUpCommand = new RelayCommand(VolumeUpChanged));
        public ICommand VolumeDownCommand => _VolumeDownCommand ?? (_VolumeDownCommand = new RelayCommand(VolumeDownChanged));

        private void VolumeChanged()
        {
            _playerservice.Volume(Volume);
        }
        private void VolumeUpChanged()
        {
            if(Volume <100)
            Volume+=5;
        }
        private void VolumeDownChanged()
        {
            if(Volume>0)
            Volume-=5;
        }
        private void PreviousChanged()
        {
            _playerservice.Previous();
        }
        private void NextChanged()
        {
            _playerservice.Next();
        }
        private void StopChanged()
        {
            _playerservice.Stop();
        }
        private async void PlayPauseChanged()
        {
            var status = await _playerservice.Status();
            if(status.Playing)
                _playerservice.Pause();
            else
                _playerservice.Play();
        }

        public ObsSong Song
        {
            get => _Song;
            set
            {
                SetProperty(ref _Song, value);
            }
        }
        public ObservableCollection<ObsSong> PreviousSong { get; } = new ObservableCollection<ObsSong>();
        public ObservableCollection<ObsSong> NextSong { get; } = new ObservableCollection<ObsSong>();
        public PlayerViewModel()
        {
            _service = Ioc.Default.GetRequiredService<IService>();
            _settingservice = Ioc.Default.GetRequiredService<ISettingService>();
            _playerservice = Ioc.Default.GetRequiredService<IPlayerService>();
            SignalRMsgTraitement();
        }

        private async void SignalRMsgTraitement()
        {
            WeakReferenceMessenger.Default.Register<PlayerInfoChangedMessage>(this, (r, m) =>
            {
               //Windows.UI.Core.CoreWindow.GetForCurrentThread().Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
               //     () =>
               //     {
               //         GetStatus();
               //     });
                Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () =>
                {
                    GetStatus();
                });
            });
        }
        private async void GetStatus() { await GetStatusAsync(); }
        private async Task GetStatusAsync()
        {
            var status = await _playerservice.Status();
            if (status != null)
            {
                IsShuffle = status.IsShuffle;
                Pausing = status.Pausing;
                Playing = status.Playing;
                Volume = status.Volume;
                if (status.CurrentSong != null)
                {
                    var currentsg = new Song();
                    if (status.CurrentSong.SongType == SongType._0)
                        currentsg = await _service.Mediatheque.Song.Song(status.CurrentSong.Id);
                    else if (status.CurrentSong.SongType == SongType._1)
                        currentsg = await _service.Compilation.Song.Song(status.CurrentSong.Id);
                    else if (status.CurrentSong.SongType == SongType._2)
                        currentsg = await _service.Deezer.Songs.Song(status.CurrentSong.Id);
                    Song = new ObsSong(currentsg, _settingservice.APIURLEndpoint);
                    ArtisteAlbumLabel = $"{Song.Artiste} - {Song.Album}";
                }
                PreviousSong.Clear();
                NextSong.Clear();
                foreach (var sg in status.SongAlreadyPlay)
                {
                    if (sg != null)
                    {
                        PreviousSong.Add(new ObsSong(sg, _settingservice.APIURLEndpoint));
                    }
                }
                foreach (var sg in status.SongToPlay)
                {
                    if (sg != null)
                    {
                        NextSong.Add(new ObsSong(sg, _settingservice.APIURLEndpoint)); 
                    }
                }
            }
        }

        private void SetDefilement()
        {
            Timer timer = new Timer();
            timer.Interval = 175;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () =>
                {
                    if (_defilement == Song.Artiste.Length + Song.Album.Length)
                        _defilement = 0;
                    if(_defilement < (Song.Artiste.Length + Song.Album.Length)-40)
                    ArtisteAlbumLabel = $"{Song.Artiste} - {Song.Album}".Substring(_defilement++, 40);
                    else
                        ArtisteAlbumLabel = $"{Song.Artiste} - {Song.Album}".Substring(_defilement++);
                });
        }

        public async Task LoadDataAsync()
        {
            GetStatus();
        }
    }
}
