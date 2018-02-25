using System;

using ScoroTask.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ScoroTask.Views
{
    public sealed partial class AppInformationPage : Page
    {
        private AppInformationViewModel ViewModel
        {
            get { return DataContext as AppInformationViewModel; }
        }

        public AppInformationPage()
        {
            InitializeComponent();
        }
    }
}
