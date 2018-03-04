using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class Repeat
    {
        [JsonProperty("custom")]
        private TypeCustom custom;
        [JsonProperty("daily")]
        private TypeDaily daily;
        [JsonProperty("monthly")]
        private TypeMonthly monthly;

        public Repeat() { }

        public Repeat(TypeCustom custom, TypeDaily daily, TypeMonthly monthly)
        {
            this.custom = custom;
            this.daily = daily;
            this.monthly = monthly;
        }

        public Repeat setCustom(TypeCustom custom)
        {
            this.custom = custom;
            return this;
        }

        public Repeat setDaily(TypeDaily daily)
        {
            this.daily = daily;
            return this;
        }

        public Repeat setMonthly(TypeMonthly monthly)
        {
            this.monthly = monthly;
            return this;
        }

        public TypeCustom getCustom()
        {
            return custom == null ? (new TypeCustom()) : custom;
        }

        public TypeDaily getDaily()
        {
            return daily == null ? (new TypeDaily()) : daily;
        }

        public TypeMonthly getMonthly()
        {
            return monthly == null ? (new TypeMonthly()) : monthly;
        }
    }
}