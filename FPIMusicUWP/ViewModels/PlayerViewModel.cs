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
        private ObsSong _Song;
        public bool IsShuffle
        {
            get => _IsShuffle;
            set
            {
                SetProperty(ref _IsShuffle, value);
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

            InitSignalR();
        }

        private void InitSignalR()
        {
            connection = new HubConnectionBuilder()
                .WithUrl(new Uri($"{_settingservice.APIURLEndpoint}/synchro"))
                .WithAutomaticReconnect()
                .Build();
            SignalRMsgTraitement();
        }

        private async void SignalRMsgTraitement()
        {
            //connection.On("Synchro", (Func<string, Task>)(async (message) =>
            connection.On<string>("Synchro", async (message)=>
            {
                await GetStatus();
            });
            await connection.StartAsync();
        }

        private async Task GetStatus()
        {
            var status = await _playerservice.Status();
            if (status != null)
            {
                IsShuffle = status.IsShuffle;
                Pausing = status.Pausing;
                Playing = status.Playing;
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
                }
                PreviousSong.Clear();
                NextSong.Clear();
                foreach (var sg in status.SongAlreadyPlay)
                {
                    PreviousSong.Add(new ObsSong(sg, _settingservice.APIURLEndpoint));
                }
                foreach (var sg in status.SongToPlay)
                {
                    NextSong.Add(new ObsSong(sg, _settingservice.APIURLEndpoint));
                }
            }
        }

        public async Task LoadDataAsync()
        {
            await GetStatus();
        }
    }
}
