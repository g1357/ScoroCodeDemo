using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using CommonServiceLocator;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Microsoft.Toolkit.Uwp.UI.Controls;

using ScoroTask.Helpers;
using ScoroTask.Services;
using ScoroTask.Views;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ScoroTask.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private const string PanoramicStateName = "PanoramicState";
        private const string WideStateName = "WideState";
        private const string NarrowStateName = "NarrowState";
        private const double WideStateMinWindowWidth = 640;
        private const double PanoramicStateMinWindowWidth = 1024;

        public NavigationServiceEx NavigationService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NavigationServiceEx>();
            }
        }

        private bool _isPaneOpen;

        public bool IsPaneOpen
        {
            get { return _isPaneOpen; }
            set { Set(ref _isPaneOpen, value); }
        }

        private object _selected;

        public object Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        private SplitViewDisplayMode _displayMode = SplitViewDisplayMode.CompactInline;

        public SplitViewDisplayMode DisplayMode
        {
            get { return _displayMode; }
            set { Set(ref _displayMode, value); }
        }

        private object _lastSelectedItem;

        private ObservableCollection<ShellNavigationItem> _primaryItems = new ObservableCollection<ShellNavigationItem>();

        public ObservableCollection<ShellNavigationItem> PrimaryItems
        {
            get { return _primaryItems; }
            set { Set(ref _primaryItems, value); }
        }

        private ObservableCollection<ShellNavigationItem> _secondaryItems = new ObservableCollection<ShellNavigationItem>();

        public ObservableCollection<ShellNavigationItem> SecondaryItems
        {
            get { return _secondaryItems; }
            set { Set(ref _secondaryItems, value); }
        }

        private ICommand _openPaneCommand;

        public ICommand OpenPaneCommand
        {
            get
            {
                if (_openPaneCommand == null)
                {
                    _openPaneCommand = new RelayCommand(() => IsPaneOpen = !_isPaneOpen);
                }

                return _openPaneCommand;
            }
        }

        private ICommand _itemSelected;

        public ICommand ItemSelectedCommand
        {
            get
            {
                if (_itemSelected == null)
                {
                    _itemSelected = new RelayCommand<HamburgetMenuItemInvokedEventArgs>(ItemSelected);
                }

                return _itemSelected;
            }
        }

        private ICommand _stateChangedCommand;

        public ICommand StateChangedCommand
        {
            get
            {
                if (_stateChangedCommand == null)
                {
                    _stateChangedCommand = new RelayCommand<Windows.UI.Xaml.VisualStateChangedEventArgs>(args => GoToState(args.NewState.Name));
                }

                return _stateChangedCommand;
            }
        }

        private void GoToState(string stateName)
        {
            switch (stateName)
            {
                case PanoramicStateName:
                    DisplayMode = SplitViewDisplayMode.CompactInline;
                    break;
                case WideStateName:
                    DisplayMode = SplitViewDisplayMode.CompactInline;
                    IsPaneOpen = false;
                    break;
                case NarrowStateName:
                    DisplayMode = SplitViewDisplayMode.Overlay;
                    IsPaneOpen = false;
                    break;
                default:
                    break;
            }
        }

        public void Initialize(Frame frame)
        {
            NavigationService.Frame = frame;
            NavigationService.Navigated += Frame_Navigated;
            PopulateNavItems();

            InitializeState(Window.Current.Bounds.Width);
        }

        private void InitializeState(double windowWith)
        {
            if (windowWith < WideStateMinWindowWidth)
            {
                GoToState(NarrowStateName);
            }
            else if (windowWith < PanoramicStateMinWindowWidth)
            {
                GoToState(WideStateName);
            }
            else
            {
                GoToState(PanoramicStateName);
            }
        }

        private void PopulateNavItems()
        {
            _primaryItems.Clear();
            _secondaryItems.Clear();

            // TODO WTS: Change the symbols for each item as appropriate for your app
            // More on Segoe UI Symbol icons: https://docs.microsoft.com/windows/uwp/style/segoe-ui-symbol-font
            // Or to use an IconElement instead of a Symbol see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/projectTypes/navigationpane.md
            // Edit String/en-US/Resources.resw: Add a menu item title for each page
            _primaryItems.Add(new ShellNavigationItem("Shell_Main".GetLocalized(), Symbol.Document, typeof(MainViewModel).FullName));
            _primaryItems.Add(new ShellNavigationItem("Shell_UserOperations".GetLocalized(), Symbol.OtherUser, typeof(UserOperationsViewModel).FullName));
            _primaryItems.Add(new ShellNavigationItem("Shell_DocumentOperations".GetLocalized(), Symbol.Document, typeof(DocumentOperationsViewModel).FullName));
            _primaryItems.Add(new ShellNavigationItem("Shell_FileOperations".GetLocalized(), Symbol.SyncFolder, typeof(FileOperationsViewModel).FullName));
            _primaryItems.Add(new ShellNavigationItem("Shell_MessageOperations".GetLocalized(), Symbol.Message, typeof(MessageOperationsViewModel).FullName));

            _primaryItems.Add(new ShellNavigationItem("Shell_Blank".GetLocalized(), Symbol.Document, typeof(BlankViewModel).FullName));
            _primaryItems.Add(new ShellNavigationItem("Shell_WebView".GetLocalized(), Symbol.Document, typeof(WebViewViewModel).FullName));
            _primaryItems.Add(new ShellNavigationItem("Shell_MasterDetail".GetLocalized(), Symbol.Document, typeof(MasterDetailViewModel).FullName));
            _primaryItems.Add(new ShellNavigationItem("Shell_Grid".GetLocalized(), Symbol.Document, typeof(GridViewModel).FullName));
            _primaryItems.Add(new ShellNavigationItem("Shell_Chart".GetLocalized(), Symbol.Document, typeof(ChartViewModel).FullName));
            _primaryItems.Add(new ShellNavigationItem("Shell_Tabbed".GetLocalized(), Symbol.Document, typeof(TabbedViewModel).FullName));
            _primaryItems.Add(new ShellNavigationItem("Shell_Map".GetLocalized(), Symbol.Document, typeof(MapViewModel).FullName));
            _primaryItems.Add(new ShellNavigationItem("Shell_ImageGallery".GetLocalized(), Symbol.Document, typeof(ImageGalleryViewModel).FullName));
            _secondaryItems.Add(new ShellNavigationItem("Shell_Settings".GetLocalized(), Symbol.Setting, typeof(SettingsViewModel).FullName));
        }

        private void ItemSelected(HamburgetMenuItemInvokedEventArgs args)
        {
            if (DisplayMode == SplitViewDisplayMode.CompactOverlay || DisplayMode == SplitViewDisplayMode.Overlay)
            {
                IsPaneOpen = false;
            }

            Navigate(args.InvokedItem);
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            if (e != null)
            {
                var vm = NavigationService.GetNameOfRegisteredPage(e.SourcePageType);
                var navigationItem = PrimaryItems?.FirstOrDefault(i => i.ViewModelName == vm);
                if (navigationItem == null)
                {
                    navigationItem = SecondaryItems?.FirstOrDefault(i => i.ViewModelName == vm);
                }

                if (navigationItem != null)
                {
                    ChangeSelected(_lastSelectedItem, navigationItem);
                    _lastSelectedItem = navigationItem;
                }
            }
        }

        private void ChangeSelected(object oldValue, object newValue)
        {
            if (oldValue != null)
            {
                (oldValue as ShellNavigationItem).IsSelected = false;
            }

            if (newValue != null)
            {
                (newValue as ShellNavigationItem).IsSelected = true;
                Selected = newValue;
            }
        }

        private void Navigate(object item)
        {
            var navigationItem = item as ShellNavigationItem;
            if (navigationItem != null)
            {
                NavigationService.Navigate(navigationItem.ViewModelName);
            }
        }
    }
}
