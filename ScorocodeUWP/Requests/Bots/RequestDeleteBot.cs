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
    public class RequestDeleteBot : AppBase
    {
        [JsonProperty("bot")]
        private ScorocodeBot bot;

        public RequestDeleteBot(ScorocodeSdkStateHolder stateHolder, String botId)
            : base(stateHolder)
        {
            this.bot = new ScorocodeBot().setBotId(botId);
        }
    }
}