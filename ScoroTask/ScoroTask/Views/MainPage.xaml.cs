using System;

using ScoroTask.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ScoroTask.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel
        {
            get { return DataContext as MainViewModel; }
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
