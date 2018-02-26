using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses.Collections
{
    public class ResponseGetCollectionsList : ResponseCodes
    {
        [JsonProperty("collections")]
        private Dictionary<String, ScorocodeCollection> collections;

        public ResponseGetCollectionsList(Dictionary<String, ScorocodeCollection> collections)
        {
            this.collections = collections;
        }

        public List<ScorocodeCollection> GetCollections()
        {
            List<ScorocodeCollection> result = new List<ScorocodeCollection>();

            if (collections != null)
            {
                foreach (var item in collections)
                {
                    result.Add(item.Value);
                }
            }
            return result;
        }
    }
}