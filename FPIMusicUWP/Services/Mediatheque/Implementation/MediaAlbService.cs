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
    public class MediaAlbService : IMediaAlbService
    {
        private string apiURL;
        private MediaClient MediaConnector;

        public MediaAlbService(string apiURL)
        {
            this.apiURL = apiURL;
            MediaConnector = new MediaClient(this.apiURL, new HttpClient());
        }
        public async Task<IEnumerable<GroupedMediaExtendedAlbum>> groupedAlbums()
        {
            return await MediaConnector.GroupedAlbumAsync();
        }
        public async Task<IEnumerable<MediaExtendedAlbum>> Albums()
        {
            return await MediaConnector.AlbumAllAsync();
        }
        public async Task<IEnumerable<MediaExtendedAlbum>> AlbumByArtiste(int id)
        {
            return await MediaConnector.MediaAsync(id);
        }
        public async Task<MediaExtendedAlbum> Album(int id)
        {
            return await MediaConnector.AlbumGETAsync(id);
        }
        public async Task<IEnumerable<MediaExtendedAlbum>> Album(string name)
        {
            return await MediaConnector.AlbumAllAsync(name);
        }
        public async Task Album(MediaExtendedAlbum item)
        {
            await MediaConnector.AlbumPUTAsync(item.Id, item);
        }
    }
}
