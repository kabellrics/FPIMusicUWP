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
    public class DeezerSongService : IDeezerSongService
    {
        private string apiURL;
        private DeezerClient DeezerConnector;

        public DeezerSongService(string apiURL)
        {
            this.apiURL = apiURL;
            DeezerConnector = new DeezerClient(this.apiURL, new HttpClient());
        }
        public async Task<DeezerSong> Song(int id)
        {
            return await DeezerConnector.SongAsync(id);
        }
        public async Task<IEnumerable<DeezerSong>> SongByArtiste(int id)
        {
            return await DeezerConnector.SongByArtisteAsync(id);
        }
        public async Task<IEnumerable<DeezerSong>> SongByAlbum(int id)
        {
            return await DeezerConnector.SongByAlbumAsync(id);
        }
        public async Task<IEnumerable<DeezerSong>> SongByPlaylist(int id)
        {
            return await DeezerConnector.SongByPlaylistAsync(id);
        }
    }
}
