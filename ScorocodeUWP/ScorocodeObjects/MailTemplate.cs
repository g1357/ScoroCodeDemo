using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class MailTemplate
    {
        [JsonProperty("subject")]
        private string subject;
        [JsonProperty("body")]
        private string body;

        public MailTemplate(string subject, string body)
        {
            this.subject = subject;
            this.body = body;
        }

        public string Subject => subject;

        public string Body => body;
    }
}