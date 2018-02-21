using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ScorocodeUWP.Responses;

namespace ScorocodeUWP
{
    public class ResponseLogin : ResponseCodes
    {
        private Result _result;
        [JsonProperty("result")]
        public Result result
        {
            get { return _result; }
            set { _result = value; }
        }

        public Result getResult()
        {
            return _result;
        }
        public void setResult(Result result)
        {
            this._result = result;
        }

        public class Result
        {
            private string sessionId;
            [JsonProperty("sessionId")]
            public string SessionId
            {
                get { return sessionId; }
                set { sessionId = value; }
            }
            private Dictionary<String, Object> user = new Dictionary<string, object>();
            [JsonProperty("user")]
            public Dictionary<string, object> User
            {
                get { return user; }
                set { user = value; }
            }
            public String getSessionId()
            {
                return sessionId;
            }
            public void setSessionId(String sessionId)
            {
                this.sessionId = sessionId;
            }
            public DocumentInfo getUserInfo()
            {
                return new DocumentInfo(user);
            }
            public void setUser(Dictionary<String, Object> user)
            {
                this.user = user;
            }
        }

    }
}
