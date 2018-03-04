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
    public class RequestUpdateBot : AppBase
    {
        [JsonProperty("bot")]
        private ScorocodeBot bot;

        public RequestUpdateBot(ScorocodeSdkStateHolder stateHolder, string botId, ScorocodeBot bot)
            : base(stateHolder)
        {
            this.bot = bot;
            this.bot.setBotId(botId);
        }
    }
}