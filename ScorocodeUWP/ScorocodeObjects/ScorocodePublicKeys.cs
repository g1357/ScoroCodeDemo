using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class ScorocodePublicKeys
    {
        [JsonProperty("masterKey")]
        private string masterKey;
        [JsonProperty("fileKey")]
        private string fileKey;
        [JsonProperty("messageKey")]
        private string messageKey;
        [JsonProperty("scriptKey")]
        private string scriptKey;
        [JsonProperty("websocketKey")]
        private string websocketKey;

        public ScorocodePublicKeys(string masterKey, string fileKey, string messageKey, 
            string scriptKey, string websocketKey)
        {
            this.masterKey = masterKey;
            this.fileKey = fileKey;
            this.messageKey = messageKey;
            this.scriptKey = scriptKey;
            this.websocketKey = websocketKey;
        }

        public string getMasterKey()
        {
            return masterKey;
        }

        public string getFileKey()
        {
            return fileKey;
        }

        public string getMessageKey()
        {
            return messageKey;
        }

        public string getScriptKey()
        {
            return scriptKey;
        }

        public string getWebsocketKey()
        {
            return websocketKey;
        }
    }
}