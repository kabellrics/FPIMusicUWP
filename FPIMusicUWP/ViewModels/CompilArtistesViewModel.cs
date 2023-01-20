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
using FPIMusicUWP.ViewModels.ObservableObj.Compilation;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace FPIMusicUWP.ViewModels
{
    public class CompilArtistesViewModel : ObservableObject
    {
        public const string CompilArtistesSelectedIdKey = "CompilArtistesSelectedIdKey";
        private IService _service;
        private ISettingService _settingservice;

        private ICommand _itemSelectedCommand;

        //public ObservableCollection<SampleImage> Source { get; } = new ObservableCollection<SampleImage>();
        public ObservableCollection<ObsGroupedCompilArtiste> GrpArtistes { get; } = new ObservableCollection<ObsGroupedCompilArtiste>();

        public ICommand ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<ItemClickEventArgs>(OnItemSelected));

        public CompilArtistesViewModel()
        {
            _service = Ioc.Default.GetRequiredService<IService>();
            _settingservice = Ioc.Default.GetRequiredService<ISettingService>();
        }

        public async Task LoadDataAsync()
        {
            GrpArtistes.Clear();
            var arts = await _service.Compilation.Artistes.groupedArtistes();
            foreach (var art in arts)
            {
                var obsitem = new ObsGroupedCompilArtiste(art, _settingservice.APIURLEndpoint);
                GrpArtistes.Add(obsitem);
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
            //var selected = args.ClickedItem as SampleImage;
            //ImagesNavigationHelper.AddImageId(CompilArtistesSelectedIdKey, selected.ID);
            //NavigationService.Frame.SetListDataItemForNextConnectedAnimation(selected);
            //NavigationService.Navigate<CompilArtistesDetailPage>(selected.ID);
        }
    }
}
