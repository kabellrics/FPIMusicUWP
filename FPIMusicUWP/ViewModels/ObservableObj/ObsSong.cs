using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FPIMusicUWP.Core.Model;
using FPIMusicUWP.Core.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace FPIMusicUWP.ViewModels.ObservableObj
{
    public class ObsSong : ObservableObject
    {
        public Song Song;
        private string apiUrl;
        private bool _selected;
        private string _ArtisteAlbumDisplay;
        private int _defilement;
        private ICommand _isSelectedCommand;
        public ICommand IsSelectedCommand => _isSelectedCommand ?? (_isSelectedCommand = new RelayCommand<ItemClickEventArgs>(OnSelected));

        private void OnSelected(ItemClickEventArgs obj)
        {
            Selected = !Selected;
        }

        public ObsSong(Song sg, string Url)
        {
            Song = sg;
            apiUrl = Url;
            Selected = false;
            ArtisteAlbumDisplay = $"{Song.Artiste} - {Song.Album}";
        }
        public bool Selected
        {
            get => _selected;
            set
            {
                SetProperty(ref _selected, value);
            }
        }
        public int Id
        {
            get => Song.Id;
            set => SetProperty(Song.Id, value, Song, (syteme, item) => Song.Id = item);
        }
        public int Piste
        {
            get => Song.Piste;
            set => SetProperty(Song.Piste, value, Song, (syteme, item) => Song.Piste = item);
        }
        public string Path
        {
            get => Song.Path;
            set => SetProperty(Song.Path, value, Song, (syteme, item) => Song.Path = item);
        }
        public string Title
        {
            get => Song.Title;
            set => SetProperty(Song.Title, value, Song, (syteme, item) => Song.Title = item);
        }
        public string Artiste
        {
            get => Song.Artiste;
            set => SetProperty(Song.Artiste, value, Song, (syteme, item) => Song.Artiste = item);
        }
        public string Album
        {
            get => Song.Album;
            set => SetProperty(Song.Album, value, Song, (syteme, item) => Song.Title = item);
        }
        public string ArtisteAlbumDisplay
        {

            get => _ArtisteAlbumDisplay;
            set
            {
                SetProperty(ref _ArtisteAlbumDisplay, value);
                //if (value.Length > 50)
                //{
                //    _defilement = 0;
                //    SetDefilement();
                //}
            }
        }

        private void SetDefilement()
        {
            Timer timer = new Timer();
            timer.Interval = 175;
            timer.Elapsed += Timer_Elapsed; ;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                if (_defilement == Song.Artiste.Length + Song.Album.Length)
                    _defilement = 0;
                if (_defilement < (Song.Artiste.Length + Song.Album.Length) - 60)
                    ArtisteAlbumDisplay = $"{Song.Artiste} - {Song.Album}".Substring(_defilement++, 60);
                else
                    ArtisteAlbumDisplay = $"{Song.Artiste} - {Song.Album}".Substring(_defilement++);
            });
        }

        public string DisplayCover
        {
            //get => Path.Combine(apiUrl, "api/Img/CompilArt", Album.Id.ToString());
            get
            {
                if (Song.SongType == SongType._0)
                    return $"{apiUrl}/api/Img/MediaAlb/{Song.AlbumId.ToString()}";
                else if (Song.SongType == SongType._1)
                    return $"{apiUrl}/api/Img/CompilAlb/{Song.AlbumId.ToString()}";
                else if (Song.SongType == SongType._2)
                    return $"{apiUrl}/api/Img/DeezerAlb/{Song.AlbumId.ToString()}";
                else
                    return string.Empty;
            } 

        }
    }
}
