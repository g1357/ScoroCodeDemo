using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses.Fields
{
    public class ResponseAddField : ResponseCodes
    {
        [JsonProperty("field")]
        private ScorocodeField field;

        public ResponseAddField(ScorocodeField field)
        {
            this.field = field;
        }

        public ScorocodeField Field => field;
    }
}