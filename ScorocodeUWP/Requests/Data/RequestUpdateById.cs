using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Data
{
    public class RequestUpdateById
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

        public RequestUpdateById(ScorocodeSdkStateHolder stateHolder, string collectionName,
                QueryInfo query, UpdateInfo doc)
        {
            this.app = stateHolder.ApplicationId;
            this.cli = stateHolder.ClientKey;
            this.acc = stateHolder.MasterKey;
            this.sess = stateHolder.SessionId;
            this.coll = collectionName;
            this.query = query;
            this.doc = doc.Info;
        }
    }
}