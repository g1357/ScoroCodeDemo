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
    public class RequestChangeCollectionTrigers : AppBase
    {
        [JsonProperty("coll")]
        private String coll;
        public RequestChangeCollectionTrigers(ScorocodeSdkStateHolder stateHolder, String collectionName)
            : base(stateHolder)
        {
            this.coll = collectionName;
        }
    }
}