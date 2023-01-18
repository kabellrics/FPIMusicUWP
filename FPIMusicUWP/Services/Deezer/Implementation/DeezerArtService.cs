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
    public class DeezerArtService : IDeezerArtService
    {
        private string apiURL;
        private DeezerClient DeezerConnector;

        public DeezerArtService(string apiURL)
        {
            this.apiURL = apiURL;
            DeezerConnector = new DeezerClient(this.apiURL, new HttpClient());
        }
        public async Task<IEnumerable<GroupedDeezerExtendedArtiste>> GroupedArtistes()
        {
            return await DeezerConnector.GroupedArtisteAsync();
        }
        public async Task<IEnumerable<DeezerExtendedArtiste>> Artistes()
        {
            return await DeezerConnector.ArtisteAllAsync();
        }
        public async Task<IEnumerable<DeezerExtendedArtiste>> ArtisteWithMostPlaylist()
        {
            return await DeezerConnector.ArtisteMostPlaylistAsync();
        }
        public async Task<IEnumerable<DeezerExtendedArtiste>> ArtisteWithMostSong()
        {
            return await DeezerConnector.ArtisteMostSongAsync();
        }
        public async Task<IEnumerable<DeezerExtendedArtiste>> ArtisteWithMostAlbum()
        {
            return await DeezerConnector.ArtisteMostAlbumAsync();
        }
        public async Task<DeezerExtendedArtiste> Artiste(int id)
        {
            return await DeezerConnector.ArtisteGETAsync(id);
        }
        public async Task<IEnumerable<DeezerExtendedArtiste>> Artiste(string name)
        {
            return await DeezerConnector.ArtisteByNameAsync(name);
        }
        public async Task Artiste(DeezerExtendedArtiste item)
        {
            await DeezerConnector.ArtistePUTAsync(item.Id, item);
        }
    }
}
