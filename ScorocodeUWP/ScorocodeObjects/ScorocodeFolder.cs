using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class ScorocodeFolder
    {
        [JsonProperty("_id")]
        private string _id;
        [JsonProperty("name")]
        private string name;
        [JsonProperty("path")]
        private string path;
        [JsonProperty("isScript")]
        private bool isScript;

        public ScorocodeFolder(string _id, string name, string path, bool isScript)
        {
            this._id = _id;
            this.name = name;
            this.path = path;
            this.isScript = isScript;
        }

        public string getFolderId()
        {
            return _id == null ? "" : _id;
        }

        public string getFolderName()
        {
            return name == null ? "" : name;
        }

        public string getFolderPath()
        {
            return path == null ? "" : path;
        }

        public bool isFolderContainScript()
        {
            return isScript;
        }
    }
}