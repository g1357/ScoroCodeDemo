using System;

using ScoroTask.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ScoroTask.Views
{
    public sealed partial class FileOperationsPage : Page
    {
        private FileOperationsViewModel ViewModel
        {
            get { return DataContext as FileOperationsViewModel; }
        }

        public FileOperationsPage()
        {
            InitializeComponent();
        }
    }
}
