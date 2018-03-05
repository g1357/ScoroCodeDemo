using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ScorocodeUWP.Requests;
using ScorocodeUWP.Requests.Application;
using ScorocodeUWP.Requests.Bots;
using ScorocodeUWP.Requests.Collections;
using ScorocodeUWP.Requests.Data;
using ScorocodeUWP.Requests.Fields;
using ScorocodeUWP.Requests.Files;
using ScorocodeUWP.Requests.Folders;
using ScorocodeUWP.Requests.Indexes;
using ScorocodeUWP.Requests.Messages;
using ScorocodeUWP.Requests.Scripts;
using ScorocodeUWP.Responses;
using ScorocodeUWP.Responses.Application;
using ScorocodeUWP.Responses.Bots;
using ScorocodeUWP.Responses.Collections;
using ScorocodeUWP.Responses.Data;
using ScorocodeUWP.Responses.Fields;
using ScorocodeUWP.Responses.Folders;
using ScorocodeUWP.Responses.Messages;
using ScorocodeUWP.Responses.Scripts;
using ScorocodeUWP.ScorocodeObjects;
using ScorocodeUWP.WebApi;
using Windows.Web.Http;

namespace ScorocodeUWP
{
    public class ScorocodeApi
    {
        WebApiCommand cmd = new WebApiCommand();
        string baseUri = @"https://api.scorocode.ru/";

        //====== Sign-up, sign-in methods - Методы работы с пользователями ======

        // @Headers({ "Content-Type: application/json"})
        // @POST("api/v1/register")
        // Call<ResponseCodes> register(@Body RequestRegisterUser requestRegisterUser);
        public async Task<ResponseCodes> RegisterAsync(RequestRegisterUser requestRegisterUser)
        {
            var uri = new Uri(baseUri + @"api/v1/register");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestRegisterUser);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            //var task = cmd.PostAsync(uri, jsonContent);
            //task.Wait();
            //HttpResponseMessage httpResponse = task.Result;

            ResponseCodes responseCodes = new ResponseCodes();
            if (httpResponse.IsSuccessStatusCode)
            {
                responseCodes = JsonConvert.DeserializeObject<ResponseCodes>(httpResponse.Content.ToString());
            }
            else
            {
                responseCodes.Error = true;
                responseCodes.ErrCode = "";
                responseCodes.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCodes;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/login")
        //Call<ResponseLogin> login(@Body RequestLoginUser requestLoginUser);
        public async Task<ResponseLogin> LoginAsync(RequestLoginUser requestLoginUser)
        {
            var uri = new Uri(baseUri + @"api/v1/login");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestLoginUser);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            //var task = cmd.PostAsync(uri, jsonContent);
            //task.Wait();
            //HttpResponseMessage httpResponse = task.Result;

            ResponseLogin responseLogin = new ResponseLogin();
            if (httpResponse.IsSuccessStatusCode)
            {
                responseLogin = JsonConvert.DeserializeObject<ResponseLogin>(httpResponse.Content.ToString());
            }
            else
            {
                responseLogin.Error = true;
                responseLogin.ErrCode = "";
                responseLogin.ErrMsg = "Ошибка HttpClient.";
            }

            return responseLogin;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/logout")
        //Call<ResponseCodes> logout(@Body RequestLogoutUser requestLogoutUser);
        public async Task<ResponseCodes> LogoutAsync(RequestLogoutUser requestLogoutUser)
        {
            var uri = new Uri(baseUri + @"api/v1/logout");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestLogoutUser);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);

            ResponseCodes responseCodes = new ResponseCodes();
            if (httpResponse.IsSuccessStatusCode)
            {
                responseCodes = JsonConvert.DeserializeObject<ResponseCodes>(httpResponse.Content.ToString());
            }
            else
            {
                responseCodes.Error = true;
                responseCodes.ErrCode = "";
                responseCodes.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCodes;
        }

        //====== Data methods - Методы работы с документами коллекции ======

        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/data/insert")
        //Call<ResponseInsert> insert(@Body RequestInsert requestInsert);

        /// <summary>
        /// Создание нового документа коллекции
        /// </summary>
        /// <param name="requestInsert">Параметры создаваемого документа</param>
        /// <returns>Резулитаты создания документа</returns>
        public async Task<ResponseInsert> InsertAsync(RequestInsert requestInsert)
        {
            var uri = new Uri(baseUri + @"api/v1/data/insert");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestInsert);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);

