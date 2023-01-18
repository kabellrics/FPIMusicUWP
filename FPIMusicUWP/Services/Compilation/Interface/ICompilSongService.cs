using FPIMusicUWP.Core.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Compilation.Interface
{
    public interface ICompilSongService
    {
        Task<CompilationSong> Song(int id);
        Task<IEnumerable<CompilationSong>> SongByArtiste(int id);
        Task<IEnumerable<CompilationSong>> SongByAlbum(int id);
    }
}
