using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class TypeDaily
    {
        [JsonProperty("on")]
        private List<int> on;
        [JsonProperty("hours")]
        private int hours;
        [JsonProperty("minutes")]
        private int minutes;

        public TypeDaily() : this(new List<int>(), 0, 0) { }

        public TypeDaily(List<int> on, int hours, int minutes)
        {
            this.on = on;
            this.hours = hours;
            this.minutes = minutes;
        }

        public static String getName()
        {
            return "daily";
        }
    }
}