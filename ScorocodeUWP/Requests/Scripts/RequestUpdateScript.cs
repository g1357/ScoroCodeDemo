using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Scripts
{
    public class RequestUpdateScript : RequestCreateScript
    {
        [JsonProperty("script")]
        private string script;

        public RequestUpdateScript(ScorocodeSdkStateHolder stateHolder, string scriptId, ScorocodeScript script)
            : base(stateHolder, script)
        {
            this.script = scriptId;
        }
    }
}