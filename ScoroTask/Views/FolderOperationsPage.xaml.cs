using System;

using ScoroTask.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ScoroTask.Views
{
    public sealed partial class FolderOperationsPage : Page
    {
        private FolderOperationsViewModel ViewModel
        {
            get { return DataContext as FolderOperationsViewModel; }
        }

        public FolderOperationsPage()
        {
            InitializeComponent();
        }
    }
}
