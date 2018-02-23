using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Data
{
    public class RequestCount
    {
        [JsonProperty("app")]
        private String app;
        [JsonProperty("cli")]
        private String cli;
        [JsonProperty("acc")]
        private String acc;
        [JsonProperty("sess")]
        private String sess;
        [JsonProperty("coll")]
        private String coll;
        [JsonProperty("query")]
        private Dictionary<String, Object> query;

        public RequestCount(ScorocodeSdkStateHolder stateHolder,
            string coll, Query query = null)
        {
            this.app = stateHolder.ApplicationId;
            this.cli = stateHolder.ClientKey;
            this.acc = stateHolder.MasterKey;
            this.sess = stateHolder.SessionId;
            this.coll = coll;
            if (query != null)
            {
                this.query = query.getQueryInfo(); //.getInfo();
            }
        }
    }
}