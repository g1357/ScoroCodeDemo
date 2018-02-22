using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ScorocodeUWP;
using ScorocodeUWP.Requests;
using ScorocodeUWP.Requests.Data;
using ScorocodeUWP.Responses;
using ScorocodeUWP.Responses.Data;
using ScorocodeUWP.ScorocodeObjects;
using ScoroTask.Dialogs;
using ScoroTask.Helpers;
using ScoroTask.Services;
using Windows.UI.Xaml.Controls;

namespace ScoroTask.ViewModels
{
    public class DocumentOperationsViewModel : ViewModelBase
    {
        private string _collectionName;
        public string CollectionName
        {
            get { return _collectionName; }
            set
            {
                if (Set(ref _collectionName, value))
                {
                    CreateCommand.RaiseCanExecuteChanged();
                    CLearCommand.RaiseCanExecuteChanged();
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
            set
            {
                if (Set(ref _doc, value))
                {
                    CLearCommand.RaiseCanExecuteChanged();
                }
            }
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

        private string _document;
        public string Document
        {
            get { return _document; }
            set
            {
                if (Set(ref _document, value))
                {
                    CLearCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private RelayCommand _createCommand;
        public RelayCommand CreateCommand
        {
            get
            {
                if (_createCommand == null)
                {
                    _createCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestInsert requestInsert;

                        if (Doc.Count > 0)
                        {
                            DocumentInfo docInfo = new DocumentInfo();
                            foreach (var item in Doc)
                            {
                                docInfo.Put(item.Key, item.Value);
                            }
                            requestInsert = new RequestInsert(stateHolder,
                                CollectionName, docInfo);
                        }
                        else
                        {
                            requestInsert = new RequestInsert(stateHolder, CollectionName);
                        }
                        ResponseInsert responsInsert = await sc.InsertAsync(requestInsert);

                        Error = responsInsert.Error;
                        ErrorCode = responsInsert.ErrCode;
                        ErrorMessage = responsInsert.ErrMsg;
                        if (!Error)
                        {
                            Document = string.Empty;
                            var dictionary = responsInsert.Result;
                            foreach (var item in dictionary)
                            {
                                Document += $"{item.Key} : {item.Value}\n";
                            }
                        }
                    },
                    () =>
                    {
                        return !string.IsNullOrWhiteSpace(CollectionName);
                    });
                }
                return _createCommand;
            }
        }
        private RelayCommand _clearCommand;
        public RelayCommand CLearCommand
        {
            get
            {
                if (_clearCommand == null)
                {
                    _clearCommand = new RelayCommand(() =>
                    {
                        CollectionName = string.Empty;
                        Document = string.Empty;
                        Doc.Clear();
                        SelectedDoc = null;
                    },
                    () =>
                    {
                        return !string.IsNullOrWhiteSpace(CollectionName) ||
                            !string.IsNullOrWhiteSpace(Document) ||
                            Doc.Count > 0;
                    });
                }
                return _clearCommand;
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
                        DocLine docLine = new DocLine() { Key = "key", Value = "value" };
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

        private string _sessionId;
        public string SessionId
        {
            get { return _sessionId; }
            set
            {
                if (Set(ref _sessionId, value))
                {
                }
            }
        }
        private string _user;
        public string User
        {
            get { return _user; }
            set { Set(ref _user, value); }
        }

        //============ Delete Documant ============
        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestRemove requestRemove;
                        Dictionary<string, object> query = new Dictionary<string, object>();
                        query.Add("_id", "9CkCd3BsdO");

                        requestRemove = new RequestRemove(stateHolder, "tasks", query, 10);
                        ResponseRemove responseRemove = await sc.RemoveAsync(requestRemove);

                        Error = responseRemove.Error;
                        ErrorCode = responseRemove.ErrCode;
                        ErrorMessage = responseRemove.ErrMsg;
                        if (!Error)
                        {
                            Document = string.Empty;
                            var dictionary = responseRemove.Result.Docs;
                            foreach (var item in dictionary)
                            {
                                Document += $"_id : {item}\n";
                            }
                        }
                    },
                    () =>
                    {
                        return true;
                    });
                }
                return _deleteCommand;
            }
        }
        //============ Change Documant ============
        private RelayCommand _changeCommand;
        public RelayCommand ChangeCommand
        {
            get
            {
                if (_changeCommand == null)
                {
                    _changeCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestUpdate requestUpdate;
                        Query query = new Query("tasks");
                        query.equalTo("_id", "ynztmonusP");
                        UpdateInfo updateInfo = new UpdateInfo();
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        dic.Add("bossComment", "Do it now!");
                        updateInfo.Info.Add("$set", dic);

                        requestUpdate = new RequestUpdate(stateHolder, "tasks", query, updateInfo, 10);
                        ResponseUpdate responseUpdate = await sc.UpdateAsync(requestUpdate);

                        Error = responseUpdate.Error;
                        ErrorCode = responseUpdate.ErrCode;
                        ErrorMessage = responseUpdate.ErrMsg;
                        if (!Error)
                        {
                            Document = string.Empty;
                            var dictionary = responseUpdate.Result.Docs;
                            foreach (var item in dictionary)
                            {
                                Document += $"_id : {item}\n";
                            }
                        }
                    },
                    () =>
                    {
                        return true;
                    });
                }
                return _changeCommand;
            }
        }
        //============ Change by Id Documant ============
        private RelayCommand _changeByIdCommand;
        public RelayCommand ChangeByIdCommand
        {
            get
            {
                if (_changeByIdCommand == null)
                {
                    _changeByIdCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestRemove requestRemove;
                        Dictionary<string, object> query = new Dictionary<string, object>();
                        query.Add("_id", "9CkCd3BsdO");

                        requestRemove = new RequestRemove(stateHolder, "tasks", query, 10);
                        ResponseRemove responseRemove = await sc.RemoveAsync(requestRemove);

                        Error = responseRemove.Error;
                        ErrorCode = responseRemove.ErrCode;
                        ErrorMessage = responseRemove.ErrMsg;
                        if (!Error)
                        {
                            Document = string.Empty;
                            var dictionary = responseRemove.Result.Docs;
                            foreach (var item in dictionary)
                            {
                                Document += $"_id : {item}\n";
                            }
                        }
                    },
                    () =>
                    {
                        return true;
                    });
                }
                return _changeByIdCommand;
            }
        }
        //============ Request Documant ============
        private RelayCommand _requestCommand;
        public RelayCommand RequestCommand
        {
            get
            {
                if (_requestCommand == null)
                {
                    _requestCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestRemove requestRemove;
                        Dictionary<string, object> query = new Dictionary<string, object>();
                        query.Add("_id", "9CkCd3BsdO");

                        requestRemove = new RequestRemove(stateHolder, "tasks", query, 10);
                        ResponseRemove responseRemove = await sc.RemoveAsync(requestRemove);

                        Error = responseRemove.Error;
                        ErrorCode = responseRemove.ErrCode;
                        ErrorMessage = responseRemove.ErrMsg;
                        if (!Error)
                        {
                            Document = string.Empty;
                            var dictionary = responseRemove.Result.Docs;
                            foreach (var item in dictionary)
                            {
                                Document += $"_id : {item}\n";
                            }
                        }
                    },
                    () =>
                    {
                        return true;
                    });
                }
                return _requestCommand;
            }
        }
        //============ Request of Quantity Documant ============
        private RelayCommand _requestQtyCommand;
        public RelayCommand RequestQtyCommand
        {
            get
            {
                if (_requestQtyCommand == null)
                {
                    _requestQtyCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestRemove requestRemove;
                        Dictionary<string, object> query = new Dictionary<string, object>();
                        query.Add("_id", "9CkCd3BsdO");

                        requestRemove = new RequestRemove(stateHolder, "tasks", query, 10);
                        ResponseRemove responseRemove = await sc.RemoveAsync(requestRemove);

                        Error = responseRemove.Error;
                        ErrorCode = responseRemove.ErrCode;
                        ErrorMessage = responseRemove.ErrMsg;
                        if (!Error)
                        {
                            Document = string.Empty;
                            var dictionary = responseRemove.Result.Docs;
                            foreach (var item in dictionary)
                            {
                                Document += $"_id : {item}\n";
                            }
                        }
                    },
                    () =>
                    {
                        return true;
                    });
                }
                return _requestQtyCommand;
            }
        }

    }
}
