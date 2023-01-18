using FPIMusicUWP.Core;
using FPIMusicUWP.Core.ModelDTO;
using FPIMusicUWP.Services.Compilation.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Compilation.Implementation
{
    public class CompilSongService: ICompilSongService
    {
        private string apiURL;
        private CompilClient CompilConnector;

        public CompilSongService(string apiURL)
        {
            this.apiURL = apiURL;
            CompilConnector = new CompilClient(this.apiURL, new HttpClient());
        }
        public async Task<CompilationSong> Song(int id)
        {
            return await CompilConnector.SongAsync(id);
        }
        public async Task<IEnumerable<CompilationSong>> SongByArtiste(int id)
        {
            return await CompilConnector.SongByArtisteAsync(id);
        }
        public async Task<IEnumerable<CompilationSong>> SongByAlbum(int id)
        {
            return await CompilConnector.SongByAlbumAsync(id);
        }
    }
}
