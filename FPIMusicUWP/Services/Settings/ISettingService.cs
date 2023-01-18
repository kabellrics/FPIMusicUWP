using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.Services.Settings
{
    public interface ISettingService
    {
        string APIURLEndpoint { get; set; }
        string MediathequePath { get; }
        string CompilationPath { get; }
        string DeezerPath { get; }
    }
}
