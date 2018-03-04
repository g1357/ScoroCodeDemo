using Newtonsoft.Json;
using ScorocodeUWP.Requests.Application;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Requests.Folders
{
    public class RequestDeleteFolder : AppBase
    {
        [JsonProperty("path")]
        private string path;

        public RequestDeleteFolder(ScorocodeSdkStateHolder stateHolder, string path)
            : base(stateHolder)
        {
            this.path = path;
        }
    }
}