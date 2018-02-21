﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class UpdateInfo
    {
        [JsonProperty("info")]
        public Dictionary<string, Dictionary<string, object>> Info = 
            new Dictionary<string, Dictionary<string, object>>();
    }
}
