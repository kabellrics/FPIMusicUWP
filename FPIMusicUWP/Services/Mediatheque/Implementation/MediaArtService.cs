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
    public class MediaArtService : IMediaArtService
    {
        private string apiURL;
        private MediaClient MediaConnector;

        public MediaArtService(string apiURL)
        {
            this.apiURL = apiURL;
            MediaConnector = new MediaClient(this.apiURL, new HttpClient());
        }
        public async Task<IEnumerable<GroupedMediaExtendedArtiste>> groupedArtistes()
        {
            return await MediaConnector.GroupedArtisteAsync();
        }
        public async Task<IEnumerable<MediaExtendedArtiste>> Artistes()
        {
            return await MediaConnector.ArtisteAllAsync();
        }
        public async Task<IEnumerable<MediaExtendedArtiste>> ArtisteWithMostSongs()
        {
            return await MediaConnector.ArtisteMostSongAsync();
        }
        public async Task<IEnumerable<MediaExtendedArtiste>> ArtisteWithMostAlbums()
        {
            return await MediaConnector.ArtisteMostAlbumAsync();
        }
        public async Task<MediaExtendedArtiste> Artiste(int id)
        {
            return await MediaConnector.ArtisteGETAsync(id);
        }
        public async Task<IEnumerable<MediaExtendedArtiste>> Artiste(string name)
        {
            return await MediaConnector.ArtisteAllAsync(name);
        }
        public async Task Artiste(MediaExtendedArtiste item)
        {
            await MediaConnector.ArtistePUTAsync(item.Id, item);
        }
    }
}
