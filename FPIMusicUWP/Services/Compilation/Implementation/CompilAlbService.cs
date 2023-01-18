using FPIMusicUWP.Core;
using FPIMusicUWP.Core.ModelDTO;
using FPIMusicUWP.Services.Compilation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Compilation.Implementation
{
    public class CompilAlbService: ICompilAlbService
    {
        private string apiURL;
        private CompilClient CompilConnector;
        public CompilAlbService(string apiURL)
        {
            this.apiURL = apiURL;
            CompilConnector = new CompilClient(this.apiURL, new HttpClient());
        }
        public async Task<IEnumerable<GroupedCompilExtendedAlbum>> groupedAlbums()
        {
            return await CompilConnector.GroupedAlbumAsync();
        }
        public async Task<IEnumerable<CompilExtendedAlbum>> Albums()
        {
            return await CompilConnector.AlbumAllAsync();
        }
        public async Task<CompilExtendedAlbum> Album(int id)
        {
            return await CompilConnector.AlbumGETAsync(id);
        }
        public async Task<IEnumerable<CompilExtendedAlbum>> Album(string name)
        {
            return await CompilConnector.AlbumAllAsync(name);
        }
        public async Task album(CompilExtendedAlbum item)
        {
            await CompilConnector.AlbumPUTAsync(item.Id, item);
        }
    }
}
