using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ScorocodeUWP.Requests;
using ScorocodeUWP.Requests.Application;
using ScorocodeUWP.Requests.Data;
using ScorocodeUWP.Requests.Fikes;
using ScorocodeUWP.Responses;
using ScorocodeUWP.Responses.Data;
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
        public async Task<ResponseCount> CountAsync(RequestCount requestCount)
        {
            var uri = new Uri(baseUri + @"api/v1/data/count");
            // Сформировать JSON данные
            string jsonContent = JsonConvert.SerializeObject(requestCount);
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


        //@GET("api/v1/getfile/{app}/{coll}/{field}/{docId}/{file}")
        //Call<ResponseCodes> getFile(
        //        @NonNull @Path("app") String app,
        //        @NonNull @Path("coll") String coll,
        //        @NonNull @Path("field") String field,
        //        @NonNull @Path("docId") String docId,
        //        @NonNull @Path("file") String file);


        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/deletefile")
        //Call<ResponseCodes> deleteFile(@Body RequestFile requestDeleteFile);


        ///====== Message methods ======

        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/sendemail")
        //Call<ResponseCodes> sendEmail(@Body RequestSendEmail requestSendEmail);


        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/sendpush")
        //Call<ResponseCodes> sendPush(@Body RequestSendPush requestSendPush);


        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/sendsms")
        //Call<ResponseCodes> sendSms(@Body RequestSendSms requestSendSms);


        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/scripts")
        //Call<ResponseCodes> sendScriptTask(@Body RequestSendScriptTask requestSendScriptTask);


        //====== Application methods ======

        //@Headers({ "Content-Type: application/json"})
        //@POST("api/v1/stat")
        //Call<ResponseAppStatistic> getAppStatistic(@Body RequestStatistic requestStatistic);
        public ResponseAppStatistic getAppStatistic(RequestStatistic requestStatistic)
        {
            return new ResponseAppStatistic();
        }

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app")
        //Call<ResponseAppInfo> getApplicationInfo(@Body RequestAppInfo requestAppInfo);


        //====== Collections methods ======

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections")
        //Call<ResponseGetCollectionsList> getCollectionsList(@Body RequestCollectionList requestCollectionList);


        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/get")
        //Call<ResponseCollection> getCollectionByName(@Body RequestCollectionByName requestCollectionByName);


        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/create")
        //Call<ResponseCollection> createCollection(@Body RequestCreateCollection requestCreateCollection);


        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/update")
        //Call<ResponseCollection> updateCollection(@Body RequestUpdateCollection requestUpdateCollection);


        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/delete")
        //Call<ResponseCodes> deleteCollection(@Body RequestDeleteCollection requestDeleteCollection);


        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/clone")
        //Call<ResponseCollection> cloneCollection(@Body RequestCloneCollection requestCloneCollection);


        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/index/create")
        //Call<ResponseCodes> createCollectionsIndex(@Body RequestCreateCollectionIndex requestCreateCollectionIndex);


        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/index/delete")
        //Call<ResponseCodes> deleteCollectionsIndex(@Body RequestDeleteCollectionIndex requestCreateCollectionIndex);


        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/triggers")
        //Call<ResponseChangeCollectionTriggers> changeCollectionTriggers(@Body RequestChangeCollectionTriggers requestChangeCollectionTriggers);


        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/fields/create")
        //Call<ResponseAddField> addFieldInCollection(@Body RequestCreateField requestAddFieldInCollection);


        //        @Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/collections/fields/delete")
        //Call<ResponseCollection> deleteFieldFromCollection(@Body RequestDeleteField requestDeleteFieldFromCollection);


        //====== Folder methods ======

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/scripts/folders")
        //Call<ResponseGetFoldersList> getFoldersList(@Body RequestFoldersList requestFoldersList);


        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/scripts/folders/create")
        //Call<ResponseCodes> createNewFolder(@Body RequestCreateNewFolder requestCreateNewFolder);


        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/scripts/folders/delete")
        //Call<ResponseCodes> deleteFolder(@Body RequestDeleteFolder requestDeleteFolder);


        //====== Script methods ======

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/scripts/create")
        //Call<ResponseScript> createScript(@Body RequestCreateScript requestCreateScript);


        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/scripts/get")
        //Call<ResponseScript> getScriptById(@Body RequestGetScriptById requestGetScript);


        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/scripts/update")
        //Call<ResponseScript> updateScript(@Body RequestUpdateScript requestUpdateScript);


        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/app/scripts/delete")
        //Call<ResponseCodes> deleteScript(@Body RequestDeleteScriptById requestDeleteScript);


        //====== Bot methods ======

        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/bots")
        //Call<ResponseBotList> getBotsList(@Body RequestGetBotsList requestGetBotsList);


        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/bots/create")
        //Call<ResponseBot> createBot(@Body RequestCreateBot requestCreateBot);


        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/bots/update")
        //Call<ResponseBot> updateBot(@Body RequestUpdateBot requestUpdateBot);


        //@Headers({ "Content-Type: application/json"})
        //@POST("/api/v1/bots/delete")
        //Call<ResponseCodes> deleteBot(@Body RequestDeleteBot requestDeleteBot);


    }
}
