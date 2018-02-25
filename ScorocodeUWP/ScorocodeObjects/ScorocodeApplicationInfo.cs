using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class ScorocodeApplicationInfo
    {
        private string _id;
        private string appId;
        private string name;
        private string description;
        private string userId;
        private string serverId;
        private Limits limits;
        private Dictionary<string, ScorocodeCollection> schemas;
        private ScorocodePublicKeys accessKeys;
        private ScorocodeClientKeys clientKeys;
        private bool readOnly;
        private ScorocodeACLPublic ACLPublic;
        private Settings settings;
        private StorageInfo storage;
        private string stringId;
        private string npm;

        public ScorocodeApplicationInfo(string id, string appId, string name, string description, string userId,
                string serverId, Limits limits, Dictionary<string, ScorocodeCollection> schemas, ScorocodePublicKeys accessKeys,
                ScorocodeClientKeys clientKeys, bool readOnly, ScorocodeACLPublic ACLPublic,
                Settings settings, StorageInfo storage, string stringId, string npm) {
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
        this.ACLPublic = ACLPublic;
        this.settings = settings;
        this.storage = storage;
        this.stringId = stringId;
        this.npm = npm;
    }

    public String getId()
    {
        return _id == null ? "" : _id;
    }

    public String getAppId()
    {
        return appId == null ? "" : appId;
    }

    @NonNull

    public String getApplicationName()
    {

        return name == null ? "" : name;

    }



    @NonNull

    public String getDescription()
    {

        return description == null ? "" : description;

    }



    @NonNull

    public String getUserId()
    {

        return userId == null ? "" : userId;

    }



    @NonNull

    public String getServerId()
    {

        return serverId == null ? "" : serverId;

    }



    @NonNull

    public Limits getLimits()
    {

        return limits == null ? new Limits(0L, 0L, 0L, 0L, 0L, 0L, 0L) : limits;

    }



    @NonNull

    public List<ScorocodeCollection> getCollections()
    {

        List<ScorocodeCollection> scorocodeCollectionList = new ArrayList<>();

        for (String key : schemas.keySet())
        {

            scorocodeCollectionList.add(schemas.get(key));

        }

        return scorocodeCollectionList;

    }



    @NonNull

    public ScorocodePublicKeys getAccessKeys()
    {

        return accessKeys == null ? new ScorocodePublicKeys("", "", "", "", "") : accessKeys;

    }



    @NonNull

    public ScorocodeClientKeys getClientKeys()
    {

        return clientKeys == null ? new ScorocodeClientKeys("", "", "", "") : clientKeys;

    }



    @NonNull

    public boolean isReadonly()
    {

        return readonly;

    }



    @NonNull

    public ScorocodeACLPublic getACLPublic()
    {

        return ACLPublic == null ? new ScorocodeACLPublic(false, false, false, false) : ACLPublic;

    }



    @NonNull

    public Settings getSettings()
    {

        return settings == null ? new Settings(false, 0L, "", "", (new HashMap<String, MailTemplate>()), "") : settings;

    }



    @NonNull

    public StorageInfo getStorage()
    {

        return storage == null ? new StorageInfo("", "") : storage;

    }



    @NonNull

    public String getStringId()
    {

        return stringId == null ? "" : stringId;

    }



    @NonNull

    public String getNpm()
    {

        return npm == null ? "" : npm;

    }

}
}
}
