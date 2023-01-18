using FPIMusicUWP.Services.Compilation.Implementation;
using FPIMusicUWP.Services.Compilation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Compilation
{
    public class CompilService: ICompilService
    {
        private readonly String _ApiURL;
        public CompilService( String ApiURL)
        {
            _ApiURL = ApiURL;
            Albums = new CompilAlbService(_ApiURL);
            Artistes = new CompilArtService(_ApiURL);
            Song = new CompilSongService(_ApiURL);
        }
        public ICompilAlbService Albums { get; private set; }
        public ICompilArtService Artistes { get; private set; }
        public ICompilSongService Song { get; private set; }
    }
}
