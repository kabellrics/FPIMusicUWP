using FPIMusicUWP.Core.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Mediatheque.Interface
{
    public interface IMediaAlbService
    {
        Task<IEnumerable<GroupedMediaExtendedAlbum>> groupedAlbums();
        Task<IEnumerable<MediaExtendedAlbum>> Albums();
        Task<IEnumerable<MediaExtendedAlbum>> AlbumByArtiste(int id);
        Task<MediaExtendedAlbum> Album(int id);
        Task<IEnumerable<MediaExtendedAlbum>> Album(string name);
        Task Album(MediaExtendedAlbum item);
    }
}
