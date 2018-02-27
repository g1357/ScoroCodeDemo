using Newtonsoft.Json;
using ScorocodeUWP.Requests.Application;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Fields
{
    public class RequestCreateField : AppBase
    {
        [JsonProperty("coll")]
        private string coll;
        [JsonProperty("collField")]
        private ScorocodeField collField;

        public RequestCreateField(ScorocodeSdkStateHolder stateHolder, string collectionName,
            ScorocodeField scorocodeField) : base(stateHolder)
        {
            this.coll = collectionName;
            this.collField = scorocodeField;
        }
    }
}