using System;

using FPIMusicUWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace FPIMusicUWP.Views
{
    public sealed partial class HomeDeezerPage : Page
    {
        public HomeDeezerViewModel ViewModel { get; } = new HomeDeezerViewModel();

        public HomeDeezerPage()
        {
            InitializeComponent();
        }
    }
}
