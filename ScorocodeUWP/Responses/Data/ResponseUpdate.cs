using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses.Data
{
    public class ResponseUpdate : ResponseCodes
    {
        [JsonProperty("result")]
        private Results result;
        public Results Result
        {
            get => result;
        }
        public ResponseUpdate(Results result)
        {
            this.result = result;
        }

        public class Results
        {
            [JsonProperty("count")]
            public int Count;
            [JsonProperty("docs")]
            public List<string> Docs;
        }
    }
}