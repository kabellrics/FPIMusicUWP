using FPIMusicUWP.Core.ModelDTO;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusicUWP.ViewModels.ObservableObj.Mediatheque
{
    public class ObsMediaArtiste: ObservableObject
    {
        public MediaExtendedArtiste Artiste;
        private string apiUrl;
        public ObsMediaArtiste(MediaExtendedArtiste art,string Url)
        {
            Artiste = art;
            apiUrl= Url;
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
        public string DisplayCover
        {
            //get => Path.Combine(apiUrl, "api/Img/MediaArt", Artiste.Id.ToString());
            get => $"{apiUrl}/api/Img/MediaArt/{Artiste.Id.ToString()}";

        }
    }
}
