using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Messages
{
    public class MessageEmail
    {
        [JsonProperty("subject")]
        private string subject;
        [JsonProperty("text")]
        private string text;
        [JsonProperty("from")]
        private string from;

        public MessageEmail(string from, string subject, string text)
        {
            this.subject = subject;
            this.text = text;
            this.from = from;
        }
    }
}