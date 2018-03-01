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
    public class RequestDeleteField : AppBase
    {
        [JsonProperty("coll")]
        private string coll;
        [JsonProperty("collField")]
        private DeleteField collField;

        public RequestDeleteField(ScorocodeSdkStateHolder stateHolder, string collectionName, 
            string fieldName) : base(stateHolder)
        {
            this.coll = collectionName;
            this.collField = new DeleteField(fieldName);
        }

        class DeleteField
        {
            [JsonProperty("name")]
            private string name;

            public DeleteField(string fieldName)
            {
                name = fieldName;
            }
        }
    }
}