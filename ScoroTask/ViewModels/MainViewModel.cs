using System;

using GalaSoft.MvvmLight;

namespace ScoroTask.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public string ReleaseDate { get; set; } = "13.02.2018";
        public MainViewModel()
        {
        }
    }
}
