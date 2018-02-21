using Newtonsoft.Json;
using ScorocodeUWP.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP
{
    public class ResponseRemove : ResponseCodes
    {
        [JsonProperty("result")]
        public Results Result { get; set; }

        public class Results
        {
            [JsonProperty("count")]
            public int Count { get; set; }
            [JsonProperty("docs")]
            public List<string> Docs { get; set; }
        }
    }
}