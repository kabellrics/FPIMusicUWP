using FPIMusicUWP.Core.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Compilation.Interface
{
    public interface ICompilAlbService
    {
        Task<IEnumerable<GroupedCompilExtendedAlbum>> groupedAlbums();
        Task<IEnumerable<CompilExtendedAlbum>> Albums();
        Task<CompilExtendedAlbum> Album(int id);
        Task<IEnumerable<CompilExtendedAlbum>> Album(string name);
        Task album(CompilExtendedAlbum item);
    }
}
