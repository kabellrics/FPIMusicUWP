using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using FPIMusicUWP.Core.Models;
using FPIMusicUWP.Core.Services;
using FPIMusicUWP.Helpers;
using FPIMusicUWP.Services;
using FPIMusicUWP.Views;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Toolkit.Uwp.UI.Animations;

using Windows.UI.Xaml.Controls;
using FPIMusicUWP.Services.Settings;
using CommunityToolkit.Mvvm.DependencyInjection;
using FPIMusicUWP.ViewModels.ObservableObj.Compilation;
using FPIMusicUWP.ViewModels.ObservableObj.Deezer;

namespace FPIMusicUWP.ViewModels
{
    public class CompilAlbumViewModel : ObservableObject
    {
        public const string CompilAlbumSelectedIdKey = "CompilAlbumSelectedIdKey";
        private IService _service;
        private ISettingService _settingservice;

        private ICommand _itemSelectedCommand;

        //public ObservableCollection<SampleImage> Source { get; } = new ObservableCollection<SampleImage>();
        public ObservableCollection<ObsGroupedCompilAlbum> GrpAlbums { get; } = new ObservableCollection<ObsGroupedCompilAlbum>();

        public ICommand ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<ItemClickEventArgs>(OnItemSelected));

        public CompilAlbumViewModel()
        {
            _service = Ioc.Default.GetRequiredService<IService>();
            _settingservice = Ioc.Default.GetRequiredService<ISettingService>();
        }

        public async Task LoadDataAsync()
        {
            GrpAlbums.Clear();
            var arts = await _service.Compilation.Albums.groupedAlbums();
            foreach (var art in arts)
            {
                var obsitem = new ObsGroupedCompilAlbum(art, _settingservice.APIURLEndpoint);
                GrpAlbums.Add(obsitem);
            }
            //Source.Clear();

            //// Replace this with your actual data
            //var data = await SampleDataService.GetImageGalleryDataAsync("ms-appx:///Assets");

            //foreach (var item in data)
            //{
            //    Source.Add(item);
            //}
        }

        private void OnItemSelected(ItemClickEventArgs args)
        {
            var selected = args.ClickedItem as ObsCompilAlbum;
            //ImagesNavigationHelper.AddImageId(CompilAlbumSelectedIdKey, selected.ID);
            NavigationService.Frame.SetListDataItemForNextConnectedAnimation(selected);
            NavigationService.Navigate<CompilAlbumDetailPage>(selected.Id);
        }
    }
}
