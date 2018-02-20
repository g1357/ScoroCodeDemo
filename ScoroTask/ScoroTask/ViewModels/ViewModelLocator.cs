using System;

using CommonServiceLocator;

using GalaSoft.MvvmLight.Ioc;

using ScoroTask.Services;
using ScoroTask.Views;

namespace ScoroTask.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            if (SimpleIoc.Default.IsRegistered<NavigationServiceEx>())
            {
                return;
            }

            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();
            Register<MainViewModel, MainPage>();
            Register<BlankViewModel, BlankPage>();
            Register<WebViewViewModel, WebViewPage>();
            Register<MasterDetailViewModel, MasterDetailPage>();
            Register<GridViewModel, GridPage>();
            Register<ChartViewModel, ChartPage>();
            Register<TabbedViewModel, TabbedPage>();
            Register<MapViewModel, MapPage>();
            Register<ImageGalleryViewModel, ImageGalleryPage>();
            Register<ImageGalleryDetailViewModel, ImageGalleryDetailPage>();
            Register<SettingsViewModel, SettingsPage>();
            Register<ShareTargetViewModel, ShareTargetPage>();
            Register<UserOperationsViewModel, UserOperationsPage>();
            Register<DocumentOperationsViewModel, DocumentOperationsPage>();
        }

        public DocumentOperationsViewModel DocumentOperationsViewModel => ServiceLocator.Current.GetInstance<DocumentOperationsViewModel>();

        public UserOperationsViewModel UserOperationsViewModel => ServiceLocator.Current.GetInstance<UserOperationsViewModel>();

        public ShareTargetViewModel ShareTargetViewModel => ServiceLocator.Current.GetInstance<ShareTargetViewModel>();

        public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();

        public ImageGalleryDetailViewModel ImageGalleryDetailViewModel => ServiceLocator.Current.GetInstance<ImageGalleryDetailViewModel>();

        public ImageGalleryViewModel ImageGalleryViewModel => ServiceLocator.Current.GetInstance<ImageGalleryViewModel>();

        public MapViewModel MapViewModel => ServiceLocator.Current.GetInstance<MapViewModel>();

        public TabbedViewModel TabbedViewModel => ServiceLocator.Current.GetInstance<TabbedViewModel>();

        public ChartViewModel ChartViewModel => ServiceLocator.Current.GetInstance<ChartViewModel>();

        public GridViewModel GridViewModel => ServiceLocator.Current.GetInstance<GridViewModel>();

        public MasterDetailViewModel MasterDetailViewModel => ServiceLocator.Current.GetInstance<MasterDetailViewModel>();

        public WebViewViewModel WebViewViewModel => ServiceLocator.Current.GetInstance<WebViewViewModel>();

        public BlankViewModel BlankViewModel => ServiceLocator.Current.GetInstance<BlankViewModel>();

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService => ServiceLocator.Current.GetInstance<NavigationServiceEx>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
