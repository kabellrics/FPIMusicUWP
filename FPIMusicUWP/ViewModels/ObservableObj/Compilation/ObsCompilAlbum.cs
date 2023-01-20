using CommunityToolkit.Mvvm.ComponentModel;
using FPIMusicUWP.Core.ModelDTO;
using FPIMusicUWP.ViewModels.ObservableObj.Compilation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.ViewModels.ObservableObj.Compilation
{
    public class ObsCompilAlbum : ObservableObject
    {
        public CompilExtendedAlbum Album;
        private string apiUrl;
        public ObsCompilAlbum(CompilExtendedAlbum alb, string Url)
        {
            Album = alb;
            apiUrl = Url;
        }
        public int Id
        {
            get => Album.Id;
            set => SetProperty(Album.Id, value, Album, (syteme, item) => Album.Id = item);
        }
        public string Name
        {
            get => Album.Name;
            set
            {
                SetProperty(Album.Name, value, Album, (syteme, item) => Album.Name = item);
            }
        }
        public string Cover
        {
            get => Album.Cover;
            set
            {
                SetProperty(Album.Cover, value, Album, (syteme, item) => Album.Cover = item);
            }
        }
        public int NbArtiste
        {
            get => Album.NbArtiste;
            set => SetProperty(Album.NbArtiste, value, Album, (syteme, item) => Album.NbArtiste = item);
        }
        public int NbSong
        {
            get => Album.NbSong;
            set => SetProperty(Album.NbSong, value, Album, (syteme, item) => Album.NbSong = item);
        }
        public string NbSongDisplay
        {
            get
            {
                if (NbSong == 1)
                    return "Un seul morceau";
                else if (NbSong == 0)
                    return "Aucun morceau";
                else
                    return $"{NbSong} morceaux";
            }
        }
        public string NbArtisteDisplay
        {
            get
            {
                if (NbArtiste == 1)
                    return "Un seul artiste";
                else if (NbArtiste == 0)
                    return "Aucun artiste";
                else
                    return $"{NbArtiste} artistes";
            }
        }
        public string DisplayCover
        {
            //get => Path.Combine(apiUrl, "api/Img/CompilArt", Album.Id.ToString());
            get => $"{apiUrl}/api/Img/CompilAlb/{Album.Id.ToString()}";

        }
    }
    public class ObsGroupedCompilAlbum : ObservableObject
    {
        private string _key;
        public String Key
        {
            get => _key;
            set
            {
                SetProperty(ref _key, value);
            }
        }
        public ObservableCollection<ObsCompilAlbum> Items { get; set; }

        public ObsGroupedCompilAlbum(GroupedCompilExtendedAlbum groupedAlbum, string uri)
        {
            this.Key = groupedAlbum.Key;
            Items = new ObservableCollection<ObsCompilAlbum>();
            foreach (var item in groupedAlbum.Items)
            {
                Items.Add(new ObsCompilAlbum(item, uri));
            }
        }
    }
}
