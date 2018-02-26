using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class ScorocodeClientKeys
    {
        [JsonProperty("android")]
        private string android;
        [JsonProperty("ios")]
        private string ios;
        [JsonProperty("javascript")]
        private string javascript;
        [JsonProperty("winphone")]
        private string winphone;

        public ScorocodeClientKeys(string android, string ios, string javascript, string winphone)
        {
            this.android = android;
            this.ios = ios;
            this.javascript = javascript;
            this.winphone = winphone;
        }

        public string getAndroidClientKey => android;

        public string getIosClientKey => ios;

        public string getJavascriptClientKey => javascript;

        public string getWinphoneClientKey => winphone;
    }
}