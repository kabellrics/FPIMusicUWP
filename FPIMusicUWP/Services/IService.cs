using FPIMusicUWP.Services.Compilation;
using FPIMusicUWP.Services.Deezer;
using FPIMusicUWP.Services.Mediatheque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services
{
    public interface IService
    {
        ICompilService Compilation { get; }
        IMediaService Mediatheque { get; }
        IDeezerService Deezer { get; }
    }
}
