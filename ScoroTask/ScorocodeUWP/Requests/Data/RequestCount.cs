using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Data
{
    public class RequestCount
    {
        private String app;
        private String cli;
        private String acc;
        private String sess;
        private String coll;
        private Dictionary<String, Object> query;

        public RequestCount(ScorocodeSdkStateHolder stateHolder,
            string coll, Query query = null)
        {
            this.app = stateHolder.ApplicationId;
            this.cli = stateHolder.ClientKey;
            this.acc = stateHolder.MasterKey;
            this.sess = stateHolder.SessionId;
            this.coll = coll;
            if (query != null)
            {
                this.query = query.getQueryInfo(); //.getInfo();
            }
        }
    }
}