using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;

namespace ScorocodeUWP.Requests
{
    // Редакция 2.001 от 09.02.2018 ДГБ
    // Basen on Java file
    //  Created by Peter Staranchuk on 5/10/16

    public class RequestRegisterUser
    {
        [JsonProperty("app")]
        private String app;
        [JsonProperty("cli")]
        private String cli;
        [JsonProperty("acc")]
        private String acc;
        [JsonProperty("username")]
        private String username;
        [JsonProperty("email")]
        private String email;
        [JsonProperty("password")]
        private String password;
        [JsonProperty("doc")]
        private Dictionary<String, Object> doc = new Dictionary<string, object>();

        public RequestRegisterUser(ScorocodeSdkStateHolder stateHolder, String username, String email, String password, DocumentInfo doc)
        {
            this.app = stateHolder.ApplicationId;
            this.cli = stateHolder.ClientKey;
            this.acc = stateHolder.MasterKey;
            this.email = email;
            this.username = username;
            this.password = password;

            if (doc != null)
            {
                this.doc = doc.GetContent();
            }
        }

        public RequestRegisterUser(ScorocodeSdkStateHolder stateHolder, String username, String email, String password)
            : this(stateHolder, username, email, password, null)
        {
        }
    }
}