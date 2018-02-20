using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Data
{
    public class RequestInsert
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
        [JsonProperty("doc")]
        private Dictionary<string, object> _doc;

        public RequestInsert(ScorocodeSdkStateHolder stateHolder, string collectionName,
                DocumentInfo doc = null)
        {
            _app = stateHolder.ApplicationId;
            _cli = stateHolder.ClientKey;
            _acc = stateHolder.MasterKey;
            _sess = stateHolder.SessionId;
            _coll = collectionName;
            if (doc != null)
            {
                _doc = doc.GetFields();
            }
            else
            {
                _doc = new Dictionary<string, object>();
            }
        }

        public RequestInsert(ScorocodeSdkStateHolder stateHolder, string collectionName)
            : this(stateHolder, collectionName, null)
        { 
        }

    }
}