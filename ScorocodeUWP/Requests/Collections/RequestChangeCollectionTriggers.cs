using Newtonsoft.Json;
using ScorocodeUWP.Requests.Application;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Collections
{
    public class RequestChangeCollectionTriggers : AppBase
    {
        [JsonProperty("coll")]
        private string coll;
        [JsonProperty("triggers")]
        private ScorocodeTriggers triggers;

        public RequestChangeCollectionTriggers(ScorocodeSdkStateHolder stateHolder, 
            string collectionName, ScorocodeTriggers triggers) : base(stateHolder)
        {
            this.coll = collectionName;
            this.triggers = triggers;
        }
    }
}