            ResponseInsert responseInsert = new ResponseInsert();
            if (httpResponse.IsSuccessStatusCode)
            {
                responseInsert = JsonConvert.DeserializeObject<ResponseInsert>(httpResponse.Content.ToString());
            }
            else
            {
                responseInsert.Error = true;
                responseInsert.ErrCode = "";
                responseInsert.ErrMsg = "Ошибка HttpClient.";
            }
            return responseInsert;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/data/remove")
        //Call<ResponseRemove> remove(@Body RequestRemove requestRemove);
        public async Task<ResponseRemove> RemoveAsync(RequestRemove requestRemove)
        {
            var uri = new Uri(baseUri + @"api/v1/data/remove");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestRemove);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);

            ResponseRemove responseRemove = new ResponseRemove();
            if (httpResponse.IsSuccessStatusCode)
            {
                responseRemove = JsonConvert.DeserializeObject<ResponseRemove>(httpResponse.Content.ToString());
            }
            else
            {
                responseRemove.Error = true;
                responseRemove.ErrCode = "";
                responseRemove.ErrMsg = "Ошибка HttpClient.";
            }
            return new ResponseRemove();
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/data/update")
        //Call<ResponseUpdate> update(@Body RequestUpdate requestUpdate);
        public async Task<ResponseUpdate> UpdateAsync(RequestUpdate requestUpdate)
        {
            var uri = new Uri(baseUri + @"api/v1/data/update");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestUpdate);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseUpdate.Results results = new ResponseUpdate.Results();
            ResponseUpdate responseRemove = new ResponseUpdate(results);

            if (httpResponse.IsSuccessStatusCode)
            {
                responseRemove = JsonConvert.DeserializeObject<ResponseUpdate>(httpResponse.Content.ToString());
            }
            else
            {
                responseRemove.Error = true;
                responseRemove.ErrCode = "";
                responseRemove.ErrMsg = "Ошибка HttpClient.";
            }
            return responseRemove;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/data/updatebyid")
        //Call<ResponseUpdateById> updateById(@Body RequestUpdateById requestUpdateById);
        public async Task<ResponseUpdateById> UpdateByIdAsync(RequestUpdateById requestUpdateById)
        {
            var uri = new Uri(baseUri + @"api/v1/data/updatebyid");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestUpdateById);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseUpdateById responseUpdateById = new ResponseUpdateById();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseUpdateById = JsonConvert.DeserializeObject<ResponseUpdateById>(httpResponse.Content.ToString());
            }
            else
            {
                responseUpdateById.Error = true;
                responseUpdateById.ErrCode = "";
                responseUpdateById.ErrMsg = "Ошибка HttpClient.";
            }
            return responseUpdateById;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/data/find")
        //Call<ResponseString> find(@Body RequestFind requestFind);
        public async Task<ResponseString> FindAsync(RequestFind requestFind)
        {
            var uri = new Uri(baseUri + @"api/v1/data/find");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestFind);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseString responseString = new ResponseString();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseString = JsonConvert.DeserializeObject<ResponseString>(httpResponse.Content.ToString());
            }
            else
            {
                responseString.Error = true;
                responseString.ErrCode = "";
                responseString.ErrMsg = "Ошибка HttpClient.";
            }
            return responseString;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/data/count")
        //Call<ResponseCount> count(@Body RequestCount requestCount);
        public async Task<ResponseResult> CountAsync(RequestCount requestCount)
        {
            var uri = new Uri(baseUri + @"api/v1/data/count");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestCount);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseResult responseResult = new ResponseResult();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseResult = JsonConvert.DeserializeObject<ResponseResult>(httpResponse.Content.ToString());
            }
            else
            {
                responseResult.Error = true;
                responseResult.ErrCode = "";
                responseResult.ErrMsg = "Ошибка HttpClient.";
            }
            return responseResult;
        }

        //====== File methods ======

        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/upload")
        //Call<ResponseCodes> upload(@Body RequestUpload requestUpload);
        public async Task<ResponseCodes> UploadAsync(RequestUpload requestUpload)
        {
            var uri = new Uri(baseUri + @"api/v1/upload");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestUpload);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseString responseString = new ResponseString();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseString = JsonConvert.DeserializeObject<ResponseString>(httpResponse.Content.ToString());
            }
            else
            {
                responseString.Error = true;
                responseString.ErrCode = "";
                responseString.ErrMsg = "Ошибка HttpClient.";
            }
            return responseString;
        }

        //@GET("api/v1/getfile/{app}/{coll}/{field}/{docId}/{file}")
        //Call<ResponseCodes> getFile(
        //        @NonNull @Path("app") String app,
        //        @NonNull @Path("coll") String coll,
        //        @NonNull @Path("field") String field,
        //        @NonNull @Path("docId") String docId,
        //        @NonNull @Path("file") String file);
        public async Task<string> GetFileAsync(string app, string coll,
            string field, string docId, string file)
        {
            var uri = new Uri(baseUri + $"api/v1/getfile/{app}/{coll}/{field}/{docId}/{file}");
            HttpResponseMessage httpResponse = await cmd.GetAsync(uri);
            //ResponseCodes responseCodes = new ResponseCodes();

            //if (httpResponse.IsSuccessStatusCode)
            //{
            //    responseCodes = JsonConvert.DeserializeObject<ResponseCount>(httpResponse.Content.ToString());
            //}
            //else
            //{
            //    responseCodes.Error = true;
            //    responseCodes.ErrCode = "";
            //    responseCodes.ErrMsg = "Ошибка HttpClient.";
            //}
            return httpResponse.Content.ToString();
        }


        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/deletefile")
        //Call<ResponseCodes> deleteFile(@Body RequestFile requestDeleteFile);
        public async Task<ResponseCodes> DeleteFileAsync(RequestFile requestDeleteFile)
        {
            var uri = new Uri(baseUri + @"api/v1/deletefile");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestDeleteFile);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseCodes responseCodes = new ResponseCodes();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseCodes = JsonConvert.DeserializeObject<ResponseCount>(httpResponse.Content.ToString());
            }
            else
            {
                responseCodes.Error = true;
                responseCodes.ErrCode = "";
                responseCodes.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCodes;
        }

        ///====== Message methods ======

        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/sendemail")
        //Call<ResponseCodes> sendEmail(@Body RequestSendEmail requestSendEmail);
        public async Task<ResponseCount> SendEmailAsync(RequestSendEmail requestSendEmaile)
        {
            var uri = new Uri(baseUri + @"api/v1/sendemail");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestSendEmaile);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseCount responseCount = new ResponseCount();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseCount = JsonConvert.DeserializeObject<ResponseCount>(httpResponse.Content.ToString());
            }
            else
            {
                responseCount.Error = true;
                responseCount.ErrCode = "";
                responseCount.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCount;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/sendpush")
        //Call<ResponseCodes> sendPush(@Body RequestSendPush requestSendPush);
        public async Task<ResponseCount> SendPushAsync(RequestSendPush requestSendPush)
        {
            var uri = new Uri(baseUri + @"api/v1/sendpush");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestSendPush);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseCount responseCount = new ResponseCount();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseCount = JsonConvert.DeserializeObject<ResponseCount>(httpResponse.Content.ToString());
            }
            else
            {
                responseCount.Error = true;
                responseCount.ErrCode = "";
                responseCount.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCount;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/sendsms")
        //Call<ResponseCodes> sendSms(@Body RequestSendSms requestSendSms);
        public async Task<ResponseCount> SendSmsAsync(RequestSendSms requestSendSms)
        {
            var uri = new Uri(baseUri + @"api/v1/sendsms");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestSendSms);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseCount responseCount = new ResponseCount();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseCount = JsonConvert.DeserializeObject<ResponseCount>(httpResponse.Content.ToString());
            }
            else
            {
                responseCount.Error = true;
                responseCount.ErrCode = "";
                responseCount.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCount;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/scripts")
        //Call<ResponseCodes> sendScriptTask(@Body RequestSendScriptTask requestSendScriptTask);
        public async Task<ResponseCount> SendScriptTaskAsync(RequestSendScriptTask requestSendScriptTask)
        {
            var uri = new Uri(baseUri + @"api/v1/scripts");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestSendScriptTask);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseCount responseCount = new ResponseCount();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseCount = JsonConvert.DeserializeObject<ResponseCount>(httpResponse.Content.ToString());
            }
            else
            {
                responseCount.Error = true;
                responseCount.ErrCode = "";
                responseCount.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCount;
        }


        //====== Application methods ======

        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/stat")
        //Call<ResponseAppStatistic> getAppStatistic(@Body RequestStatistic requestStatistic);
        public async Task<ResponseAppStatistic> GetAppStatisticAsync(RequestStatistic requestStatistic)
        {
            var uri = new Uri(baseUri + @"api/v1/stat");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestStatistic);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseAppStatistic responseAppStatistic = new ResponseAppStatistic();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseAppStatistic = JsonConvert.DeserializeObject<ResponseAppStatistic>(httpResponse.Content.ToString());
            }
            else
            {
                responseAppStatistic.Error = true;
                responseAppStatistic.ErrCode = "";
                responseAppStatistic.ErrMsg = "Ошибка HttpClient.";
            }
            return responseAppStatistic;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app")
        //Call<ResponseAppInfo> getApplicationInfo(@Body RequestAppInfo requestAppInfo);
        public async Task<ResponseAppInfo> GetAppInformationAsync(RequestAppInfo requestAppInfo)
        {
            var uri = new Uri(baseUri + @"api/v1/app");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestAppInfo);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseAppInfo responseAppInfo = null;

            if (httpResponse.IsSuccessStatusCode)
            {
                var jsonString = httpResponse.Content.ToString();
                responseAppInfo = JsonConvert.DeserializeObject<ResponseAppInfo>(jsonString);
            }
            else
            {
                responseAppInfo.Error = true;
                responseAppInfo.ErrCode = "";
                responseAppInfo.ErrMsg = "Ошибка HttpClient.";
            }
            return responseAppInfo;
        }

        //====== Collections methods ======

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections")
        //Call<ResponseGetCollectionsList> getCollectionsList(@Body RequestCollectionList requestCollectionList);
        public async Task<ResponseGetCollectionsList> GetCollectionsListAsync(RequestCollectionsList requestCollectionsList)
        {
            var uri = new Uri(baseUri + @"api/v1/app/collections");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestCollectionsList);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseGetCollectionsList responseCollList = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseCollList = JsonConvert.DeserializeObject<ResponseGetCollectionsList>(httpResponse.Content.ToString());
            }
            else
            {
                responseCollList.Error = true;
                responseCollList.ErrCode = "";
                responseCollList.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCollList;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/get")
        //Call<ResponseCollection> getCollectionByName(@Body RequestCollectionByName requestCollectionByName);
        public async Task<ResponseChangeCollectionTrigers> GetCollectionByNameAsync(RequestChangeCollectionTrigers requestCollectionByName)
        {
            var uri = new Uri(baseUri + @"api/v1/app/collections/get");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestCollectionByName);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseChangeCollectionTrigers responseCollection = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseCollection = JsonConvert.DeserializeObject<ResponseChangeCollectionTrigers>(httpResponse.Content.ToString());
            }
            else
            {
                responseCollection.Error = true;
                responseCollection.ErrCode = "";
                responseCollection.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCollection;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/create")
        //Call<ResponseCollection> createCollection(@Body RequestCreateCollection requestCreateCollection);
        public async Task<ResponseChangeCollectionTrigers> CreateCollectionAync(RequestCreateCollection requestCreateCollection)
        {
            var uri = new Uri(baseUri + @"api/v1/app/collections/create");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestCreateCollection);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseChangeCollectionTrigers responseCollection = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseCollection = JsonConvert.DeserializeObject<ResponseChangeCollectionTrigers>(httpResponse.Content.ToString());
            }
            else
            {
                responseCollection.Error = true;
                responseCollection.ErrCode = "";
                responseCollection.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCollection;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/update")
        //Call<ResponseCollection> updateCollection(@Body RequestUpdateCollection requestUpdateCollection);
        public async Task<ResponseChangeCollectionTrigers> UpdateCollectionAsync(RequestUpdateCollection requestUpdateCollection)
        {
            var uri = new Uri(baseUri + @"api/v1/app/collections/update");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestUpdateCollection);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseChangeCollectionTrigers responseCollection = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseCollection = JsonConvert.DeserializeObject<ResponseChangeCollectionTrigers>(httpResponse.Content.ToString());
            }
            else
            {
                responseCollection.Error = true;
                responseCollection.ErrCode = "";
                responseCollection.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCollection;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/delete")
        //Call<ResponseCodes> deleteCollection(@Body RequestDeleteCollection requestDeleteCollection);
        public async Task<ResponseCodes> DeleteCollectionAsync(RequestDeleteCollection requestDeleteCollection)
        {
            var uri = new Uri(baseUri + @"api/v1/app/collections/delete");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestDeleteCollection);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseCodes responseCodes = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseCodes = JsonConvert.DeserializeObject<ResponseCodes>(httpResponse.Content.ToString());
            }
            else
            {
                responseCodes.Error = true;
                responseCodes.ErrCode = "";
                responseCodes.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCodes;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/clone")
        //Call<ResponseCollection> cloneCollection(@Body RequestCloneCollection requestCloneCollection);
        public async Task<ResponseChangeCollectionTrigers> CloneCollectionAsync(RequestCloneCollection requestCloneCollection)
        {
            var uri = new Uri(baseUri + @"api/v1/app/collections/clone");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestCloneCollection);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseChangeCollectionTrigers responseCollection = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseCollection = JsonConvert.DeserializeObject<ResponseChangeCollectionTrigers>(httpResponse.Content.ToString());
            }
            else
            {
                responseCollection.Error = true;
                responseCollection.ErrCode = "";
                responseCollection.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCollection;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/index/create")
        //Call<ResponseCodes> createCollectionsIndex(@Body RequestCreateCollectionIndex requestCreateCollectionIndex);
        public async Task<ResponseCodes> CreateCollectionIndexAsync(RequestCreateCollectionIndex requestCreateCollectionIndex)
        {
            var uri = new Uri(baseUri + @"api/v1/app/collections/index/create");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestCreateCollectionIndex);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseCodes responseCodes = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseCodes = JsonConvert.DeserializeObject<ResponseCodes>(httpResponse.Content.ToString());
            }
            else
            {
                responseCodes.Error = true;
                responseCodes.ErrCode = "";
                responseCodes.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCodes;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/index/delete")
        //Call<ResponseCodes> deleteCollectionsIndex(@Body RequestDeleteCollectionIndex requestCreateCollectionIndex);
        public async Task<ResponseCodes> DeleteCollectionIndexAsync(RequestDeleteCollectionIndex requestCreateCollectionIndex)
        {
            var uri = new Uri(baseUri + @"api/v1/app/collections/index/delete");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestCreateCollectionIndex);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseCodes responseCodes = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseCodes = JsonConvert.DeserializeObject<ResponseCodes>(httpResponse.Content.ToString());
            }
            else
            {
                responseCodes.Error = true;
                responseCodes.ErrCode = "";
                responseCodes.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCodes;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/triggers")
        //Call<ResponseChangeCollectionTriggers> changeCollectionTriggers(@Body RequestChangeCollectionTriggers requestChangeCollectionTriggers);
        public async Task<ResponseChangeCollectionTriggers> ChangeCollectionTriggersAsync(RequestChangeCollectionTriggers requestChangeCollectionTriggers)
        {
            var uri = new Uri(baseUri + @"api/v1/app/collections/triggers");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestChangeCollectionTriggers);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseChangeCollectionTriggers responseChangeCollectionTriggers = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseChangeCollectionTriggers = JsonConvert.DeserializeObject<ResponseChangeCollectionTriggers>(httpResponse.Content.ToString());
            }
            else
            {
                responseChangeCollectionTriggers.Error = true;
                responseChangeCollectionTriggers.ErrCode = "";
                responseChangeCollectionTriggers.ErrMsg = "Ошибка HttpClient.";
            }
            return responseChangeCollectionTriggers;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/fields/create")
        //Call<ResponseAddField> addFieldInCollection(@Body RequestCreateField requestAddFieldInCollection);
        public async Task<ResponseAddField> AddFieldToCollectionAsync(RequestCreateField requestAddFieldInCollection)
        {
            var uri = new Uri(baseUri + @"api/v1/app/collections/fields/create");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestAddFieldInCollection);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseAddField responseAddField = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseAddField = JsonConvert.DeserializeObject<ResponseAddField>(httpResponse.Content.ToString());
            }
            else
            {
                responseAddField.Error = true;
                responseAddField.ErrCode = "";
                responseAddField.ErrMsg = "Ошибка HttpClient.";
            }
            return responseAddField;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/fields/delete")
        //Call<ResponseCollection> deleteFieldFromCollection(@Body RequestDeleteField requestDeleteFieldFromCollection);
        public async Task<ResponseChangeCollectionTrigers> DeleteFieldFromCollectionAsync(RequestDeleteField requestDeleteFieldFromCollection)
        {
            var uri = new Uri(baseUri + @"api/v1/app/collections/fields/delete");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestDeleteFieldFromCollection);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseChangeCollectionTrigers responseCollection = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseCollection = JsonConvert.DeserializeObject<ResponseChangeCollectionTrigers>(httpResponse.Content.ToString());
            }
            else
            {
                responseCollection.Error = true;
                responseCollection.ErrCode = "";
                responseCollection.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCollection;
        }

        //====== Folder methods ======

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/scripts/folders")
        //Call<ResponseGetFoldersList> getFoldersList(@Body RequestFoldersList requestFoldersList);
        public async Task<ResponseGetFoldersList> GetFoldersListAsync(RequestFoldersList requestFoldersList)
        {
            var uri = new Uri(baseUri + @"api/v1/app/scripts/folders");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestFoldersList);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseGetFoldersList responseGetFoldersList = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseGetFoldersList = JsonConvert.DeserializeObject<ResponseGetFoldersList>(httpResponse.Content.ToString());
            }
            else
            {
                responseGetFoldersList.Error = true;
                responseGetFoldersList.ErrCode = "";
                responseGetFoldersList.ErrMsg = "Ошибка HttpClient.";
            }
            return responseGetFoldersList;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/scripts/folders/create")
        //Call<ResponseCodes> createNewFolder(@Body RequestCreateNewFolder requestCreateNewFolder);
        public async Task<ResponseCodes> CreateNewFolderAsync(RequestCreateNewFolder requestCreateNewFolder)
        {
            var uri = new Uri(baseUri + @"api/v1/app/scripts/folders/create");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestCreateNewFolder);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseCodes responseCodes = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseCodes = JsonConvert.DeserializeObject<ResponseCodes>(httpResponse.Content.ToString());
            }
            else
            {
                responseCodes.Error = true;
                responseCodes.ErrCode = "";
                responseCodes.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCodes;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/scripts/folders/delete")
        //Call<ResponseCodes> deleteFolder(@Body RequestDeleteFolder requestDeleteFolder);
        public async Task<ResponseCodes>DeleteFolderAsync(RequestDeleteFolder requestDeleteFolder)
        {
            var uri = new Uri(baseUri + @"api/v1/app/scripts/folders/delete");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestDeleteFolder);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseCodes responseCodes = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseCodes = JsonConvert.DeserializeObject<ResponseCodes>(httpResponse.Content.ToString());
            }
            else
            {
                responseCodes.Error = true;
                responseCodes.ErrCode = "";
                responseCodes.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCodes;
        }


        //====== Script methods ======

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/scripts/create")
        //Call<ResponseScript> createScript(@Body RequestCreateScript requestCreateScript);
        public async Task<ResponseScript> CreateScriptAsync(RequestCreateScript requestCreateScriptr)
        {
            var uri = new Uri(baseUri + @"api/v1/app/scripts/create");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestCreateScriptr);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseScript responseScript = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseScript = JsonConvert.DeserializeObject<ResponseScript>(httpResponse.Content.ToString());
            }
            else
            {
                responseScript.Error = true;
                responseScript.ErrCode = "";
                responseScript.ErrMsg = "Ошибка HttpClient.";
            }
            return responseScript;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/scripts/get")
        //Call<ResponseScript> getScriptById(@Body RequestGetScriptById requestGetScript);
        public async Task<ResponseScript> GetScriptByIdAsync(RequestGetScriptById requestGetScript)
        {
            var uri = new Uri(baseUri + @"api/v1/app/scripts/get");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestGetScript);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseScript responseScript = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseScript = JsonConvert.DeserializeObject<ResponseScript>(httpResponse.Content.ToString());
            }
            else
            {
                responseScript.Error = true;
                responseScript.ErrCode = "";
                responseScript.ErrMsg = "Ошибка HttpClient.";
            }
            return responseScript;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/scripts/update")
        //Call<ResponseScript> updateScript(@Body RequestUpdateScript requestUpdateScript);
        public async Task<ResponseScript> UpdateScriptAsync(RequestUpdateScript requestUpdateScript)
        {
            var uri = new Uri(baseUri + @"api/v1/app/scripts/update");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestUpdateScript);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseScript responseScript = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseScript = JsonConvert.DeserializeObject<ResponseScript>(httpResponse.Content.ToString());
            }
            else
            {
                responseScript.Error = true;
                responseScript.ErrCode = "";
                responseScript.ErrMsg = "Ошибка HttpClient.";
            }
            return responseScript;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/scripts/delete")
        //Call<ResponseCodes> deleteScript(@Body RequestDeleteScriptById requestDeleteScript);
        public async Task<ResponseCodes> DeleteScriptAsync(RequestDeleteScriptById requestDeleteScript)
        {
            var uri = new Uri(baseUri + @"api/v1/app/scripts/delete");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestDeleteScript);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseCodes responseCodes = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseCodes = JsonConvert.DeserializeObject<ResponseCodes>(httpResponse.Content.ToString());
            }
            else
            {
                responseCodes.Error = true;
                responseCodes.ErrCode = "";
                responseCodes.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCodes;
        }

        //====== Bot methods ======

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/bots")
        //Call<ResponseBotList> getBotsList(@Body RequestGetBotsList requestGetBotsList);
        public async Task<ResponseBotList> GetBotsListAsync(RequestGetBotsList requestGetBotsList)
        {
            var uri = new Uri(baseUri + @"api/v1/bots");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestGetBotsList);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseBotList responseBotList = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseBotList = JsonConvert.DeserializeObject<ResponseBotList>(httpResponse.Content.ToString());
            }
            else
            {
                responseBotList.Error = true;
                responseBotList.ErrCode = "";
                responseBotList.ErrMsg = "Ошибка HttpClient.";
            }
            return responseBotList;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/bots/create")
        //Call<ResponseBot> createBot(@Body RequestCreateBot requestCreateBot);
        public async Task<ResponseBot> CreateBotAsync(RequestCreateBot requestCreateBot)
        {
            var uri = new Uri(baseUri + @"api/v1/bots/create");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestCreateBot);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseBot responseBot = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseBot = JsonConvert.DeserializeObject<ResponseBot>(httpResponse.Content.ToString());
            }
            else
            {
                responseBot.Error = true;
                responseBot.ErrCode = "";
                responseBot.ErrMsg = "Ошибка HttpClient.";
            }
            return responseBot;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/bots/update")
        //Call<ResponseBot> updateBot(@Body RequestUpdateBot requestUpdateBot);
        public async Task<ResponseBot> UpdateBotAsync(RequestUpdateBot requestUpdateBot)
        {
            var uri = new Uri(baseUri + @"api/v1/bots/update");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestUpdateBot);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseBot responseBot = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseBot = JsonConvert.DeserializeObject<ResponseBot>(httpResponse.Content.ToString());
            }
            else
            {
                responseBot.Error = true;
                responseBot.ErrCode = "";
                responseBot.ErrMsg = "Ошибка HttpClient.";
            }
            return responseBot;
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/bots/delete")
        //Call<ResponseCodes> deleteBot(@Body RequestDeleteBot requestDeleteBot);
        public async Task<ResponseCodes> DeleteBotAsync(RequestDeleteBot requestDeleteBot)
        {
            var uri = new Uri(baseUri + @"api/v1/bots/delete");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestDeleteBot);
            HttpResponseMessage httpResponse = await cmd.PostAsync(uri, jsonContent);
            ResponseCodes responseCodes = null; // new ResponseGetCollectionsList();

            if (httpResponse.IsSuccessStatusCode)
            {
                responseCodes = JsonConvert.DeserializeObject<ResponseCodes>(httpResponse.Content.ToString());
            }
            else
            {
                responseCodes.Error = true;
                responseCodes.ErrCode = "";
                responseCodes.ErrMsg = "Ошибка HttpClient.";
            }
            return responseCodes;
        }

    }
}
