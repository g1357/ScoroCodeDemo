using System;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ScorocodeUWP;
using ScorocodeUWP.Requests.Folders;
using ScorocodeUWP.Responses;
using ScorocodeUWP.Responses.Folders;
using ScorocodeUWP.ScorocodeObjects;
using ScoroTask.Helpers;
using ScoroTask.Services;

namespace ScoroTask.ViewModels
{
    public class FolderOperationsViewModel : ViewModelBase
    {
        public FolderOperationsViewModel()
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

        private string _path;
        public string Path
        {
            get { return _path; }
            set { Set(ref _path, value); }
        }

        private string _document;
        public string Document
        {
            get { return _document; }
            set { Set(ref _document, value); }
        }

        public void PivotItemSelectionChange()
        {
            Error = false;
            ErrorCode = "";
            ErrorMessage = "";
            Document = "";
        }

        //============ Get Folders List ============
        private RelayCommand _getFolderListCommand;
        public RelayCommand GetFolderListCommand
        {
            get
            {
                if (_getFolderListCommand == null)
                {
                    _getFolderListCommand = new RelayCommand(async () =>
                    {
                        Document = "";
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestFoldersList requestFoldersList = new RequestFoldersList(stateHolder, Path);
                        ResponseGetFoldersList responseGetFoldersList = await sc.GetFoldersListAsync(requestFoldersList);

                        Error = responseGetFoldersList.Error;
                        ErrorCode = responseGetFoldersList.ErrCode;
                        ErrorMessage = responseGetFoldersList.ErrMsg;
                        if (!Error)
                        {
                            var folders = responseGetFoldersList.getFolders();
                            Document = $"Folders: {folders.Count}";
                            foreach (var item in folders)
                            {
                                Document += $"\n\t id: {item.getFolderId()}";
                                Document += $"\t name: {item.getFolderName()}";
                                Document += $"\t path: {item.getFolderPath()}";
                                Document += $"\t containScript_id: {item.isFolderContainScript()}";
                            }
                        }
                    },
                    () =>
                    {
                        return true;
                    });
                }
                return _getFolderListCommand;
            }
        }

        //============ Create new Folder ============
        private RelayCommand _createNewFolderCommand;
        public RelayCommand CreateNewFolderCommand
        {
            get
            {
                if (_createNewFolderCommand == null)
                {
                    _createNewFolderCommand = new RelayCommand(async () =>
                    {
                        Document = "";
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestCreateNewFolder requestCreateNewFolder = new RequestCreateNewFolder(stateHolder, Path);
                        ResponseCodes responseCodes = await sc.CreateNewFolderAsync(requestCreateNewFolder);

                        Error = responseCodes.Error;
                        ErrorCode = responseCodes.ErrCode;
                        ErrorMessage = responseCodes.ErrMsg;
                    },
                    () =>
                    {
                        return true;
                    });
                }
                return _createNewFolderCommand;
            }
        }

        //============ Delete Folder ============
        private RelayCommand _deleteFolderCommand;
        public RelayCommand DeleteFolderCommand
        {
            get
            {
                if (_deleteFolderCommand == null)
                {
                    _deleteFolderCommand = new RelayCommand(async () =>
                    {
                        Document = "";
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        RequestDeleteFolder requestDeleteFolder = new RequestDeleteFolder(stateHolder, Path);
                        ResponseCodes responseCodes = await sc.DeleteFolderAsync(requestDeleteFolder);

                        Error = responseCodes.Error;
                        ErrorCode = responseCodes.ErrCode;
                        ErrorMessage = responseCodes.ErrMsg;
                    },
                    () =>
                    {
                        return true;
                    });
                }
                return _deleteFolderCommand;
            }
        }

    }
}
