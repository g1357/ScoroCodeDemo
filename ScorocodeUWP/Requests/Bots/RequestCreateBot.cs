using Newtonsoft.Json;
using ScorocodeUWP.Requests.Application;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Bots
{
    public class RequestCreateBot : AppBase
    {
        [JsonProperty("bot")]
        private ScorocodeBot bot;

        public RequestCreateBot(ScorocodeSdkStateHolder stateHolder, string botName, string botId, string scriptId, bool isActive)
            : base(stateHolder)
        {
            this.bot = new ScorocodeBot(botName, botId, scriptId, isActive);
        }
    }
}