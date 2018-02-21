using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Data
{
    public class RequestRemove
    {
        [JsonProperty("app")]
        private string _app;
        [JsonProperty("cli")]
        private string _cli;
        [JsonProperty("acc")]
        private string _acc;
        [JsonProperty("sess")]
        private string _sess;
        [JsonProperty("coll")]
        private string _coll;
        [JsonProperty("query")]
        private Dictionary<string, object> _query;
        [JsonProperty("limit")]
        private int limit;

        public RequestRemove(ScorocodeSdkStateHolder stateHolder, string collectionName,
                Dictionary<string, object> query = null, int limit = 0)
        {
            _app = stateHolder.ApplicationId;
            _cli = stateHolder.ClientKey;
            _acc = stateHolder.MasterKey;
            _sess = stateHolder.SessionId;
            _coll = collectionName;

            if (query != null)
            {
                _query = query;
            }
            this.limit = limit;
        }
    }
}