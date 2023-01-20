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
    public class ObsDeezerPlaylist : ObservableObject
    {
        public DeezerExtendedPlaylist Playlist;
        private string apiUrl;
        public ObsDeezerPlaylist(DeezerExtendedPlaylist pl, string Url)
        {
            Playlist = pl;
            apiUrl = Url;
        }
        public int Id
        {
            get => Playlist.Id;
            set => SetProperty(Playlist.Id, value, Playlist, (syteme, item) => Playlist.Id = item);
        }
        public string Name
        {
            get => Playlist.Name;
            set
            {
                SetProperty(Playlist.Name, value, Playlist, (syteme, item) => Playlist.Name = item);
            }
        }
        public string Cover
        {
            get => Playlist.Cover;
            set
            {
                SetProperty(Playlist.Cover, value, Playlist, (syteme, item) => Playlist.Cover = item);
            }
        }
        public int NbSong
        {
            get => Playlist.NbSong;
            set => SetProperty(Playlist.NbSong, value, Playlist, (syteme, item) => Playlist.NbSong = item);
        }
        public int NbAlbum
        {
            get => Playlist.NbAlbum;
            set => SetProperty(Playlist.NbAlbum, value, Playlist, (syteme, item) => Playlist.NbAlbum = item);
        }
        public int NbArtiste
        {
            get => Playlist.NbArtiste;
            set => SetProperty(Playlist.NbArtiste, value, Playlist, (syteme, item) => Playlist.NbArtiste = item);
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
            //get => Path.Combine(apiUrl, "api/Img/MediaArt", Artiste.Id.ToString());
            get => $"{apiUrl}/api/Img/DeezerPlaylist/{Playlist.Id.ToString()}";

        }
    }
    public class ObsGroupedDeezerPlaylist : ObservableObject
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
        public ObservableCollection<ObsDeezerPlaylist> Items { get; set; }

        public ObsGroupedDeezerPlaylist(GroupedDeezerExtendedPlaylist groupedartiste, string uri)
        {
            this.Key = groupedartiste.Key;
            Items = new ObservableCollection<ObsDeezerPlaylist>();
            foreach (var item in groupedartiste.Items)
            {
                Items.Add(new ObsDeezerPlaylist(item, uri));
            }
        }
    }
}
