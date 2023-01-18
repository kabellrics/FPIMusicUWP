using System;
using System.Threading.Tasks;
using System.Windows.Input;

using FPIMusicUWP.Helpers;
using FPIMusicUWP.Services;
using FPIMusicUWP.Services.Settings;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;

using Windows.ApplicationModel;
using Windows.UI.Xaml;

namespace FPIMusicUWP.ViewModels
{
    // TODO: Add other settings as necessary. For help see https://github.com/microsoft/TemplateStudio/blob/main/docs/UWP/pages/settings.md
    public class SettingsViewModel : ObservableObject
    {
        private ElementTheme _elementTheme = ThemeSelectorService.Theme;
        private ISettingService _settingService;
        public ElementTheme ElementTheme
        {
            get { return _elementTheme; }

            set { SetProperty(ref _elementTheme, value); }
        }

        private string _versionDescription;
        private string _CandidateURL;

        public string CandidateURL
        {
            get { return _CandidateURL; }

            set { SetProperty(ref _CandidateURL, value); }
        }
        public string VersionDescription
        {
            get { return _versionDescription; }

            set { SetProperty(ref _versionDescription, value); }
        }
        public string MediathequePath
        {
            get { return _settingService.MediathequePath; }
        }
        public string CompilationPath
        {
            get { return _settingService.CompilationPath; }
        }
        public string DeezerPath
        {
            get { return _settingService.DeezerPath; }
        }

        private ICommand _switchThemeCommand;
        private ICommand _validateURLCommand;

        public ICommand ValidateURLCommand
        {
            get
            {
                if (_validateURLCommand == null)
                {
                    _validateURLCommand = new RelayCommand(
                        () =>
                        {
                            ValidateURL();
                        });
                }

                return _validateURLCommand;
            }
        }

        private void ValidateURL()
        {
            _settingService.APIURLEndpoint = CandidateURL;
        }

        public ICommand SwitchThemeCommand
        {
            get
            {
                if (_switchThemeCommand == null)
                {
                    _switchThemeCommand = new RelayCommand<ElementTheme>(
                        async (param) =>
                        {
                            ElementTheme = param;
                            await ThemeSelectorService.SetThemeAsync(param);
                        });
                }

                return _switchThemeCommand;
            }
        }

        public SettingsViewModel(/*ISettingService settingService*/)
        {
            _settingService = Ioc.Default.GetRequiredService<ISettingService>();
        }

        public async Task InitializeAsync()
        {
            VersionDescription = GetVersionDescription();
            await Task.CompletedTask;
        }

        private string GetVersionDescription()
        {
            var appName = "AppDisplayName".GetLocalized();
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;

            return $"{appName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}
