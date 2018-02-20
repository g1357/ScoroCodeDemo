using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ScorocodeUWP.Responses;
using ScorocodeUWP.ScorocodeObjects;

namespace ScorocodeUWP.Requests
{
    // Редакция 1.001 от 09.02.2018 ДГБ
    // Basen on Java file
    //  Created by Peter Staranchuk on 5/10/16

    public class RequestLoginUser
    {
        [JsonProperty("app")]
        public string App { get; }

        [JsonProperty("cli")]
        public string Cli { get; }

        [JsonProperty("email")]
        public string Email { get; }

        [JsonProperty("password")]
        public string Password { get; }

        public RequestLoginUser(ScorocodeSdkStateHolder stateHolder, String email, String password)
        {
            App = stateHolder.ApplicationId;
            Cli = stateHolder.ClientKey;
            Email = email;
            Password = password;
        }
    }
}