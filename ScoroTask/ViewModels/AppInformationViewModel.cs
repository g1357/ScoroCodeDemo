using System;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ScorocodeUWP;
using ScorocodeUWP.Requests.Application;
using ScorocodeUWP.Requests.Messages;
using ScorocodeUWP.Responses;
using ScorocodeUWP.Responses.Application;
using ScorocodeUWP.Responses.Messages;
using ScorocodeUWP.ScorocodeObjects;
using ScoroTask.Helpers;
using ScoroTask.Services;

namespace ScoroTask.ViewModels
{
    public class AppInformationViewModel : ViewModelBase
    {
        public AppInformationViewModel()
        {
        }
        private bool _error;
        public bool Error
        {
            get { return _error; }
            set { Set(ref _error, value); }
        }
        private string _errorCode;
        public string ErrorCode
        {
            get { return _errorCode; }
            set { Set(ref _errorCode, value); }
        }
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { Set(ref _errorMessage, value); }
        }

        private string _document;
        public string Document
        {
            get { return _document; }
            set { Set(ref _document, value); }
        }

        //============ Get Application Statistic ============
        private RelayCommand _getAppStatisticCommand;
        public RelayCommand GetAppStatisticCommand
        {
            get
            {
                if (_getAppStatisticCommand == null)
                {
                    _getAppStatisticCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestStatistic requestStatistic = new RequestStatistic(stateHolder);
                        ResponseAppStatistic responseAppStatistic = await sc.GetAppStatistic(requestStatistic);

                        Error = responseAppStatistic.Error;
                        ErrorCode = responseAppStatistic.ErrCode;
                        ErrorMessage = responseAppStatistic.ErrMsg;
                        if (!Error)
                        {
                            var result = responseAppStatistic.result;
                            Document = $"dataSize: {result.dataSize}";
                            Document += $"\nfileaSize: {result.filesSize}";
                            Document += $"\nindexSize: {result.indexSize}";
                            Document += $"\nstore: {result.store}";
                        }
                    },
                    () =>
                    {
                        return true;
                    });
                }
                return _getAppStatisticCommand;
            }
        }

        //============ Get Application Information ============
        private RelayCommand _getAppInfoCommand;
        public RelayCommand GetAppInfoCommand
        {
            get
            {
                if (_getAppInfoCommand == null)
                {
                    _getAppInfoCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestAppInfo requestAppInfo = new RequestAppInfo(stateHolder);
                        ResponseAppInfo responseAppInfo = await sc.GetAppInformation(requestAppInfo);

                        Error = responseAppInfo.Error;
                        ErrorCode = responseAppInfo.ErrCode;
                        ErrorMessage = responseAppInfo.ErrMsg;
                        if (!Error)
                        {
                            Document = responseAppInfo.ToString();
                        }
                    },
                    () =>
                    {
                        return true;
                    });
                }
                return _getAppInfoCommand;
            }
        }

    }
}
