using System;

using FPIMusicUWP.Services;
using FPIMusicUWP.Services.Settings;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.Mvvm.DependencyInjection;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using FPIMusicUWP.Services.Player;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Mvvm.Messaging;
using FPIMusicUWP.Core.Model;
using FPIMusicUWP.ViewModels;

namespace FPIMusicUWP
{
    public sealed partial class App : Application
    {
        private Lazy<ActivationService> _activationService;

        private ActivationService ActivationService
        {
            get { return _activationService.Value; }
        }

        public App()
        {
            try
            {
                InitializeComponent();
                UnhandledException += OnAppUnhandledException;

                // Deferred execution until used. Check https://docs.microsoft.com/dotnet/api/system.lazy-1 for further info on Lazy<T> class.
                _activationService = new Lazy<ActivationService>(CreateActivationService);
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args);
            }
            Ioc.Default.ConfigureServices(
               new ServiceCollection()
               .AddSingleton<ISettingService,SettingService>()
               .AddSingleton<IService, Service>()
               .AddSingleton<IPlayerService, PlayerService>()
               .AddSingleton<CompilAlbumDetailViewModel>()
               .AddSingleton<CompilArtistesDetailViewModel>()
               .AddSingleton<DeezerArtistesDetailViewModel>()
               .AddSingleton<DeezerAlbumsDetailViewModel>()
               .AddSingleton<DeezerPlaylistDetailViewModel>()
               .AddSingleton<MediaAlbumsDetailViewModel>()
               .AddSingleton<MediaArtistesDetailViewModel>()
               .BuildServiceProvider());


            var _settingservice = Ioc.Default.GetRequiredService<ISettingService>();
            var connection = new HubConnectionBuilder()
                .WithUrl(new Uri($"{_settingservice.APIURLEndpoint}/synchro"))
                .WithAutomaticReconnect()
                .ConfigureLogging(logging =>
                {
                    //logging.AddConsole();
                    // This will set ALL logging to Debug level
                    logging.SetMinimumLevel(LogLevel.Debug);
                })
                .Build();
            connection.On<string>("Synchro", message =>
            {
                WeakReferenceMessenger.Default.Send(new PlayerInfoChangedMessage(message));
            });
            await connection.StartAsync();
        }

        protected override async void OnActivated(IActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);
        }

        private void OnAppUnhandledException(object sender, Windows.UI.Xaml.UnhandledExceptionEventArgs e)
        {
            // TODO: Please log and handle the exception as appropriate to your scenario
            // For more info see https://docs.microsoft.com/uwp/api/windows.ui.xaml.application.unhandledexception
        }

        private ActivationService CreateActivationService()
        {
            return new ActivationService(this, typeof(Views.MainPage), new Lazy<UIElement>(CreateShell));
        }

        private UIElement CreateShell()
        {
            return new Views.ShellPage();
        }
    }
}
