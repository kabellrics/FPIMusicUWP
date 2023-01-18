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
    public class CompilArtService: ICompilArtService
    {
        private string apiURL;
        private CompilClient CompilConnector;

        public CompilArtService(string apiURL)
        {
            this.apiURL = apiURL;
            CompilConnector = new CompilClient(this.apiURL, new HttpClient());
        }
        public async Task<IEnumerable<GroupedCompilExtendedArtiste>> groupedArtistes()
        {
            return await CompilConnector.GroupedArtisteAsync();
        }
        public async Task<IEnumerable<CompilExtendedArtiste>> Artistes()
        {
            return await CompilConnector.ArtisteAllAsync();
        }
        public async Task<IEnumerable<CompilExtendedArtiste>> ArtisteWithMostSongs()
        {
            return await CompilConnector.ArtisteMostSongAsync();
        }
        public async Task<IEnumerable<CompilExtendedArtiste>> ArtisteWithMostAlbums()
        {
            return await CompilConnector.ArtisteMostAlbumAsync();
        }
        public async Task<CompilExtendedArtiste> Artiste(int id)
        {
            return await CompilConnector.ArtisteGETAsync(id);
        }
        public async Task<IEnumerable<CompilExtendedArtiste>> Artiste(string name)
        {
            return await CompilConnector.ArtisteAllAsync(name);
        }
        public async Task Artiste(CompilExtendedArtiste item)
        {
            await CompilConnector.ArtistePUTAsync(item.Id, item);
        }
    }
}
