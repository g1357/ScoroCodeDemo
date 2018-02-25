using System;

using ScoroTask.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ScoroTask.Views
{
    public sealed partial class MessageOperationsPage : Page
    {
        private MessageOperationsViewModel ViewModel
        {
            get { return DataContext as MessageOperationsViewModel; }
        }

        public MessageOperationsPage()
        {
            InitializeComponent();
        }
    }
}
