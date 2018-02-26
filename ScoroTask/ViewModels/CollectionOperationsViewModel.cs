using System;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ScorocodeUWP;
using ScorocodeUWP.Requests.Collections;
using ScorocodeUWP.Responses.Collections;
using ScorocodeUWP.ScorocodeObjects;
using ScoroTask.Helpers;
using ScoroTask.Services;

namespace ScoroTask.ViewModels
{
    public class CollectionOperationsViewModel : ViewModelBase
    {
        public CollectionOperationsViewModel()
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
        private string _collName = "tasks";
        public string CollName
        {
            get { return _collName; }
            set { Set(ref _collName, value); }
        }

        //============ Get Collection List ============
        private RelayCommand _getCollectionListCommand;
        public RelayCommand GetCollectionListCommand
        {
            get
            {
                if (_getCollectionListCommand == null)
                {
                    _getCollectionListCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestCollectionsList requestCollectionsList = new RequestCollectionsList(stateHolder);
                        ResponseGetCollectionsList responseAppStatistic = await sc.GetCollectionsList(requestCollectionsList);

                        Error = responseAppStatistic.Error;
                        ErrorCode = responseAppStatistic.ErrCode;
                        ErrorMessage = responseAppStatistic.ErrMsg;
                        if (!Error)
                        {
                            var colls = responseAppStatistic.GetCollections();
                            Document = $"Collections: {colls.Count}";
                            foreach (var item in colls)
                            {
                                Document += $"\n\tname: {item.CollectionName}";
                                Document += $"\t_id: {item.CollectionId}";
                            }
                        }
                    },
                    () =>
                    {
                        return true;
                    });
                }
                return _getCollectionListCommand;
            }
        }

        //============ Get Collection By Name ============
        private RelayCommand _getCollByNameCommand;
        public RelayCommand GetCollByNameCommand
        {
            get
            {
                if (_getCollByNameCommand == null)
                {
                    _getCollByNameCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestCollectionByName requestCollectionByName = new RequestCollectionByName(stateHolder, CollName);
                        ResponseCollection responseCollection = await sc.GetCollectionByName(requestCollectionByName);

                        Error = responseCollection.Error;
                        ErrorCode = responseCollection.ErrCode;
                        ErrorMessage = responseCollection.ErrMsg;
                        if (!Error)
                        {
                            var coll = responseCollection.Collection;
                            Document = "Collection:";
                            Document += $"\n\tName:\t{coll.CollectionName}";
                            Document += $"\n\t_id:\t{coll.CollectionId}";
                            Document += $"\n\tFields:";
                            foreach (var item in coll.Fields)
                            {
                                Document += $"\n\t\t{item.getFieldName()} \t ({item.getFieldType()})";
                            }
                        }
                    },
                    () =>
                    {
                        return true;
                    });
                }
                return _getCollByNameCommand;
            }
        }

    }
}
