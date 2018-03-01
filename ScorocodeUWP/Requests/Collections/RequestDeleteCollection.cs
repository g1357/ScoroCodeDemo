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
    public class RequestDeleteCollection : AppBase
    {
        [JsonProperty("collection")]
        private DeleteCollection collection;

        public RequestDeleteCollection(ScorocodeSdkStateHolder stateHolder, string collectionId)
            : base(stateHolder)
        {
            this.collection = new DeleteCollection(collectionId);
        }

        class DeleteCollection
        {
            [JsonProperty("id")]
            private string id;

            public DeleteCollection(string collId)
            {
                id = collId;
            }
        }
    }
}