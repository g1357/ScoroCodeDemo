using Newtonsoft.Json;
using ScorocodeUWP.Requests.Application;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Scripts
{
    public class RequestGetScriptById : AppBase
    {
        [JsonProperty("script")]
        private string script;

        public RequestGetScriptById(ScorocodeSdkStateHolder stateHolder, string scriptId)
            : base(stateHolder)
        {
            this.script = scriptId;
        }
    }
}