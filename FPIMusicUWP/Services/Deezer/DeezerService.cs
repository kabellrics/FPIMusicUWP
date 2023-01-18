using FPIMusicUWP.Services.Deezer.Implementation;
using FPIMusicUWP.Services.Deezer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Deezer
{
    public class DeezerService: IDeezerService
    {
        private readonly String _ApiURL;
        public DeezerService(String ApiURL)
        {
            _ApiURL = ApiURL;
            Albums = new DeezerAlbService(_ApiURL);
            Artistes = new DeezerArtService(_ApiURL);
            Playlists = new DeezerPlaylistService(_ApiURL);
            Songs = new DeezerSongService(_ApiURL);
        }
        public IDeezerAlbService Albums { get; private set; }

        public IDeezerArtService Artistes { get; private set; }

        public IDeezerPlaylistService Playlists { get; private set; }

        public IDeezerSongService Songs { get; private set; }
    }
}
