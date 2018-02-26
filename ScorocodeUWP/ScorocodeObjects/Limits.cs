using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class Limits
    {
        [JsonProperty("rps")]
        private long rps;
        [JsonProperty("store")]
        private long store;
        [JsonProperty("pushValue")]
        private long pushValue;
        [JsonProperty("pushUsed")]
        private long pushUsed;
        [JsonProperty("developers")]
        private long developers;
        [JsonProperty("ws")]
        private long ws;
        [JsonProperty("scriptTimeout")]
        private long scriptTimeout;

        public Limits(long rps, long store, long pushValue, long pushUsed,
                      long developers, long ws, long scriptTimeout)
        {
            this.rps = rps;
            this.store = store;
            this.pushValue = pushValue;
            this.pushUsed = pushUsed;
            this.developers = developers;
            this.ws = ws;
            this.scriptTimeout = scriptTimeout;
        }

        public long RequestPerSecondLimit => rps;

        public long StoreAmountLimit => store;

        public long PushCountLimit => pushValue;

        public long PushUsedNumber => pushUsed;

        public long DevelopersLimit => developers;

        public long WebsocketsConnectionLimit => ws;

        public long ScriptTimeout => scriptTimeout;
    }
}