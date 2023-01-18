using FPIMusicUWP.Core.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Deezer.Interface
{
    public interface IDeezerAlbService
    {
        Task<IEnumerable<GroupedDeezerExtendedAlbum>> GroupedAlbums();
        Task<IEnumerable<DeezerExtendedAlbum>> Albums();
        Task<DeezerExtendedAlbum> Album(int id);
        Task<IEnumerable<DeezerExtendedAlbum>> Album(string name);
        Task Album(DeezerExtendedAlbum item);
    }
}
