using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ScorocodeUWP;
using ScorocodeUWP.Requests;
using ScorocodeUWP.Responses;
using ScorocodeUWP.ScorocodeObjects;
using ScoroTask.Dialogs;
using ScoroTask.Helpers;
using ScoroTask.Services;
using Windows.UI.Xaml.Controls;

namespace ScoroTask.ViewModels
{
    public class UserOperationsViewModel : ViewModelBase
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (Set(ref _userName, value))
                {
                    RegisterCommand.RaiseCanExecuteChanged();
                };
            }
        }
        private string _eMail;
        public string EMail
        {
            get { return _eMail; }
            set
            {
                if (Set(ref _eMail, value))
                {
                    RegisterCommand.RaiseCanExecuteChanged();
                    LoginCommand.RaiseCanExecuteChanged();
                    LogoutCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (Set(ref _password, value))
                {
                    RegisterCommand.RaiseCanExecuteChanged();
                    LoginCommand.RaiseCanExecuteChanged();
                    LogoutCommand.RaiseCanExecuteChanged();
                };
            }
        }

        public class DocLine
        {
            public string Key { get; set; }
            public string Value { get; set; } 
        }
        private ObservableCollection<DocLine> _doc = new ObservableCollection<DocLine>();
        public ObservableCollection<DocLine> Doc
        {
            get { return _doc; }
            set { Set(ref _doc, value); }
        }

        private DocLine _selectedDoc;
        public DocLine SelectedDoc
        {
            get { return _selectedDoc; }
            set { Set(ref _selectedDoc, value); }
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

        private RelayCommand _registerCommand;
        public RelayCommand RegisterCommand
        {
            get
            {
                if (_registerCommand == null)
                {
                    _registerCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestRegisterUser requestRegisterUsers;

                        if (Doc.Count > 0)
                        {
                            DocumentInfo docInfo = new DocumentInfo();
                            foreach (var item in Doc)
                            {
                                docInfo.Put(item.Key, item.Value);
                            }
                            requestRegisterUsers = new RequestRegisterUser(stateHolder,
                                UserName, EMail, Password, docInfo);
                        }
                        else
                        {
                            requestRegisterUsers = new RequestRegisterUser(stateHolder,
                                UserName, EMail, Password);
                        }
                        ResponseCodes responsCodes = await sc.RegisterAsync(requestRegisterUsers);

                        Error = responsCodes.Error;
                        ErrorCode = responsCodes.ErrCode;
                        ErrorMessage = responsCodes.ErrMsg;
                    },
                    () =>
                        {
                            return !string.IsNullOrWhiteSpace(UserName) &&
                                !string.IsNullOrWhiteSpace(EMail) &&
                                !string.IsNullOrWhiteSpace(Password);
                        });
                }
                return _registerCommand;
            }
        }

        private RelayCommand _addRecord;
        public RelayCommand AddRecord
        {
            get
            {
                if (_addRecord == null)
                {
                    _addRecord = new RelayCommand(async () =>
                    {
                        DocLine docLine = new DocLine() { Key = "key", Value = "value"};
                        CustomFieldDialog custFieldDlg = new CustomFieldDialog()
                        {
                            Title = "Введите имя и значение пользовательского поля",
                            CloseButtonText = "Сохранить",
                            PrimaryButtonText = "Отменить",
                            SecondaryButtonText = ""
                        };
                        custFieldDlg.DataContext = docLine;
                        ContentDialogResult result = await custFieldDlg.ShowAsync();
                        switch (result)
                        {
                            case ContentDialogResult.None:
                                    Doc.Add(docLine); // new DocLine() { Key = "CustomField", Value = "Custom Field Value" });
                                    RaisePropertyChanged("Doc");
                                break;
                            case ContentDialogResult.Primary:
                                break;
                            case ContentDialogResult.Secondary:
                                break;
                        }
                    });
                }
                return _addRecord;
            }
        }

        private RelayCommand _deleteRecord;
        public RelayCommand DeleteRecord
        {
            get
            {
                if (_deleteRecord == null)
                {
                    _deleteRecord = new RelayCommand(() =>
                    {
                        Doc.Remove(SelectedDoc);
                        SelectedDoc = null;
                        RaisePropertyChanged("Doc");
                    },
                    () =>
                    {
                        return (SelectedDoc != null);
                    });
                }
                return _deleteRecord;
            }
        }
        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestLoginUser requestLoginUsers = new RequestLoginUser(stateHolder,
                            EMail, Password);
                        ResponseLogin responseLogin = await sc.LoginAsync(requestLoginUsers);

                        Error = responseLogin.Error;
                        ErrorCode = responseLogin.ErrCode;
                        ErrorMessage = responseLogin.ErrMsg;
                        if (!Error)
                        {
                            SessionId = responseLogin.result.SessionId;
                            stateHolder.SessionId = SessionId;
                            User = string.Empty;
                            var dictionary = responseLogin.result.User;
                            foreach (var item in dictionary)
                            {
                                User += $"{item.Key} : {item.Value}\n";
                            }
                        }
                    },
                    () =>
                    {
                        return !string.IsNullOrWhiteSpace(EMail) &&
                            !string.IsNullOrWhiteSpace(Password);
                    });
                }
                return _loginCommand;
            }
        }
        private RelayCommand _logoutCommand;
        public RelayCommand LogoutCommand
        {
            get
            {
                if (_logoutCommand == null)
                {
                    _logoutCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestLogoutUser requestLogoutUsers = new RequestLogoutUser(stateHolder);
                        ResponseCodes responseCodes = await sc.LogoutAsync(requestLogoutUsers);

                        Error = responseCodes.Error;
                        ErrorCode = responseCodes.ErrCode;
                        ErrorMessage = responseCodes.ErrMsg;
                        if (!Error)
                        {
                            stateHolder.SessionId = string.Empty;
                            SessionId = string.Empty;
                        }
                        User = string.Empty;
                    },
                    () =>
                    {
                        return !string.IsNullOrWhiteSpace(SessionId);
                    });
                }
                return _logoutCommand;
            }
        }
        private string _sessionId;
        public string SessionId
        {
            get { return _sessionId; }
            set
            {
                if (Set(ref _sessionId, value))
                {
                    LogoutCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private string _user;
        public string User
        {
            get { return _user; }
            set { Set(ref _user, value); }
        }

        public UserOperationsViewModel()
        {
        }
    }
}
