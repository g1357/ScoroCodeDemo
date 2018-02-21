using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses.Data
{
    public class ResponseString : ResponseCodes
    {
        [JsonProperty("result")]
        private string result;
        public string Result
        {
            get => result;
            set { result = value; }
        }
    }
}