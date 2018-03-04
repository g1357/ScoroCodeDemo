using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses.Scripts
{
    public class ResponseScript : ResponseCodes
    {
        [JsonProperty("script")]
        private ScorocodeScript script;

        public ResponseScript(ScorocodeScript script)
        {
            this.script = script;
        }

        public ScorocodeScript getScript()
        {
            return script;
        }
    }
}