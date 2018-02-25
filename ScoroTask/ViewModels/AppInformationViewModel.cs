using System;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ScorocodeUWP;
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
                        RequestSendEmail requestSendEmail;
                        Query query = new Query("tasks");
                        query.equalTo("bossComment", "Good Job!");
                        MessageEmail msg = new MessageEmail("scorotask@yandex.ru", "test Mesage", "Hello, Friend!");

                        requestSendEmail = new RequestSendEmail(stateHolder, "tasks", query, msg);
                        ResponseCount responseCount = await sc.GetAppStatistic(requestSendEmail);

                        Error = responseCount.Error;
                        ErrorCode = responseCount.ErrCode;
                        ErrorMessage = responseCount.ErrMsg;
                        if (!Error)
                        {
                            Document = responseCount.count.ToString();
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
                        RequestSendPush requestSendPush;
                        Query query = new Query("users");
                        Dictionary<string, object> data = new Dictionary<string, object>();

                        MessagePush msg = new MessagePush("Test Push Notification", data);
                        bool debug = true;

                        requestSendPush = new RequestSendPush(stateHolder, "users", query, msg, debug);
                        ResponseCount responseCount = await sc.G(requestSendPush);

                        Error = responseCount.Error;
                        ErrorCode = responseCount.ErrCode;
                        ErrorMessage = responseCount.ErrMsg;
                        if (!Error)
                        {
                            Document = responseCount.count.ToString();
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
