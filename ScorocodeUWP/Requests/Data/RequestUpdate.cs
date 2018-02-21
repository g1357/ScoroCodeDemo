using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Data
{
    public class RequestUpdate
    {
        [JsonProperty("app")]
        private string app;
        [JsonProperty("cli")]
        private string cli;
        [JsonProperty("acc")]
        private string acc;
        [JsonProperty("sess")]
        private string sess;
        [JsonProperty("coll")]
        private string coll;
        [JsonProperty("query")]
        private Dictionary<string, object> query;
        [JsonProperty("doc")]
        private Dictionary<string, Dictionary<string, object>> doc;
        [JsonProperty("limit")]
        private int limit;

        public RequestUpdate(ScorocodeCoreInfo stateHolder, string collectionName,
            Query query, UpdateInfo doc, int limit)
        {
            this.app = stateHolder.getApplicationId();
            this.cli = stateHolder.getClientKey();
            this.acc = stateHolder.getMasterKey();
            this.sess = stateHolder.getSessionId();
            this.coll = collectionName;
            if (query != null)
            {
                this.query = query.getQueryInfo(); //.getInfo();
            }
            this.doc = doc.Info;
            this.limit = limit;
        }
    }
}