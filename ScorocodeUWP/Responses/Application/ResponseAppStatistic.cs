using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses
{
    public sealed class ResponseAppStatistic : ResponseCodes
    {
        [JsonProperty("result")]
        public Result result;

        public Result getResult()
        {
            return result;
        }

        public void setResult(Result result)
        {
            this.result = result;
        }

        public class Result
        {
            [JsonProperty("dataSize")]
            public long dataSize;   // Размер данных приложения, в байтах
            [JsonProperty("filesSize")]
            public long filesSize;  // Размер файлов приложения, в байтах
            [JsonProperty("indexSize")]
            public long indexSize;  // "Размер" индексов приложения, в байтах
            [JsonProperty("store")]
            public double store;    // 
        }
    }
}