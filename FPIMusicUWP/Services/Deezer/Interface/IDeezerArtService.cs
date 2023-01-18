using FPIMusicUWP.Core.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Deezer.Interface
{
    public interface IDeezerArtService
    {
        Task<IEnumerable<GroupedDeezerExtendedArtiste>> GroupedArtistes();
        Task<IEnumerable<DeezerExtendedArtiste>> Artistes();
        Task<IEnumerable<DeezerExtendedArtiste>> ArtisteWithMostPlaylist();
        Task<IEnumerable<DeezerExtendedArtiste>> ArtisteWithMostSong();
        Task<IEnumerable<DeezerExtendedArtiste>> ArtisteWithMostAlbum();
        Task<DeezerExtendedArtiste> Artiste(int id);
        Task<IEnumerable<DeezerExtendedArtiste>> Artiste(string name);
        Task Artiste(DeezerExtendedArtiste item);
    }
}
