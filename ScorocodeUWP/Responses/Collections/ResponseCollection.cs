﻿using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses.Collections
{
    public class ResponseCollection : ResponseCodes
    {
        [JsonProperty("collection")]
        private ScorocodeCollection collection;

        public ResponseCollection(ScorocodeCollection collection)
        {
            this.collection = collection;
        }

        public ScorocodeCollection Collection => collection;
    }
}