﻿using System;

using ScoroTask.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ScoroTask.Views
{
    public sealed partial class WebViewPage : Page
    {
        private WebViewViewModel ViewModel
        {
            get { return DataContext as WebViewViewModel; }
        }

        public WebViewPage()
        {
            InitializeComponent();
            ViewModel.Initialize(webView);
        }
    }
}
