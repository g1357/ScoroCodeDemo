using Newtonsoft.Json;
using ScoroTask.Models;
using System;
using System.Net.Http.Headers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Windows.Web.Http;
using Windows.Web.Http.Headers;

using ScorocodeUWP;
using ScorocodeUWP.Requests;
using ScorocodeUWP.ScorocodeObjects;
using ScorocodeUWP.Responses;

namespace ScoroTask.ViewModels
{
    public class BlankViewModel : ViewModelBase
    {
        public BlankViewModel()
        {
        }

        ScorocodeSdkStateHolder stateHolder = new ScorocodeSdkStateHolder(
            /* applicationId */ "228730d6c20044fc85f8a5c8b015e0e7",
            /* clientKey */ "b93d0e6f7f0e4c18955f580c082345cc",
            /* masterKey */ "01db6a43743e4492a7bdef1a3be3a395",
            /* fileKey */ "deb3d951109d43069baba7b8e5424442",
            /* messageKey */ "80704b44194f4e1282986e5d68942848",
            /* scriptKey */ "c27ad4e97a784072b029dd02f68c347c",
            /* websocketKey */ "7b1966691002464e92066b2693135236");

        private string _log;
        public string Log
        {
            get  {  return _log; }
            set  { Set(ref _log, value); }
        }
        private RelayCommand _startCommand;
        public RelayCommand StartCommand 
        {
            get
            {
                if (_startCommand == null)
                {
                    _startCommand = new RelayCommand(StartCommandExecute);
                }
                return _startCommand;
            }
        }

        private RelayCommand _postCommand;
        public RelayCommand PostCommand
        {
            get
            {
                if (_postCommand == null)
                {
                    _postCommand = new RelayCommand(PostCommandExecute);
                }
                return _postCommand;
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
                        Log = "Login command:\n";

                        var sc = new ScorocodeApi();
                        RequestLoginUser requestLoginUsers = new RequestLoginUser(stateHolder, "dukar7@yabdex.ru", "moscow");

                        ResponseLogin responsLogin = await sc.LoginAsync(requestLoginUsers);

                        stateHolder.SessionId = responsLogin.result.SessionId;

                        Log += $"\n\nError:\t{responsLogin.Error}";
                        Log += $"\nErrCode:\t{responsLogin.ErrCode}";
                        Log += $"\nErrMsg:\t{responsLogin.ErrMsg}";
                        Log += $"\nSessionId:\t{responsLogin.result.SessionId}";
                        Log += $"\nUser:\n";
                        foreach (var item in responsLogin.result.User)
                        {
                            Log += $"\n{item.Key}:\t{item.Value}";
                        }
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
                        Log = "Logout command:\n";
                        Log += $"SessionId: {stateHolder.SessionId}";

                        var sc = new ScorocodeApi();
                        RequestLogoutUser requestLogoutUser = new RequestLogoutUser(stateHolder);

                        ResponseCodes responsCodes = await sc.LogoutAsync(requestLogoutUser);
                        Log += $"\n\nError:\t{responsCodes.Error}";
                        Log += $"\nErrCode:\t{responsCodes.ErrCode}";
                        Log += $"\nErrMsg:\t{responsCodes.ErrMsg}";
                    });
                }
                return _logoutCommand;
            }
        }

        private async void StartCommandExecute()
        {
            Log = "Button clicked!";

            //var uri = new Uri("https://api.scorocode.ru/api/v1/app");
            //string jsonString = "{ \"acc\": \"01db6a43743e4492a7bdef1a3be3a395\", " // ключ доступа, только masterKey
            //                    + "\"app\": \"228730d6c20044fc85f8a5c8b015e0e7\", " // идентификатор приложения
            //                    + "\"cli\": \"b93d0e6f7f0e4c18955f580c082345cc\" }";// клиентский ключ
            //var content = new HttpStringContent(jsonString, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");
            //var httpClient = new HttpClient();
            ////httpClient.DefaultRequestHeaders.Clear();
            ////httpClient.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
            ////httpClient.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("text/javascript"));

            //var response = await httpClient.PostAsync(uri, content);

            //Log += $"\n\nStatus Code: {response.StatusCode}";
            ////Log += $"\n\n{response.Content}";

            //Models.Example example;

            ////var serializer = new DataContractJsonSerializer(typeof(Example));
            ////example = (Example) serializer

            //example = JsonConvert.DeserializeObject<Models.Example>(response.Content.ToString());

            var sc = new ScorocodeApi();
            //tring applicationId, String clientKey, String masterKey,
            //String fileKey, String messageKey, String scriptKey, String webSocket
            ScorocodeSdkStateHolder stateHolder = new ScorocodeSdkStateHolder(
                /* applicationId */ "228730d6c20044fc85f8a5c8b015e0e7",
                /* clientKey */ "b93d0e6f7f0e4c18955f580c082345cc",
                /* masterKey */ "01db6a43743e4492a7bdef1a3be3a395",
                /* fileKey */ "deb3d951109d43069baba7b8e5424442",
                /* messageKey */ "80704b44194f4e1282986e5d68942848",
                /* scriptKey */ "c27ad4e97a784072b029dd02f68c347c",
                /* websocketKey */ "7b1966691002464e92066b2693135236");
            RequestRegisterUser requestRegisterUsers = new RequestRegisterUser(stateHolder, "Dukar", "dukar7@yabdex.ru", "moscow");

            ResponseCodes responsCodes = await sc.RegisterAsync(requestRegisterUsers);
            Log += $"\n\nError:\t{responsCodes.Error}";
            Log += $"\nErrCode:\t{responsCodes.ErrCode}";
            Log += $"\nErrMsg:\t{responsCodes.ErrMsg}";

        }

        private async void PostCommandExecute()
        {
            Log = "POST Command: \n";

            string jsonContent = "{\"app\":\"228730d6c20044fc85f8a5c8b015e0e7\"," +
                "\"cli\":\"b93d0e6f7f0e4c18955f580c082345cc\"," +
                "\"acc\":\"01db6a43743e4492a7bdef1a3be3a395\"," +
                "\"username\":\"Dukar\"," +
                "\"email\":\"dukar7@yabdex.ru\"," +
                "\"password\":\"moscow\"," +
                "\"doc\":{}}";
            Uri uri = new Uri("https://api.scorocode.ru/api/v1/register");
            HttpStringContent httpContent = new HttpStringContent(jsonContent, Windows.Storage.Streams.UnicodeEncoding.Utf8,
                "application/json");
            HttpClient httpClient = new HttpClient();

            var httpResponse = await httpClient.PostAsync(uri, httpContent);

            Log += $"\n\nStatus Code: {httpResponse.StatusCode}";
            Log += $"\n\n{httpResponse.Content}";
        }

    }
}
