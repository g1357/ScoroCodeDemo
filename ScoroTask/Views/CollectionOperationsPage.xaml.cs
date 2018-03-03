using System;

using ScoroTask.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ScoroTask.Views
{
    public sealed partial class CollectionOperationsPage : Page
    {
        private CollectionOperationsViewModel ViewModel
        {
            get { return DataContext as CollectionOperationsViewModel; }
        }

        public CollectionOperationsPage()
        {
            InitializeComponent();
        }

        private void TextBlock_SelectionChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
