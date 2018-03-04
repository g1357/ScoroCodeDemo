using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class TypeCustom
    {
        [JsonProperty("days")]
        private int days;
        [JsonProperty("hours")]
        private int hours;
        [JsonProperty("minutes")]
        private int minutes;

        public TypeCustom() : this(0,0,0) { }

        public TypeCustom(int days, int hours, int minutes)
        {
            this.days = days;
            this.hours = hours;
            this.minutes = minutes;
        }

        public static String getName()
        {
            return "custom";
        }
    }
}