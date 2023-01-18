using FPIMusicUWP.Services.Compilation;
using FPIMusicUWP.Services.Deezer;
using FPIMusicUWP.Services.Mediatheque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services
{
    public class Service:IService
    {
        private readonly String _ApiURL;
        public Service(String ApiURL)
        {
            _ApiURL = ApiURL;
            Compilation = new CompilService(_ApiURL);
            Mediatheque = new MediaService(_ApiURL);
            Deezer = new DeezerService(_ApiURL);
        }
        public ICompilService Compilation { get; private set; }

        public IMediaService Mediatheque { get; private set; }

        public IDeezerService Deezer { get; private set; }
    }
}
