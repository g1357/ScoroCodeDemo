﻿using System;

using ScoroTask.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ScoroTask.Views
{
    public sealed partial class SettingsPage : Page
    {
        private SettingsViewModel ViewModel
        {
            get { return DataContext as SettingsViewModel; }
        }

        //// TODO WTS: Change the URL for your privacy policy in the Resource File, currently set to https://YourPrivacyUrlGoesHere

        public SettingsPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.Initialize();
        }
    }
}
