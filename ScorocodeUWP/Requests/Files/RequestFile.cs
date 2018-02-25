using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Files
{
    public class RequestFile
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
        [JsonProperty("docId")]
        private String docId;
        [JsonProperty("field")]
        private String field;
        [JsonProperty("file")]
        private String file;

        public RequestFile(ScorocodeSdkStateHolder stateHolder, string coll,
                string docId, string field, string file)
        {
            this.app = stateHolder.ApplicationId;
            this.cli = stateHolder.ClientKey;
            this.acc = stateHolder.MasterOrFileKey;
            this.sess = stateHolder.SessionId;
            this.coll = coll;
            this.docId = docId;
            this.field = field;
            this.file = file;
        }
    }
}