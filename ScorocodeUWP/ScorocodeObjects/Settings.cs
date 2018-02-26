using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class Settings
    {
        [JsonProperty("emailVerified")]
        private bool emailVerified;
        [JsonProperty("sessionTimeout")]
        private long sessionTimeout;
        [JsonProperty("androidApiKey")]
        private string androidApiKey;
        [JsonProperty("gcmSenderId")]
        private string gcmSenderId;
        [JsonProperty("mailTemplates")]
        private Dictionary<string, MailTemplate> mailTemplates;
        [JsonProperty("smtp")]
        private string smtp;

        public Settings(bool emailVerified, long sessionTimeout, string androidApiKey,
                        string gcmSenderId, Dictionary<string, MailTemplate> mailTemplates, string smtp)
        {
            this.emailVerified = emailVerified;
            this.sessionTimeout = sessionTimeout;
            this.androidApiKey = androidApiKey;
            this.gcmSenderId = gcmSenderId;
            this.mailTemplates = mailTemplates;
            this.smtp = smtp;
        }

        public bool IsEmailVerified => emailVerified;

        public long SessionTimeout => sessionTimeout;

        public string AndroidApiKey => androidApiKey;

        public string GcmSenderId => gcmSenderId;

        public Dictionary<string, MailTemplate> MailTemplates => mailTemplates;

        public string Smtp => smtp;
    }
}
