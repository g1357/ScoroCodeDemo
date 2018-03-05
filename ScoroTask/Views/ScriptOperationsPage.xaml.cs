using System;

using ScoroTask.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ScoroTask.Views
{
    public sealed partial class ScriptOperationsPage : Page
    {
        private ScriptOperationsViewModel ViewModel
        {
            get { return DataContext as ScriptOperationsViewModel; }
        }

        public ScriptOperationsPage()
        {
            InitializeComponent();
        }
    }
}
