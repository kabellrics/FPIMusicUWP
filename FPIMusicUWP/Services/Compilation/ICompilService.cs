using FPIMusicUWP.Services.Compilation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Compilation
{
    public interface ICompilService
    {
        ICompilAlbService Albums { get; }
        ICompilArtService Artistes { get; }
        ICompilSongService Song { get; }
    }
}
