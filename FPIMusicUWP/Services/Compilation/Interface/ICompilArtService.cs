using FPIMusicUWP.Core.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Compilation.Interface
{
    public interface ICompilArtService
    {
        Task<IEnumerable<GroupedCompilExtendedArtiste>> groupedArtistes();
        Task<IEnumerable<CompilExtendedArtiste>> Artistes();
        Task<IEnumerable<CompilExtendedArtiste>> ArtisteWithMostSongs();
        Task<IEnumerable<CompilExtendedArtiste>> ArtisteWithMostAlbums();
        Task<CompilExtendedArtiste> Artiste(int id);
        Task<IEnumerable<CompilExtendedArtiste>> Artiste(string name);
        Task Artiste(CompilExtendedArtiste item);
    }
}
