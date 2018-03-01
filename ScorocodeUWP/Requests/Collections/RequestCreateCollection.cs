using Newtonsoft.Json;
using ScorocodeUWP.Requests.Application;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Collections
{
    public class RequestCreateCollection : AppBase
    {
        [JsonProperty("collection")]
        private CreateCollection collection;


        class CreateCollection
        {
            [JsonProperty("name")]
            private string name;

            [JsonProperty("useDocsACL")]
            private bool useDocsACL;

            [JsonProperty("ACL")]
            private ScorocodeACL acl;

            public CreateCollection(string collectionName, bool isUseDocsACL, ScorocodeACL ACL)
            {
                name = collectionName;
                useDocsACL = isUseDocsACL;
                acl = ACL;
            }
        }
        //private ScorocodeCollection collection;

        public RequestCreateCollection(ScorocodeSdkStateHolder stateHolder, string collectionName,
            bool isUseDocsACL, ScorocodeACL ACL) : base(stateHolder)
        {
            collection = new CreateCollection(collectionName, isUseDocsACL, ACL);
            //    this.collection = new ScorocodeCollection()
            //            .setCollectionName(collectionName)
            //            .setUseDocsACL(isUseDocsACL)
            //            .setACL(ACL)
            //            .setNotify(false)
            //            .setTriggers(new ScorocodeTriggers());
        }

        //public RequestCreateCollection(ScorocodeSdkStateHolder stateHolder, string collectionName, 
        //    bool isUseDocsACL, ScorocodeACL ACL, bool notify) : base(stateHolder)
        //{
        //    this.collection = new ScorocodeCollection()
        //            .setCollectionName(collectionName)
        //            .setUseDocsACL(isUseDocsACL)
        //            .setACL(ACL)
        //            .setNotify(notify);
        //}
    }
}