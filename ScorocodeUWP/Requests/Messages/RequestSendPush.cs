using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Messages
{
    public class RequestSendPush
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
        [JsonProperty("msg")]
        private MessagePush msg;
        [JsonProperty("debug")]
        private bool debug;

        public RequestSendPush(ScorocodeSdkStateHolder stateHolder, string coll,
                Query query, MessagePush msg, bool debug)
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
            this.msg = msg;
            this.debug = debug;
        }
    }
}