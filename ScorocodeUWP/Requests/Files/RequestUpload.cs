using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Files
{
    public class RequestUpload
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
        [JsonProperty("docId")]
        private string docId;
        [JsonProperty("field")]
        private string field;
        [JsonProperty("file")]
        private string file;
        [JsonProperty("content")]
        private string content; //in base 64 format

        public RequestUpload(ScorocodeSdkStateHolder stateHolder, string coll,
                string docId, string field, string file, string content)
        {
            this.app = stateHolder.ApplicationId;
            this.cli = stateHolder.ClientKey;
            this.acc = stateHolder.MasterOrFileKey;
            this.sess = stateHolder.SessionId;
            this.coll = coll;
            this.docId = docId;
            this.field = field;
            this.file = file;
            this.content = content;
        }
    }
}