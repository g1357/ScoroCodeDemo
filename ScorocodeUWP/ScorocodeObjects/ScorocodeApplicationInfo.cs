using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class ScorocodeApplicationInfo
    {
        [JsonProperty("_id")]
        private string _id;
        [JsonProperty("appId")]
        private string appId;
        [JsonProperty("name")]
        private string name;
        [JsonProperty("description")]
        private string description;
        [JsonProperty("userId")]
        private string userId;
        [JsonProperty("serverId")]
        private string serverId;
        [JsonProperty("limits")]
        private Limits limits;
        [JsonProperty("schemas")]
        private Dictionary<string, ScorocodeCollection> schemas;
        [JsonProperty("accessKeys")]
        private ScorocodePublicKeys accessKeys;
        [JsonProperty("clientKeys")]
        private ScorocodeClientKeys clientKeys;
        [JsonProperty("readonly")]
        private bool readOnly;
        [JsonProperty("ACLPublic")]
        private ScorocodeACLPublic aclPublic;
        [JsonProperty("settings")]
        private Settings settings;
        [JsonProperty("storage")]
        private StorageInfo storage;
        [JsonProperty("stringId")]
        private string stringId;
        [JsonProperty("npm")]
        private string npm;

        public ScorocodeApplicationInfo(string id, string appId, string name, string description, string userId,
                string serverId, Limits limits, Dictionary<string, ScorocodeCollection> schemas, ScorocodePublicKeys accessKeys,
                ScorocodeClientKeys clientKeys, bool readOnly, ScorocodeACLPublic ACLPublic,
                Settings settings, StorageInfo storage, string stringId, string npm)
        {
            this._id = id;
            this.appId = appId;
            this.name = name;
            this.description = description;
            this.userId = userId;
            this.serverId = serverId;
            this.limits = limits;
            this.schemas = schemas;
            this.accessKeys = accessKeys;
            this.clientKeys = clientKeys;
            this.readOnly = readOnly;
            this.aclPublic = ACLPublic;
            this.settings = settings;
            this.storage = storage;
            this.stringId = stringId;
            this.npm = npm;
        }

        public string Id => _id ?? "";

        public string AppId => appId ?? "";

        public string ApplicationName => name ?? "";

        public string Description => description ?? "";

        public string UserId => userId ?? "";

        public string ServerId => serverId ?? "";

        public Limits Limits => limits ?? new Limits(0L, 0L, 0L, 0L, 0L, 0L, 0L);

        public List<ScorocodeCollection> Collections()
        {
            List<ScorocodeCollection> scorocodeCollectionList = new List<ScorocodeCollection>();

            foreach (var item in schemas)
            {
                scorocodeCollectionList.Add(item.Value);
            }
            return scorocodeCollectionList;
        }

        public ScorocodePublicKeys AccessKeys => accessKeys ?? new ScorocodePublicKeys("", "", "", "", "");

        public ScorocodeClientKeys ClientKeys => clientKeys ?? new ScorocodeClientKeys("", "", "", "");

        public bool IsReadonly => readOnly;

        public ScorocodeACLPublic AclPublic => aclPublic ?? new ScorocodeACLPublic(false, false, false, false);
        public Settings GetSettings => settings ?? new Settings(false, 0L, "", "", (new Dictionary<String, MailTemplate>()), new SMTP());

        public StorageInfo Storage => storage ?? new StorageInfo("", "");

        public string StringId => stringId ?? "";

        public string Npm => npm ?? "";
    }
}
