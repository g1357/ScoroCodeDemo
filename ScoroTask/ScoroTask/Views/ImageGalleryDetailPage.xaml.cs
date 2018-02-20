using System;

using ScoroTask.Models;
using ScoroTask.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ScoroTask.Views
{
    public sealed partial class ImageGalleryDetailPage : Page
    {
        private ImageGalleryDetailViewModel ViewModel
        {
            get { return DataContext as ImageGalleryDetailViewModel; }
        }

        public ImageGalleryDetailPage()
        {
            InitializeComponent();
            ViewModel.SetImage(previewImage);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.Initialize(e.Parameter as SampleImage);
            showFlipView.Begin();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                previewImage.Visibility = Visibility.Visible;
                ViewModel.SetAnimation();
            }
        }
    }
}
