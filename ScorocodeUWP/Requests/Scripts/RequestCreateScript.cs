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
    public class RequestCreateScript : AppBase
    {
        [JsonProperty("cloudCode")]
        private ScorocodeScript cloudCode;

        public RequestCreateScript(ScorocodeSdkStateHolder stateHolder, ScorocodeScript cloudCode)
            : base(stateHolder)
        {
            this.cloudCode = cloudCode;
        }
    }
}