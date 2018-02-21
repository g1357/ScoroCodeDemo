using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace ScorocodeUWP.WebApi
{
    public class WebApiCommand
    {
        public async Task<HttpResponseMessage> PostAsync(Uri uri, string jsonContent)
        {
            HttpStringContent content = new HttpStringContent(jsonContent, 
                Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");

            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.PostAsync(uri, content);

            return response;
        }
        public async Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(uri);

            return response;
        }
    }
}
