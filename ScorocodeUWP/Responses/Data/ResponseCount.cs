﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses.Data
{
    public class ResponseCount : ResponseCodes
    {
        [JsonProperty("result")]
        private int result;
        public int Result
        {
            get => result;
            set { result = value; }
        }
    }
}