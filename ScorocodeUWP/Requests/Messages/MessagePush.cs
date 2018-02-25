using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Messages
{
    public class MessagePush
    {
        [JsonProperty("text")]
        private string text;
        [JsonProperty("data")]
        private Dictionary<string, object> data;

        public MessagePush(string text, Dictionary<string,object> data)
        {
            this.text = text;
            this.data = data;
        }
    }
}