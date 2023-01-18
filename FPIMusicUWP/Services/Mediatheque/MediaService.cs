using FPIMusicUWP.Services.Mediatheque.Implementation;
using FPIMusicUWP.Services.Mediatheque.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Mediatheque
{
    public class MediaService: IMediaService
    {
        private readonly String _ApiURL;
        public MediaService(String ApiURL)
        {
            _ApiURL = ApiURL;
            Albums = new MediaAlbService(_ApiURL);
            Artistes = new MediaArtService(_ApiURL);
            Song = new MediaSongService(_ApiURL);
        }
        public IMediaAlbService Albums { get; private set; }

        public IMediaArtService Artistes { get; private set; }

        public IMediaSongService Song { get; private set; }
    }
}
