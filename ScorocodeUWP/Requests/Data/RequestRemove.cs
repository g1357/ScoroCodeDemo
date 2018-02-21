using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Data
{
    public class RequestRemove
    {
        private string _app;
        private string _cli;
        private string _acc;
        private string _sess;
        private string _coll;
        private Dictionary<string, object> _query;
        private int limit;

        public RequestRemove(ScorocodeSdkStateHolder stateHolder, string collectionName,
                Dictionary<string, object> query = null, int limit = 0)
        {
            _app = stateHolder.ApplicationId;
            _cli = stateHolder.ClientKey;
            _acc = stateHolder.MasterKey;
            _sess = stateHolder.SessionId;
            _coll = collectionName;

            if (query != null)
            {
                _query = query;
            }
            this.limit = limit;
        }
    }
}