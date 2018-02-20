using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ScorocodeUWP.Responses;
using Windows.Web.Http;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class NetworkHelper
    {
        public static async Task<string> ReadUrlAsync(String urlString)
        {
            Uri uri = new Uri(urlString);
            HttpResponseMessage response;
            try
            {
                HttpClient httpClient = new HttpClient();
                response = await httpClient.GetAsync(uri);
                if (response.StatusCode == HttpStatusCode.Ok)
                {
                    return response.Content.ToString();
                }
                else
                {
                    throw new InvalidOperationException("web request not OK!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsResponseSucceed(ResponseCodes responseCodes)
        {
            return !responseCodes.Error;
        }
    }
}
