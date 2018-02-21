using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses.Data
{
    public class ResponseUpdateById : ResponseCodes
    {
        [JsonProperty("result")]
        private Dictionary<string, object> result;
        public DocumentInfo getResult()
        {
            return new DocumentInfo(result);
        }

        public void setResult(Dictionary<string, object> result)
        {
            this.result = result;
        }
    }
}