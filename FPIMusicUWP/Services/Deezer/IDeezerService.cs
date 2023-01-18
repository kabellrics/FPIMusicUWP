using FPIMusicUWP.Services.Deezer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Deezer
{
    public interface IDeezerService
    {
        IDeezerAlbService Albums { get; }
        IDeezerArtService Artistes { get; }
        IDeezerPlaylistService Playlists { get; }
        IDeezerSongService Songs { get; }
    }
}
