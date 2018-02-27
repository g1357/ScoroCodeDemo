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
        private ScorocodeCollection collection;

        public RequestCloneCollection(ScorocodeSdkStateHolder stateHolder, string collectionId,
            string newCollectionName) : base(stateHolder)
        {
            this.collection = new ScorocodeCollection()
                    .setCollectionId(collectionId)
                    .setCollectionName(newCollectionName);
        }
    }
}