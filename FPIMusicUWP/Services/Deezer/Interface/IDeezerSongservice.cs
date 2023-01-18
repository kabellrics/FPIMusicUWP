using FPIMusicUWP.Core.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Deezer.Interface
{
    public interface IDeezerSongService
    {
        Task<DeezerSong> Song(int id);
        Task<IEnumerable<DeezerSong>> SongByArtiste(int id);
        Task<IEnumerable<DeezerSong>> SongByAlbum(int id);
        Task<IEnumerable<DeezerSong>> SongByPlaylist(int id);
    }
}
