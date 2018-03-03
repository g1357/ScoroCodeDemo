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
        private string code;
        [JsonProperty("code")]
        public string Code => code ?? ""; 

        private bool isActive;
        [JsonProperty("isActive")]
        public bool IsActive => isActive;

        public Trigger()
        {
            code = "";
            isActive = false;
        }

        public Trigger(string code, bool isActive)
        {
            this.code = code;
            this.isActive = isActive;
        }
    }
}
