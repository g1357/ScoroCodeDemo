using Newtonsoft.Json;
using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses.Folders
{
    public class ResponseGetFoldersList : ResponseCodes
    {
        [JsonProperty("items")]
        private List<ScorocodeFolder> items;

        public ResponseGetFoldersList(List<ScorocodeFolder> items)
        {
            this.items = items;
        }

        public List<ScorocodeFolder> getFolders()
        {
            return items;
        }
    }
}