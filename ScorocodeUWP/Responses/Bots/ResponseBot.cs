using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses.Bots
{
    public class ResponseBot : ResponseCodes
    {
        [JsonProperty("bot")]
        private ScorocodeBot bot;

        public ResponseBot(ScorocodeBot bot)
        {
            this.bot = bot;
        }

        public ScorocodeBot getBot()
        {
            return bot;
        }
    }
}