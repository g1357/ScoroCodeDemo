using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Messages
{
    public class MessageSms
    {
        [JsonProperty("text")]
        public string Text;

        public MessageSms(String text)
        {
            Text = text;
        }
    }
}
