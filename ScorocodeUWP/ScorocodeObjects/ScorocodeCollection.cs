using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class ScorocodeCollection
    {
        [JsonProperty("id")]
        private string id;
        public string CollectionId => id ?? "";

        [JsonProperty("name")]
        private string name;
        public string CollectionName => name ?? "";

        [JsonProperty("useDocsACL")]
        private bool useDocsACL;
        public bool IsUseDocsACL => useDocsACL;

        [JsonProperty("ACL")]
        private ScorocodeACL acl;
        public ScorocodeACL ACL => acl ?? new ScorocodeACL();

        [JsonProperty("triggers")]
        private ScorocodeTriggers triggers;
        public ScorocodeTriggers Triggers => triggers ?? new ScorocodeTriggers();

        [JsonProperty("fields")]
        private List<ScorocodeField> fields;
        public List<ScorocodeField> Fields => fields ?? new List<ScorocodeField>();

        [JsonProperty("system")]
        private bool system;
        public bool IsSystemCollection => system;

        [JsonProperty("notify")]
        private bool notify;
        [JsonProperty("indexes")]
        private List<Index> indexes;
        public List<Index> Indexes => indexes ?? new List<Index>();

        public ScorocodeCollection() { }

        public ScorocodeCollection(
                string id, string name, bool useDocsACL,
                ScorocodeACL ACL, ScorocodeTriggers triggers,
                List<ScorocodeField> fields, bool system, List<Index> indices, bool notify)
        {
            this.id = id;
            this.name = name;
            this.useDocsACL = useDocsACL;
            this.acl = ACL;
            this.triggers = triggers;
            this.fields = fields;
            this.system = system;
            this.indexes = indices;
            this.notify = notify;
        }

        public ScorocodeCollection setCollectionId(string id)
        {
            this.id = id;
            return this;
        }

        public ScorocodeCollection setCollectionName(string name)
        {
            this.name = name;
            return this;
        }

        public ScorocodeCollection setUseDocsACL(bool useDocsACL)
        {
            this.useDocsACL = useDocsACL;
            return this;
        }

        public ScorocodeCollection setACL(ScorocodeACL ACL)
        {
            this.acl = ACL;
            return this;
        }

        public ScorocodeCollection setTriggers(ScorocodeTriggers triggers)
        {
            this.triggers = triggers;
            return this;
        }

        public ScorocodeCollection setFields(List<ScorocodeField> fields)
        {
            this.fields = fields;
            return this;
        }

        public ScorocodeCollection setSystem(bool system)
        {
            this.system = system;
            return this;
        }

        public ScorocodeCollection setIndexes(List<Index> indexes)
        {
            this.indexes = indexes;
            return this;
        }

        public bool isNotify()
        {
            return notify;
        }

        public ScorocodeCollection setNotify(bool notify)
        {
            this.notify = notify;
            return this;
        }
    }
}