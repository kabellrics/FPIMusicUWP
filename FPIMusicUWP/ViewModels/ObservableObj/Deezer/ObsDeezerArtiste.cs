using CommunityToolkit.Mvvm.ComponentModel;
using FPIMusicUWP.Core.ModelDTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.ViewModels.ObservableObj.Deezer
{
    public class ObsDeezerArtiste : ObservableObject
    {
        public DeezerExtendedArtiste Artiste;
        private string apiUrl;
        public ObsDeezerArtiste(DeezerExtendedArtiste art, string Url)
        {
            Artiste = art;
            apiUrl = Url;
        }
        public int Id
        {
            get => Artiste.Id;
            set => SetProperty(Artiste.Id, value, Artiste, (syteme, item) => Artiste.Id = item);
        }
        public string Name
        {
            get => Artiste.Name;
            set
            {
                SetProperty(Artiste.Name, value, Artiste, (syteme, item) => Artiste.Name = item);
            }
        }
        public string Cover
        {
            get => Artiste.Cover;
            set
            {
                SetProperty(Artiste.Cover, value, Artiste, (syteme, item) => Artiste.Cover = item);
            }
        }
        public int NbSong
        {
            get => Artiste.NbSong;
            set => SetProperty(Artiste.NbSong, value, Artiste, (syteme, item) => Artiste.NbSong = item);
        }
        public int NbAlbum
        {
            get => Artiste.NbAlbum;
            set => SetProperty(Artiste.NbAlbum, value, Artiste, (syteme, item) => Artiste.NbAlbum = item);
        }
        public int NbPlaylist
        {
            get => Artiste.NbPlaylist;
            set => SetProperty(Artiste.NbPlaylist, value, Artiste, (syteme, item) => Artiste.NbPlaylist = item);
        }
        public string NbSongDisplay
        {
            get
            {
                if (NbSong == 1)
                    return "Un seule morceau";
                else if (NbSong == 0)
                    return "Aucun morceau";
                else
                    return $"{NbSong} morceaux";
            }
        }
        public string NbAlbumDisplay
        {
            get
            {
                if (NbAlbum == 1)
                    return "Un seul album";
                else if (NbAlbum == 0)
                    return "Aucun album";
                else
                    return $"{NbAlbum} albums";
            }
        }
        public string NbPlaylistDisplay
        {
            get
            {
                if (NbPlaylist == 1)
                    return "Une seule playlist";
                else if (NbPlaylist == 0)
                    return "Aucune playlist";
                else
                    return $"{NbPlaylist} playlists";
            }
        }
        public string DisplayCover
        {
            //get => Path.Combine(apiUrl, "api/Img/MediaArt", Artiste.Id.ToString());
            get => $"{apiUrl}/api/Img/DeezerArt/{Artiste.Id.ToString()}";

        }
    }
    public class ObsGroupedDeezerArtiste : ObservableObject
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
        public ObservableCollection<ObsDeezerArtiste> Items { get; set; }

        public ObsGroupedDeezerArtiste(GroupedDeezerExtendedArtiste groupedartiste, string uri)
        {
            this.Key = groupedartiste.Key;
            Items = new ObservableCollection<ObsDeezerArtiste>();
            foreach (var item in groupedartiste.Items)
            {
                Items.Add(new ObsDeezerArtiste(item, uri));
            }
        }
    }
}
