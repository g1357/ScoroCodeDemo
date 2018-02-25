using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;

namespace ScorocodeUWP.Requests.Application
{
    public class RequestStatistic
    {
        [JsonProperty("app")]
        private string app;
        [JsonProperty("cli")]
        private string cli;
        [JsonProperty("acc")]
        private string acc;

        public RequestStatistic(ScorocodeSdkStateHolder stateHolder)
        {
            app = stateHolder.ApplicationId;
            cli = stateHolder.ClientKey;
            acc = stateHolder.MasterKey;
        }
    }
}
