using CommunityToolkit.Mvvm.DependencyInjection;
using FPIMusicUWP.Core;
using FPIMusicUWP.Core.Model;
using FPIMusicUWP.Services.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Player
{
    public class PlayerService : IPlayerService
    {
        private readonly ISettingService _settingService;
        private PlayerClient PlayerConnector;

        public PlayerService()
        {
            _settingService = Ioc.Default.GetRequiredService<ISettingService>();
            PlayerConnector = new PlayerClient(_settingService.APIURLEndpoint, new HttpClient());
        }
        public async Task AddPrioritizeSongAsync(int id, int songType)
        {
            await PlayerConnector.AddPrioritizeSongAsync(id, songType);
        }
        public async Task AddSongAsync(int id, int songType)
        {
            await PlayerConnector.AddSongAsync(id, songType);
        }
        public async Task PlaySongAsync(int id, int songType)
        {
            await PlayerConnector.PlaySongAsync(id, songType);
        }
        public async Task Next() { await PlayerConnector.NextAsync(); }
        public async Task Previous() { await PlayerConnector.PreviousAsync(); }
        public async Task Stop() { await PlayerConnector.StopAsync(); }
        public async Task Pause() { await PlayerConnector.PauseAsync(); }
        public async Task Play() { await PlayerConnector.PlayAsync(); }
        public async Task Volume(int volume) { await PlayerConnector.VolumeAsync(volume); }
        public async Task<PlayerListStatus> Status() { return await PlayerConnector.StatusAsync(); }
    }
}
