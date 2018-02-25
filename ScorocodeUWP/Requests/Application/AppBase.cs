using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Application
{
    public class AppBase
    {
        [JsonProperty("acc")]
        protected string acc;
        [JsonProperty("app")]
        protected string app;
        [JsonProperty("cli")]
        protected string cli;

        public AppBase(ScorocodeSdkStateHolder stateHolder)
        {
            acc = stateHolder.MasterKey;
            app = stateHolder.ApplicationId;
            cli = stateHolder.ClientKey;
        }
    }
}