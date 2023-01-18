using FPIMusicUWP.Core;
using FPIMusicUWP.Core.ModelDTO;
using FPIMusicUWP.Services.Deezer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Deezer.Implementation
{
    public class DeezerAlbService : IDeezerAlbService
    {
        private string apiURL;
        private DeezerClient DeezerConnector;

        public DeezerAlbService(string apiURL)
        {
            this.apiURL = apiURL;
            DeezerConnector = new DeezerClient(this.apiURL, new HttpClient());
        }
        public async Task<IEnumerable<GroupedDeezerExtendedAlbum>> GroupedAlbums()
        {
            return await DeezerConnector.GroupedAlbumAsync();
        }
        public async Task<IEnumerable<DeezerExtendedAlbum>> Albums()
        {
            return await DeezerConnector.AlbumAllAsync();
        }
        public async Task<DeezerExtendedAlbum> Album(int id)
        {
            return await DeezerConnector.AlbumGETAsync(id);
        }
        public async Task<IEnumerable<DeezerExtendedAlbum>> Album(string name)
        {
            return await DeezerConnector.AlbumByNameAsync(name);
        }
        public async Task Album(DeezerExtendedAlbum item)
        {
            await DeezerConnector.AlbumPUTAsync(item.Id, item);
        }
    }
}
