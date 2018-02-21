using System;

using ScoroTask.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ScoroTask.Views
{
    public sealed partial class UserOperationsPage : Page
    {
        private UserOperationsViewModel ViewModel
        {
            get { return DataContext as UserOperationsViewModel; }
        }

        public UserOperationsPage()
        {
            InitializeComponent();
        }
    }
}
