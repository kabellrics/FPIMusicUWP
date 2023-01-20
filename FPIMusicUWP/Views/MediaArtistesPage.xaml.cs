using System;

using FPIMusicUWP.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FPIMusicUWP.Views
{
    public sealed partial class MediaArtistesPage : Page
    {
        public MediaArtistesViewModel ViewModel { get; } = new MediaArtistesViewModel();

        public MediaArtistesPage()
        {
            InitializeComponent();
            Loaded += MediaArtistesPage_Loaded;
        }

        private async void MediaArtistesPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync();
        }
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    var collectionGroups = Collection.View.CollectionGroups;
        //    ((ListViewBase)this.Zoom.ZoomedOutView).ItemsSource = collectionGroups;
        //}
        private void Zoom_ViewChangeStarted(object sender, SemanticZoomViewChangedEventArgs e)
        {
            if (e.IsSourceZoomedInView == false)
            {
                e.DestinationItem.Item = e.SourceItem.Item;
            }
        }
    }
}
