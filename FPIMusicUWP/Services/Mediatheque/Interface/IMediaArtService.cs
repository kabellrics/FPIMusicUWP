using FPIMusicUWP.Core.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Mediatheque.Interface
{
    public interface IMediaArtService
    {
        Task<IEnumerable<GroupedMediaExtendedArtiste>> groupedArtistes();
        Task<IEnumerable<MediaExtendedArtiste>> Artistes();
        Task<IEnumerable<MediaExtendedArtiste>> ArtisteWithMostSongs();
        Task<IEnumerable<MediaExtendedArtiste>> ArtisteWithMostAlbums();
        Task<MediaExtendedArtiste> Artiste(int id);
        Task<IEnumerable<MediaExtendedArtiste>> Artiste(string name);
        Task Artiste(MediaExtendedArtiste item);
    }
}
