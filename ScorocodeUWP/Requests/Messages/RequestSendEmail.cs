using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Messages
{
    public class RequestSendEmail
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
        private Dictionary<string, Object> query;
        [JsonProperty("msg")]
        private MessageEmail msg;

        public RequestSendEmail(ScorocodeSdkStateHolder stateHolder, string coll,
                Query query, MessageEmail msg)
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
        }
    }
}