using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Data
{
    public class RequestFind
    {
        [JsonProperty("app")]
        private string app;
        [JsonProperty("cli")]
        private string cli;
        [JsonProperty("acc")]
        private string acc;
        [JsonProperty("sess")]
        private string sess;
        [JsonProperty("coll")]
        private string coll;
        [JsonProperty("query")]
        private Dictionary<string, object> query;
        [JsonProperty("sort")]
        private Dictionary<string, int> sort;
        [JsonProperty("fields")]
        private List<string> fields;
        [JsonProperty("limit")]
        private int limit;
        [JsonProperty("skip")]
        private int skip;

        public RequestFind(ScorocodeCoreInfo stateHolder, string coll,
                Query query, SortInfo sort, List<String> fields,
                int limit, int skip)
        {
            this.app = stateHolder.getApplicationId();
            this.cli = stateHolder.getClientKey();
            this.acc = stateHolder.getMasterKey();
            this.sess = stateHolder.getSessionId();
            this.coll = coll;

            if (query != null)
            {
                this.query = query.getQueryInfo(); //.getInfo();
            }
            if (sort != null)
            {
                this.sort = sort.Info; //.getInfo();
            }
            this.fields = fields;
            this.limit = limit;
            this.skip = skip;
        }

    }
}