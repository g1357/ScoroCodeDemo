using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class StorageInfo
    {
        [JsonProperty("user")]
        private string user;
        [JsonProperty("password")]
        private string password;

        public StorageInfo(string user, string password)
        {
            this.user = user;
            this.password = password;
        }

        public string User => user;

        public string Password => password;
    }
}