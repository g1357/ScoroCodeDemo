using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class Index
    {
        [JsonProperty("name")]
        private string name;
        public string Name => name;
        [JsonProperty("fields")]
        private List<IndexField> fields;
        public List<IndexField> Fields => fields;

        public Index(String name, List<IndexField> fields)
        {
            this.name = name;
            this.fields = fields;
        }
    }
}