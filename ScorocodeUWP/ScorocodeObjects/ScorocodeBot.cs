using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class ScorocodeBot
    {
        [JsonProperty("_id")]
        private string _id;
        [JsonProperty("name")]
        private string name;
        [JsonProperty("botId")]
        private string botId;
        [JsonProperty("scriptId")]
        private string scriptId;
        [JsonProperty("isActive")]
        private bool isActive;

        public ScorocodeBot() { }

        public ScorocodeBot(string botName, string telegramBotId, string scriptId, bool isActive)
        {
            this.name = botName;
            this.botId = telegramBotId;
            this.scriptId = scriptId;
            this.isActive = isActive;
        }

        public string getBotId()
        {
            return _id == null ? "" : _id;
        }

        public string getBotName()
        {
            return name == null ? "" : name;
        }

        public string getTelegramBotId()
        {
            return botId == null ? "" : botId;
        }

        public string getScriptId()
        {
            return scriptId == null ? "" : scriptId;
        }

        public bool isBotActive()
        {
            return isActive;
        }

        public ScorocodeBot setBotId(string id)
        {
            this._id = id;
            return this;
        }

        public ScorocodeBot setTelegramBotId(string id)
        {
            this._id = id;
            return this;
        }

        public ScorocodeBot setBotName(string name)
        {
            this.name = name;
            return this;
        }

        public ScorocodeBot setScriptId(string scriptId)
        {
            this.scriptId = scriptId;
            return this;
        }

        public ScorocodeBot setActive(bool active)
        {
            isActive = active;
            return this;
        }
    }
}