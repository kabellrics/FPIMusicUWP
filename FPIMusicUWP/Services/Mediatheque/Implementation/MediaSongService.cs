using FPIMusicUWP.Core;
using FPIMusicUWP.Core.ModelDTO;
using FPIMusicUWP.Services.Mediatheque.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace FPIMusicUWP.Services.Mediatheque.Implementation
{
    public class MediaSongService : IMediaSongService
    {
        private string apiURL;
        private MediaClient MediaConnector;

        public MediaSongService(string apiURL)
        {
            this.apiURL = apiURL;
            MediaConnector = new MediaClient(this.apiURL, new HttpClient());
        }
        public async Task<MediathequeSong> Song(int id)
        {
            return await MediaConnector.SongAsync(id);
        }
        public async Task<IEnumerable<MediathequeSong>> SongByAlbum(int id)
        {
            return await MediaConnector.SongByAlbumAsync(id);
        }
    }
}
