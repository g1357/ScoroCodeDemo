using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class ScorocodeACLPublic
    {
        [JsonProperty("create")]
        private bool create;
        [JsonProperty("read")]
        private bool read;
        [JsonProperty("remove")]
        private bool remove;
        [JsonProperty("update")]
        private bool update;

        public ScorocodeACLPublic(bool create, bool read, bool remove, bool update)
        {
            this.create = create;
            this.read = read;
            this.remove = remove;
            this.update = update;
        }

        public bool IsCreatePermitted => create;

        public bool IsReadPermitted => read;

        public bool IsRemovePermitted => remove;

        public bool IsUpdatePermitted => update;
    }
}