using System;

using ScoroTask.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ScoroTask.Views
{
    public sealed partial class BlankPage : Page
    {
        private BlankViewModel ViewModel
        {
            get { return DataContext as BlankViewModel; }
        }

        public BlankPage()
        {
            InitializeComponent();
        }
    }
}
