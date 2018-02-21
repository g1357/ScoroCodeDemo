using System;
using System.Collections.ObjectModel;

using GalaSoft.MvvmLight;

using ScoroTask.Models;
using ScoroTask.Services;

namespace ScoroTask.ViewModels
{
    public class GridViewModel : ViewModelBase
    {
        public ObservableCollection<SampleOrder> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return SampleDataService.GetGridSampleData();
            }
        }
    }
}
