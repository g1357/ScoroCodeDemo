﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses.Data
{
    public class ResponseResult : ResponseCodes
    {
        [JsonProperty("result")]
        public int Result;
    }
}
