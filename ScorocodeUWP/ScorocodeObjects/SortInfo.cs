using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class SortInfo
    {
        private Dictionary<string, int> _info;

        [JsonProperty("info")]
        public Dictionary<string, int> Info
        {
            get
            {
                if (_info == null)
                {
                    _info = new Dictionary<string, int>();
                }
                return _info;
            }
        }

        public SortInfo()
        {
            _info = new Dictionary<string, int>();
        }

        public SortInfo(Dictionary<string, int> values)
        {
            _info = values;
        }

        public void SetAscendingFor(string fieldName)
        {
            _info.Add(fieldName, 1);
        }

        public void SetDescendingFor(String fieldName)
        {
            _info.Add(fieldName, -1);
        }
    }
}