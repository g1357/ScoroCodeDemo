using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class TypeMonthly
    {
        [JsonProperty("on")]
        private List<int> on;
        [JsonProperty("days")]
        private List<int> days;
        [JsonProperty("lastDate")]
        private bool lastDate;
        [JsonProperty("hours")]
        private int hours;
        [JsonProperty("minutes")]
        private int minutes;

        public TypeMonthly() : this(new List<int>(), new List<int>(), false, 0, 0) { }

        public TypeMonthly(List<int> on, List<int> days, bool lastDate, int hours, int minutes)
        {
            this.on = on;
            this.days = days;
            this.lastDate = lastDate;
            this.hours = hours;
            this.minutes = minutes;
        }

        public static String getName()
        {
            return "monthly";
        }

    }
}