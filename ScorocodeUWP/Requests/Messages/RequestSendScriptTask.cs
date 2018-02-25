using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Messages
{
    public class RequestSendScriptTask
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
        [JsonProperty("script")]
        private string script;
        [JsonProperty("debug")]
        private bool debug;

        public RequestSendScriptTask(ScorocodeSdkStateHolder stateHolder, String coll,
                Query query, string script, bool isDebugMode)
        {
            this.app = stateHolder.ApplicationId;
            this.cli = stateHolder.ClientKey;
            this.acc = stateHolder.MasterOrMessageKey;
            this.sess = stateHolder.SessionId;
            this.coll = coll;
            if (query != null)
            {
                this.query = query.getQueryInfo(); //.getInfo();
            }
            this.script = script;
            this.debug = isDebugMode;
        }
    }
}
