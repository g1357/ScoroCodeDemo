using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses
{
    /// <summary>
    /// Коды ответа
    /// </summary>
    public class ResponseCodes
    {
        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("errCode")]
        public string ErrCode { get; set; }

        [JsonProperty("errMsg")]
        public string ErrMsg { get; set; }
    }
}
