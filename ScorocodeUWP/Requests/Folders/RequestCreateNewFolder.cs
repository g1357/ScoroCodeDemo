using Newtonsoft.Json;
using ScorocodeUWP.Requests.Application;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses.Folders
{
    public class RequestCreateNewFolder : AppBase
    {
        [JsonProperty("path")]
        private string path;

        public RequestCreateNewFolder(ScorocodeSdkStateHolder stateHolder, string path)
            : base(stateHolder)
        {
            this.path = path;
        }

    }
}