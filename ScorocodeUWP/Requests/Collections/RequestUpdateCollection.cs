﻿using Newtonsoft.Json;
using ScorocodeUWP.Requests.Application;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Collections
{
    public class RequestUpdateCollection : AppBase
    { 
        [JsonProperty("collection")]
        private ScorocodeCollection collection;
        public RequestUpdateCollection(ScorocodeSdkStateHolder stateHolder, string collectionId, 
            string collectionName, bool isUseDocsACL, ScorocodeACL ACL, bool notify)
            : base(stateHolder)
        {
            this.collection = new ScorocodeCollection()
                    .setCollectionName(collectionName)
                    .setUseDocsACL(isUseDocsACL)
                    .setACL(ACL)
                    .setCollectionId(collectionId)
                    .setNotify(notify)
                    .setTriggers(new ScorocodeTriggers());
        }
    }
}