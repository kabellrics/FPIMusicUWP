using FPIMusicUWP.Core.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Mediatheque.Interface
{
    public interface IMediaSongService
    {
        Task<MediathequeSong> Song(int id);
        Task<IEnumerable<MediathequeSong>> SongByAlbum(int id);
    }
}
