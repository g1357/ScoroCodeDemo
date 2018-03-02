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
    public class RequestCloneCollection : AppBase
    {
        [JsonProperty("collection")]
        //private ScorocodeCollection collection;
        private CloneCollection collection;

        public RequestCloneCollection(ScorocodeSdkStateHolder stateHolder, string collectionId,
            string newCollectionName) : base(stateHolder)
        {
            //this.collection = new ScorocodeCollection()
            //        .setCollectionId(collectionId)
            //        .setCollectionName(newCollectionName);
            collection = new CloneCollection(collectionId, newCollectionName);
        }

        class CloneCollection
        {
            [JsonProperty("id")]
            private string id;
            [JsonProperty("name")]
            private string name;

            public CloneCollection(string id, string name)
            {
                this.id = id;
                this.name = name;
            }
        }
    }
}