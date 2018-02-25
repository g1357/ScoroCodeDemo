using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class IndexField
    {
        [JsonProperty("name")]
        private string name;
        public string Name => name;
        [JsonProperty("order")]
        private int order;
        public int Order => order;

        public IndexField(string name, int order)
        {
            this.name = name;
            this.order = order;
        }
    }
}
