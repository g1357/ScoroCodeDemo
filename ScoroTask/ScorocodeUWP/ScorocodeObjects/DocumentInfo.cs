using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP
{
    public class DocumentInfo
    {
        private const string ID_KEY = "_id";
        [JsonProperty("doc")]
        private Dictionary<String, Object> content;

        public DocumentInfo()
        {
            content = new Dictionary<string, object>();
        }

        public DocumentInfo(Dictionary<string, object> documentContent)
        {
            if (documentContent == null)
                content = new Dictionary<string, object>();
            else
                content = new Dictionary<string, object>(documentContent);
        }

        public string GetId() => (string)content[ID_KEY];

        public Dictionary<string, object> GetFields()
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();

            foreach (var item in content)
            {
                if (item.Key.ToLower() == ID_KEY) continue;

                fields.Add(item.Key, item.Value);
            }
            return fields;
        }

        public object Get(String key)
        {
            if (content != null)
            {
                return content[key];
            }
            else
            {
                return new object();
            }
        }

        public string GetString(string key)
        {
            return Get(key).ToString();
        }

        public double GetDouble(string key)
        {
            double result;

            if (!double.TryParse(GetString(key), out result))
                result = 0;

            return result;
        }

        public int GetInt(string key)
        {
            int result;

            if (!int.TryParse(GetString(key), out result))
                result = 0;

            return result;
        }


        public DateTime GetDate(string key)
        {
            if (!DateTime.TryParse(GetString(key), out DateTime result))
                result = new DateTime();

            return result;
        }

        public long GetLong(string key)
        {
            if (!long.TryParse(GetString(key), out long result))
                result = 0;

            return result;
        }

        public bool GetBool(string key)
        {
            if (!bool.TryParse(GetString(key), out bool result))
                result = false;

            return result;
        }

        public void Put(string field, object value)
        {
            if (content != null)
                content.Add(field, value);
        }

        public Dictionary<string, object> GetContent()
        {
            return content;
        }
    }
}
