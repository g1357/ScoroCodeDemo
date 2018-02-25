using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class ScorocodeField
    {
        [JsonProperty("name")]
        private string name;
        [JsonProperty("type")]
        private string type;
        [JsonProperty("target")]
        private string target;
        [JsonProperty("system")]
        private bool system;
        [JsonProperty("readonly")]
        private bool readOnly;
        [JsonProperty("required")]
        private bool required;

        public ScorocodeField() { }

        public ScorocodeField(string name, ScorocodeTypes type, string target, bool system, bool readOnly, bool required)
        {
            this.name = name;
            this.type = type.GetName();
            this.target = target;
            this.system = system;
            this.readOnly = readOnly;
            this.required = required;
        }

        public ScorocodeField setName(string name)
        {
            this.name = name;
            return this;
        }

        public ScorocodeField setType(string type)
        {
            this.type = type;
            return this;
        }

        public ScorocodeField setTarget(string target)
        {
            this.target = target;
            return this;
        }

        public ScorocodeField setSystem(bool system)
        {
            this.system = system;
            return this;
        }

        public ScorocodeField setReadonly(bool readOnly)
        {
            this.readOnly = readOnly;
            return this;
        }

        public ScorocodeField setRequired(bool required)
        {
            this.required = required;
            return this;
        }
        public String getFieldName()
        {
            return name == null ? "" : name;
        }

        public ScorocodeTypes getFieldType()
        {
            foreach (var item in ScorocodeTypes.TypeArray.Values())
            {
                if (type.ToUpper() == item.Value.ToUpper())
                    return (ScorocodeTypes)item.Key;
            }
            return ScorocodeTypes.TypeWrong;
        }

        public String getTarget()
        {
            return target == null ? "" : target;
        }

        public bool isSystemField()
        {
            return system;
        }

        public bool isReadonlyField()
        {
            return readOnly;
        }

        public boo isRequiredField()
        {
            return required;
        }
    }
}
