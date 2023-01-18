using FPIMusicUWP.Core;
using FPIMusicUWP.Core.ModelDTO;
using FPIMusicUWP.Services.Deezer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace FPIMusicUWP.Services.Deezer.Implementation
{
    public class DeezerPlaylistService : IDeezerPlaylistService
    {
        private string apiURL;
        private DeezerClient DeezerConnector;

        public DeezerPlaylistService(string apiURL)
        {
            this.apiURL = apiURL;
            DeezerConnector = new DeezerClient(this.apiURL, new HttpClient());
        }
        public async Task<IEnumerable<GroupedDeezerExtendedPlaylist>> GroupedPlaylists()
        {
            return await DeezerConnector.GroupedPlaylistAsync();
        }
        public async Task<IEnumerable<DeezerExtendedPlaylist>> Playlists()
        {
            return await DeezerConnector.PlaylistAllAsync();
        }
        public async Task<DeezerExtendedPlaylist> Playlist(int id)
        {
            return await DeezerConnector.PlaylistGETAsync(id);
        }
        public async Task<IEnumerable<DeezerExtendedPlaylist>> Playlist(string name)
        {
            return await DeezerConnector.PlaylistByNameAsync(name);
        }
        public async Task Playlist(DeezerExtendedPlaylist item)
        {
            await DeezerConnector.PlaylistPUTAsync(item.Id, item);
        }
    }
}
