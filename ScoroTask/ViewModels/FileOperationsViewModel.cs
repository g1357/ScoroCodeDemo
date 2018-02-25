using System;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ScorocodeUWP;
using ScorocodeUWP.Requests.Files;
using ScorocodeUWP.Responses;
using ScorocodeUWP.ScorocodeObjects;
using ScoroTask.Helpers;
using ScoroTask.Services;

namespace ScoroTask.ViewModels
{
    public class FileOperationsViewModel : ViewModelBase
    {
        public FileOperationsViewModel()
        {
        }

        //============ Upload File ============
        private RelayCommand _uploadCommand;
        public RelayCommand UploadCommand
        {
            get
            {
                if (_uploadCommand == null)
                {
                    _uploadCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        string collectionName = "tasks";
                        string docId = "qp8qTH9geK";
                        string fieldName = "attachment";
                        string fileName = "Test.txt";
                        string stringText = "This is a test file!";
                        byte[] byteArray = Encoding.UTF8.GetBytes(stringText);
                        string contentBase64 = Convert.ToBase64String(byteArray);

                        RequestUpload requestUpload = new RequestUpload(stateHolder, collectionName,
                            docId, fieldName, fileName, contentBase64);
                        ResponseCodes responseCodes = await sc.UploadAsync(requestUpload);

                        //Error = responseCodes.Error;
                        //ErrorCode = responseCodes.ErrCode;
                        //ErrorMessage = responseCodes.ErrMsg;
                        //if (!Error)
                        //{
                        //    string respStr = responseCodes.Result;
                        //    string text = Bson.ConvertToJson(respStr);
                        //    Document = text;
                        //}
                    },
                    () =>
                    {
                        return true;
                    });
                }
                return _uploadCommand;
            }
        }

        //============ Get File ============
        private RelayCommand _getFileCommand;
        public RelayCommand GetFileCommand
        {
            get
            {
                if (_getFileCommand == null)
                {
                    _getFileCommand = new RelayCommand(async () =>
                    {
                        var sc = new ScorocodeApi();
                        var globalData = Singleton<GlobalDataService>.Instance;
                        ScorocodeSdkStateHolder stateHolder = globalData.stateHolder;
                        string appId = stateHolder.ApplicationId;
                        string collectionName = "tasks";
                        string docId = "qp8qTH9geK";
                        string fieldName = "attachment";
                        string fileName = "Test.txt";

                        string responseString = await sc.GetFileAsync(appId, collectionName,
                            fieldName, docId, fileName);

                        //Error = responseString.Error;
                        //ErrorCode = responseString.ErrCode;
                        //ErrorMessage = responseString.ErrMsg;
                        //if (!Error)
                        //{
                        //    string respStr = responseString.Result;
                        //    string text = Bson.ConvertToJson(respStr);
                        //    Document = text;
                        //}
                    },
                    () =>
                    {
                        return true;
                    });
                }
                return _getFileCommand;
            }
        }

        //============ Request Documant ============
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
                        string collectionName = "tasks";
                        string docId = "qp8qTH9geK";
                        string fieldName = "attachment";
                        string fileName = "Test.txt";
                        RequestFile requestDeleteFile = new RequestFile(stateHolder, collectionName,
                            docId, fieldName, fileName);
                        ResponseCodes responseCodes = await sc.DeleteFileAsync(requestDeleteFile);

                        //Error = responseString.Error;
                        //ErrorCode = responseString.ErrCode;
                        //ErrorMessage = responseString.ErrMsg;
                        //if (!Error)
                        //{
                        //    string respStr = responseString.Result;
                        //    string text = Bson.ConvertToJson(respStr);
                        //    Document = text;
                        //}
                    },
                    () =>
                    {
                        return true;
                    });
                }
                return _deleteCommand;
            }
        }


    }
}
