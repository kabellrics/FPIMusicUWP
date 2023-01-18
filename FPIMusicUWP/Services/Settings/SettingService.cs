using FPIMusicUWP.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using static Microsoft.Toolkit.Uwp.UI.Animations.Expressions.ExpressionValues;

namespace FPIMusicUWP.Services.Settings
{
    public class SettingService: ISettingService
    {
        private SettingsClient SettingConnector;
        public SettingService()
        {
            if (!string.IsNullOrEmpty(APIURLEndpoint))
            {
                SettingConnector = new SettingsClient(APIURLEndpoint, new HttpClient());
            }
        }
        private void SettingURL()
        {
            SettingConnector = new SettingsClient(APIURLEndpoint, new HttpClient());
        }
        private const string IdUrlBase = "url_base";
        public string APIURLEndpoint
        {
            get
            {
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                return localSettings.Values[IdUrlBase] as string;
            }
            //Preferences.Get(IdUrlBase, string.Empty)};
            set { var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                localSettings.Values[IdUrlBase] = value;
                //Preferences.Set(IdUrlBase, value); SettingURL();
            }
        }
        public string MediathequePath
        {
            get => SettingConnector.MediathequePathAsync().Result.Value;
        }
        public string CompilationPath
        {
            get => SettingConnector.CompilationPathAsync().Result.Value;
        }
        public string DeezerPath
        {
            get => SettingConnector.DeezerPathAsync().Result.Value;
        }

    }
}
