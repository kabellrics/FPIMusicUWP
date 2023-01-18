using System;

using FPIMusicUWP.ViewModels;

using Windows.UI.Xaml.Controls;

namespace FPIMusicUWP.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
