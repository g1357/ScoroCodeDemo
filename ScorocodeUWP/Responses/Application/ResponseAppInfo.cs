﻿using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses.Application
{
    public class ResponseAppInfo : ResponseCodes
    {
        [JsonProperty("app")]
        private ScorocodeApplicationInfo app;

        public ResponseAppInfo(ScorocodeApplicationInfo applicationInfo)
        {
            this.app = applicationInfo;
        }

        public ScorocodeApplicationInfo getApplicationInfo()
        {
            return app;
        }
    }
}
