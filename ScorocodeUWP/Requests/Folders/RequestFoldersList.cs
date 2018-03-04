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
    public class RequestFoldersList : AppBase
    {
        [JsonProperty("path")]
        private String path;

        public RequestFoldersList(ScorocodeSdkStateHolder stateHolder, String path)
            : base(stateHolder)
        {
            this.path = path;
        }
    }
}