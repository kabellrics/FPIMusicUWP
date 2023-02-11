using CommunityToolkit.Mvvm.ComponentModel;
using FPIMusicUWP.Core.ModelDTO;
using FPIMusicUWP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.ViewModels.ObservableObj.Compilation
{
    public class ObsCompilSong : ObservableObject
    {
        public CompilationSong Song;
        private string apiUrl;
        private bool _selected;
        public ObsCompilSong(CompilationSong sg, string Url)
        {
            Song = sg;
            apiUrl = Url;
            Selected = false;
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
        public string DisplayCover
        {
            //get => Path.Combine(apiUrl, "api/Img/CompilArt", Album.Id.ToString());
            get => $"{apiUrl}/api/Img/CompilAlb/{Song.AlbumId.ToString()}";

        }
    }
}
