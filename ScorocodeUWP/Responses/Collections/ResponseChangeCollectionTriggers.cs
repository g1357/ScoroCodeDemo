using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses.Collections
{
    public class ResponseChangeCollectionTriggers : ResponseCodes
    {
        [JsonProperty("triggers")]
        private ScorocodeTriggers triggers;

        public ResponseChangeCollectionTriggers(ScorocodeTriggers triggers)
        {
            this.triggers = triggers;
        }

        public ScorocodeTriggers Triggers => triggers;
    }
}