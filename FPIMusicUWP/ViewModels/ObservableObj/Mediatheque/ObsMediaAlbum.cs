using CommunityToolkit.Mvvm.ComponentModel;
using FPIMusicUWP.Core.ModelDTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.ViewModels.ObservableObj.Mediatheque
{
    public class ObsMediaAlbum : ObservableObject
    {
        public MediaExtendedAlbum Album;
        private string apiUrl;
        public ObsMediaAlbum(MediaExtendedAlbum alb, string Url)
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
        public int NbSong
        {
            get => Album.NbSong;
            set => SetProperty(Album.NbSong, value, Album, (syteme, item) => Album.NbSong = item);
        }
        public int MediathequeArtisteID
        {
            get => Album.MediathequeArtisteID;
            set => SetProperty(Album.MediathequeArtisteID, value, Album, (syteme, item) => Album.MediathequeArtisteID = item);
        }
        public string NbSongDisplay
        {
            get
            {
                if (NbSong == 1)
                    return "Une seule morceau";
                else if (NbSong == 0)
                    return "Aucun morceau";
                else
                    return $"{NbSong} morceaux";
            }
        }
        public string DisplayCover
        {
            //get => Path.Combine(apiUrl, "api/Img/MediaArt", Album.Id.ToString());
            get => $"{apiUrl}/api/Img/MediaAlb/{Album.Id.ToString()}";

        }
    }
    public class ObsGroupedMediaAlbum : ObservableObject
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
        public ObservableCollection<ObsMediaAlbum> Items { get; set; }

        public ObsGroupedMediaAlbum(GroupedMediaExtendedAlbum groupedAlbum, string uri)
        {
            this.Key = groupedAlbum.Key;
            Items = new ObservableCollection<ObsMediaAlbum>();
            foreach (var item in groupedAlbum.Items)
            {
                Items.Add(new ObsMediaAlbum(item, uri));
            }
        }
    }
}
