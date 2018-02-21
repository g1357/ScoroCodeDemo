using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;

namespace ScorocodeUWP.Requests
{
    // Редакция 1.001 от 09.02.2018 ДГБ
    // Basen on Java file
    //  Created by Peter Staranchuk on 5/10/16

    public class RequestLogoutUser
    {
        [JsonProperty("app")]
        public string App { get; }
        [JsonProperty("cli")]
        public string Cli { get; }
        [JsonProperty("sess")]
        public string Sess { get; }

        public RequestLogoutUser(ScorocodeSdkStateHolder stateHolder)
        {
            App = stateHolder.ApplicationId;
            Cli = stateHolder.ClientKey;
            Sess = stateHolder.SessionId;
        }

    }
}
