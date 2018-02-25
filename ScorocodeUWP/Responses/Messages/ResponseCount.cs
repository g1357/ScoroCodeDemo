using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses.Messages
{
    public class ResponseCount : ResponseCodes
    {
        [JsonProperty("count")]
        public int count;
    }
}
