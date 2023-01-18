using FPIMusicUWP.Services.Mediatheque.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Mediatheque
{
    public interface IMediaService
    {
        IMediaAlbService Albums { get; }
        IMediaArtService Artistes { get; }
        IMediaSongService Song { get; }
    }
}
