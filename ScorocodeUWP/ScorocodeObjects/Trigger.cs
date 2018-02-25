using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class Trigger
    {
        [JsonProperty("code")]
        private string code;
        public string Code => code ?? ""; 

        [JsonProperty("isActive")]
        private bool isActive;
        public bool IsActive => isActive;

        public Trigger() { }

        public Trigger(string code, bool isActive)
        {
            this.code = code;
            this.isActive = isActive;
        }
    }
}
