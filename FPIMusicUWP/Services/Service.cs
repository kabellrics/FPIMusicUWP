using FPIMusicUWP.Services.Compilation;
using FPIMusicUWP.Services.Deezer;
using FPIMusicUWP.Services.Mediatheque;
using FPIMusicUWP.Services.Settings;
using CommunityToolkit.Mvvm.DependencyInjection;
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
        private readonly ISettingService _settingService;
        public Service()
        {
            _settingService = Ioc.Default.GetRequiredService<ISettingService>();
            Compilation = new CompilService(_settingService.APIURLEndpoint);
            Mediatheque = new MediaService(_settingService.APIURLEndpoint);
            Deezer = new DeezerService(_settingService.APIURLEndpoint);
        }
        public ICompilService Compilation { get; private set; }

        public IMediaService Mediatheque { get; private set; }

        public IDeezerService Deezer { get; private set; }
    }
}
