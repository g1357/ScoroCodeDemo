using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses.Bots
{
    public class ResponseBotList : ResponseCodes
    {
        [JsonProperty("items")]
        private List<ScorocodeBot> items;

        public ResponseBotList(List<ScorocodeBot> items)
        {
            this.items = items;
        }

        public List<ScorocodeBot> getBotsList()
        {
            return items == null ? (new List<ScorocodeBot>()) : items;
        }
    }
}