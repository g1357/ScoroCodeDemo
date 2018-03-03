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
    public class RequestDeleteCollectionIndex : AppBase
    {
        [JsonProperty("coll")]
        private string coll;
        [JsonProperty("index")]
        private DeleteIndex index;

        public RequestDeleteCollectionIndex(ScorocodeSdkStateHolder stateHolder,
            string collectionName, string indexName) : base(stateHolder)
        {
            this.coll = collectionName;
            this.index = new DeleteIndex(indexName);
        }

        class DeleteIndex
        {
            [JsonProperty("name")]
            private string name;    // Index Name

            public DeleteIndex(string indexName)
            {
                name = indexName;
            }
        }
    }
}