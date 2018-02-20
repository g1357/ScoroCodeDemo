using System;

using ScoroTask.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ScoroTask.Views
{
    public sealed partial class DocumentOperationsPage : Page
    {
        private DocumentOperationsViewModel ViewModel
        {
            get { return DataContext as DocumentOperationsViewModel; }
        }

        public DocumentOperationsPage()
        {
            InitializeComponent();
        }
    }
}
