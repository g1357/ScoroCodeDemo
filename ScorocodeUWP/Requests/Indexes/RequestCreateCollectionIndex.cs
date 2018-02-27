using Newtonsoft.Json;
using ScorocodeUWP.Requests.Application;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Indexes
{
    public class RequestCreateCollectionIndex : AppBase
    {
        [JsonProperty("coll")]
        private string coll;
        [JsonProperty("index")]
        private Index index;

        public RequestCreateCollectionIndex(ScorocodeSdkStateHolder stateHolder,
            string collectionName, Index index) : base(stateHolder)
        {
            this.coll = collectionName;
            this.index = index;
        }
    }
}