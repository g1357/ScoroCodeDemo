using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ScorocodeUWP;
using ScorocodeUWP.Requests.Messages;
using ScorocodeUWP.Responses.Messages;
using ScorocodeUWP.ScorocodeObjects;
using ScoroTask.Helpers;
using ScoroTask.Services;

namespace ScoroTask.ViewModels
{
    public class MessageOperationsViewModel : ViewModelBase
    {
        public MessageOperationsViewModel()
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

        private string _scriptId;
        public string ScriptId
        {
            get { return _scriptId; }
            set { Set(ref _scriptId, value); }
        }

        //============ Send E-mail Message ============
        private RelayCommand _sendEmailCommand;
        public RelayCommand SendEmailCommand
        {
            get
            {
                if (_sendEmailCommand == null)
                {
                    _sendEmailCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestSendEmail requestSendEmail;
                        Query query = new Query("tasks");
                        query.equalTo("bossComment", "Good Job!");
                        MessageEmail msg = new MessageEmail("scorotask@yandex.ru", "test Mesage", "Hello, Friend!");

                        requestSendEmail = new RequestSendEmail(stateHolder, "tasks", query, msg);
                        ResponseCount responseCount = await sc.SendEmailAsync(requestSendEmail);

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
                return _sendEmailCommand;
            }
        }

        //============ Send Push Notification ============
        private RelayCommand _sendPushCommand;
        public RelayCommand SendPushCommand
        {
            get
            {
                if (_sendPushCommand == null)
                {
                    _sendPushCommand = new RelayCommand(async () =>
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
                        ResponseCount responseCount = await sc.SendPushAsync(requestSendPush);

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
                return _sendPushCommand;
            }
        }

        //============ Send SMS Message ============
        private RelayCommand _sendSmsCommand;
        public RelayCommand SendSmsCommand
        {
            get
            {
                if (_sendSmsCommand == null)
                {
                    _sendSmsCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestSendSms requestSendSms;
                        Query query = new Query("users");
                        MessageSms msg = new MessageSms("Test SMS message!");
                        bool debug = true;

                        requestSendSms = new RequestSendSms(stateHolder, "users", query, msg, debug);
                        ResponseCount responseCount = await sc.SendSmsAsync(requestSendSms);

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
                return _sendSmsCommand;
            }
        }

        //============ Send Script Task ============
        private RelayCommand _sendScriptyCommand;
        public RelayCommand SendScriptCommand
        {
            get
            {
                if (_sendScriptyCommand == null)
                {
                    _sendScriptyCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestSendScriptTask requestSendScriptTask;
                        Query query = new Query("tasks");
                        query.equalTo("bossComment", "Good Job!");
                        bool debug = true;
                        requestSendScriptTask = new RequestSendScriptTask(stateHolder, "tasks", query, ScriptId, debug);
                        ResponseCount responseCount = await sc.SendScriptTaskAsync(requestSendScriptTask);

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
                return _sendScriptyCommand;
            }
        }

    }
}
