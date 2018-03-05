using System;

using GalaSoft.MvvmLight;

namespace ScoroTask.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public string ReleaseNo { get; set; } = "1.17";
        public string ReleaseDate { get; set; } = "05.03.2018";
        public MainViewModel()
        {
        }
    }
}
