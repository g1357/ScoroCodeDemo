using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ScorocodeUWP;
using ScorocodeUWP.Requests.Collections;
using ScorocodeUWP.Requests.Fields;
using ScorocodeUWP.Requests.Indexes;
using ScorocodeUWP.Responses;
using ScorocodeUWP.Responses.Collections;
using ScorocodeUWP.Responses.Fields;
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
            set
            {
                if (Set(ref _collName, value))
                {
                    CreateCollectionIndexCommand.RaiseCanExecuteChanged();
                    DeleteCollectionIndexCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _collId;
        public string CollId
        {
            get { return _collId; }
            set { Set(ref _collId, value); }
        }

        private string _fieldName;
        public string FieldName
        {
            get { return _fieldName; }
            set { Set(ref _fieldName, value); }
        }

        private string _indexFieldName1;
        public string IndexFieldName1
        {
            get { return _indexFieldName1; }
            set { Set(ref _indexFieldName1, value); }
        }

        private bool _index1Order;
        public bool Index1Order
        {
            get { return _index1Order; }
            set { Set(ref _index1Order, value); }
        }

        private string _indexFieldName2;
        public string IndexFieldName2
        {
            get { return _indexFieldName2; }
            set
            {
                if (Set(ref _indexFieldName2, value))
                    CreateCollectionIndexCommand.RaiseCanExecuteChanged();
            }
        }

        private bool _index2Order;
        public bool Index2Order
        {
            get { return _index2Order; }
            set { Set(ref _index2Order, value); }
        }

        private string _indexName;
        public string IndexName
        {
            get { return _indexName; }
            set
            {
                if (Set(ref _indexName, value))
                {
                    CreateCollectionIndexCommand.RaiseCanExecuteChanged();
                    DeleteCollectionIndexCommand.RaiseCanExecuteChanged();
                }
            }
        }


        public void PivotItemSelectionChange()
        {
            Error = false;
            ErrorCode = "";
            ErrorMessage = "";
            Document = "";
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
                        ResponseGetCollectionsList responseAppStatistic = await sc.GetCollectionsListAsync(requestCollectionsList);

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
                        RequestChangeCollectionTrigers requestCollectionByName = new RequestChangeCollectionTrigers(stateHolder, CollName);
                        ResponseChangeCollectionTrigers responseCollection = await sc.GetCollectionByNameAsync(requestCollectionByName);

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

        //============ Create Collection  ============
        private RelayCommand _createCollectionCommand;
        public RelayCommand CreateCollectionCommand
        {
            get
            {
                if (_createCollectionCommand == null)
                {
                    _createCollectionCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestCreateCollection requestCreateCollection = new RequestCreateCollection(stateHolder, CollName,
                            false, new ScorocodeACL());
                        ResponseChangeCollectionTrigers responseCollection = await sc.CreateCollectionAync(requestCreateCollection);

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
                return _createCollectionCommand;
            }
        }

        //============ Update Collection Settings ============
        private RelayCommand _updateCollectionCommand;
        public RelayCommand UpdateCollectionCommand
        {
            get
            {
                if (_updateCollectionCommand == null)
                {
                    _updateCollectionCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestUpdateCollection requestUpdateCollection = new RequestUpdateCollection(stateHolder,
                            CollId, CollName, false, new ScorocodeACL(), false);
                        ResponseChangeCollectionTrigers responseCollection = await sc.UpdateCollectionAsync(requestUpdateCollection);

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
                return _updateCollectionCommand;
            }
        }

        //============ Delete Collection ============
        private RelayCommand _deleteCollectionCommand;
        public RelayCommand DeleteCollectionCommand
        {
            get
            {
                if (_deleteCollectionCommand == null)
                {
                    _deleteCollectionCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestDeleteCollection requestDeleteCollection = new RequestDeleteCollection(stateHolder, CollId);
                        ResponseCodes responseCodes = await sc.DeleteCollectionAsync(requestDeleteCollection);

                        Error = responseCodes.Error;
                        ErrorCode = responseCodes.ErrCode;
                        ErrorMessage = responseCodes.ErrMsg;
                    },
                    () =>
                    {
                        return true;
                    });
                }
                return _deleteCollectionCommand;
            }
        }

        //============ Clone Collection ============
        private RelayCommand _cloneCollectionCommand;
        public RelayCommand CloneCollectionCommand
        {
            get
            {
                if (_cloneCollectionCommand == null)
                {
                    _cloneCollectionCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestCloneCollection requestCloneCollection = new RequestCloneCollection(stateHolder, CollId, CollName);
                        ResponseChangeCollectionTrigers responseCollection = await sc.CloneCollectionAsync(requestCloneCollection);

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
                return _cloneCollectionCommand;
            }
        }

        //============ Create Collection Index ============
        private RelayCommand _createCollectionIndexCommand;
        public RelayCommand CreateCollectionIndexCommand
        {
            get
            {
                if (_createCollectionIndexCommand == null)
                {
                    _createCollectionIndexCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        List<IndexField> indexFields = new List<IndexField>();
                        indexFields.Add(new IndexField(IndexFieldName1, Index1Order ? 1 : -1));
                        if (!string.IsNullOrEmpty(IndexFieldName2))
                            indexFields.Add(new IndexField(IndexFieldName2, Index2Order ? 1 : -1));
                        Index index = new Index(IndexName, indexFields);
                        RequestCreateCollectionIndex requestCreateCollectionIndex = new RequestCreateCollectionIndex(stateHolder, CollName, index);
                        ResponseCodes responseCodes = await sc.CreateCollectionIndexAsync(requestCreateCollectionIndex);

                        Error = responseCodes.Error;
                        ErrorCode = responseCodes.ErrCode;
                        ErrorMessage = responseCodes.ErrMsg;
                    },
                    () =>
                    {
                        return !string.IsNullOrEmpty(CollName)
                            && !string.IsNullOrEmpty(IndexName)
                            && !string.IsNullOrEmpty(IndexFieldName1);
                    });
                }
                return _createCollectionIndexCommand;
            }
        }

        //============ Delete Collection Index ============
        private RelayCommand _deleteCollectionIndexCommand;
        public RelayCommand DeleteCollectionIndexCommand
        {
            get
            {
                if (_deleteCollectionIndexCommand == null)
                {
                    _deleteCollectionIndexCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestDeleteCollectionIndex requestDeleteCollectionIndex = new RequestDeleteCollectionIndex(stateHolder, CollName, IndexName);
                        ResponseCodes responseCodes = await sc.DeleteCollectionIndexAsync(requestDeleteCollectionIndex);

                        Error = responseCodes.Error;
                        ErrorCode = responseCodes.ErrCode;
                        ErrorMessage = responseCodes.ErrMsg;
                    },
                    () =>
                    {
                        return !string.IsNullOrEmpty(CollName)
                            && !string.IsNullOrEmpty(IndexName);
                    });
                }
                return _deleteCollectionIndexCommand;
            }
        }

        //============ Change Collection Triggers ============
        private RelayCommand _changeCollectionTriggersCommand;
        public RelayCommand ChangeCollectionTriggersCommand
        {
            get
            {
                if (_changeCollectionTriggersCommand == null)
                {
                    _changeCollectionTriggersCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        ScorocodeTriggers scorocodeTriggers = new ScorocodeTriggers();
                        scorocodeTriggers.setBeforeInsert(new Trigger("return true;", false));
                        RequestChangeCollectionTriggers requestChangeCollectionTriggers = new RequestChangeCollectionTriggers(stateHolder, CollName, scorocodeTriggers);
                        ResponseChangeCollectionTriggers responseChangeCollectionTriggers = await sc.ChangeCollectionTriggersAsync(requestChangeCollectionTriggers);

                        Error = responseChangeCollectionTriggers.Error;
                        ErrorCode = responseChangeCollectionTriggers.ErrCode;
                        ErrorMessage = responseChangeCollectionTriggers.ErrMsg;
                        if (!Error)
                        {
                            var triggers = responseChangeCollectionTriggers.Triggers;
                            Document = "Triggers:";
                            Document += $"\n\t beforeInsert:\t{triggers.getBeforeInsert().Code} IsActive: {triggers.getBeforeInsert().IsActive}";
                            Document += $"\n\t afterInsert:\t{triggers.getAfterInsert().Code} IsActive: {triggers.getAfterInsert().IsActive}";
                            Document += $"\n\t beforeUpdate:\t{triggers.getBeforeUpdate().Code} IsActive: {triggers.getBeforeUpdate().IsActive}";
                            Document += $"\n\t afterUpdate:\t{triggers.getAfterUpdate().Code} IsActive: {triggers.getAfterUpdate().IsActive}";
                            Document += $"\n\t beforeRemove:\t{triggers.getBeforeRemove().Code} IsActive: {triggers.getBeforeRemove().IsActive}";
                            Document += $"\n\t afterRemove:\t{triggers.getAfterRemove().Code} IsActive: {triggers.getAfterRemove().IsActive}";
                            Document += $"\n\t beforeFind:\t{triggers.getBeforeFind().Code} IsActive: {triggers.getBeforeFind().IsActive}";
                        }
                    },
                    () =>
                    {
                        return true;
                    });
                }
                return _changeCollectionTriggersCommand;
            }
        }

        //============ Add Field to Collection ============
        private RelayCommand _addFieldToCollectionCommand;
        public RelayCommand AddFieldToCollectionCommand
        {
            get
            {
                if (_addFieldToCollectionCommand == null)
                {
                    _addFieldToCollectionCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        ScorocodeField field = new ScorocodeField(FieldName,
                            ScorocodeTypes.TypeString, "", false, false, false);
                        RequestCreateField requestCreateField = new RequestCreateField(stateHolder, CollName, field);
                        ResponseAddField responseAddField = await sc.AddFieldToCollectionAsync(requestCreateField);

                        Error = responseAddField.Error;
                        ErrorCode = responseAddField.ErrCode;
                        ErrorMessage = responseAddField.ErrMsg;
                        if (!Error)
                        {
                            var fld = responseAddField.Field;
                            Document = "Field:";
                            Document += $"\n\tName:\t{fld.getFieldName()}";
                            Document += $"\n\tType:\t{fld.getFieldType()}";
                            Document += $"\n\tTarget:\t{fld.getTarget()}";
                        }
                    },
                    () =>
                    {
                        return true;
                    });
                }
                return _addFieldToCollectionCommand;
            }
        }

        //============ Delete Field from Collection ============
        private RelayCommand _deleteFieldFromCollectionCommand;
        public RelayCommand DeleteFieldFromCollectionCommand
        {
            get
            {
                if (_deleteFieldFromCollectionCommand == null)
                {
                    _deleteFieldFromCollectionCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestDeleteField requestDeleteField = new RequestDeleteField(stateHolder, CollName, FieldName);
                        ResponseChangeCollectionTrigers responseCollection = await sc.DeleteFieldFromCollectionAsync(requestDeleteField);

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
                return _deleteFieldFromCollectionCommand;
            }
        }

    }
}
