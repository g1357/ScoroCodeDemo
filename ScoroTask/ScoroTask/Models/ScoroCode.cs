using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoroTask.Models
{

    [JsonObject("limits")]
    public class Limits
    {

        [JsonProperty("rps")]
        public int Rps { get; set; }

        [JsonProperty("store")]
        public long Store { get; set; }

        [JsonProperty("pushValue")]
        public int PushValue { get; set; }

        [JsonProperty("pushUsed")]
        public int PushUsed { get; set; }

        [JsonProperty("push")]
        public int Push { get; set; }

        [JsonProperty("developers")]
        public int Developers { get; set; }

        [JsonProperty("ws")]
        public int Ws { get; set; }

        [JsonProperty("scriptTimeout")]
        public int ScriptTimeout { get; set; }

        [JsonProperty("scriptsLimit")]
        public int ScriptsLimit { get; set; }

        [JsonProperty("syncScripts")]
        public int SyncScripts { get; set; }

        [JsonProperty("vm")]
        public int Vm { get; set; }
    }

    public class ACL
    {

        [JsonProperty("create")]
        public IList<string> create { get; set; }

        [JsonProperty("read")]
        public IList<string> Read { get; set; }

        [JsonProperty("remove")]
        public IList<string> Remove { get; set; }

        [JsonProperty("update")]
        public IList<string> Update { get; set; }
    }

    public class AfterInsert
    {

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }

    public class AfterRemove
    {

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }

    public class AfterUpdate
    {

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }

    public class BeforeFind
    {

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }

    public class BeforeInsert
    {

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }

    public class BeforeRemove
    {

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }

    public class BeforeUpdate
    {

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
    }

    public class Triggers
    {

        [JsonProperty("afterInsert")]
        public AfterInsert AfterInsert { get; set; }

        [JsonProperty("afterRemove")]
        public AfterRemove AfterRemove { get; set; }

        [JsonProperty("afterUpdate")]
        public AfterUpdate AfterUpdate { get; set; }

        [JsonProperty("beforeFind")]
        public BeforeFind BeforeFind { get; set; }

        [JsonProperty("beforeInsert")]
        public BeforeInsert BeforeInsert { get; set; }

        [JsonProperty("beforeRemove")]
        public BeforeRemove BeforeRemove { get; set; }

        [JsonProperty("beforeUpdate")]
        public BeforeUpdate BeforeUpdate { get; set; }
    }

    public class Field
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("system")]
        public bool System { get; set; }

        [JsonProperty("readonly")]
        public bool Readonly { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }
    }

    public class Devices
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("useDocsACL")]
        public bool UseDocsACL { get; set; }

        [JsonProperty("notify")]
        public bool Notify { get; set; }

        [JsonProperty("ACL")]
        public ACL ACL { get; set; }

        [JsonProperty("triggers")]
        public Triggers Triggers { get; set; }

        [JsonProperty("fields")]
        public IList<Field> Fields { get; set; }

        [JsonProperty("indexes")]
        public IList<object> Indexes { get; set; }

        [JsonProperty("system")]
        public bool System { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("linkTimeout")]
        public int LinkTimeout { get; set; }
    }

    //public class Field
    //{

    //    [JsonProperty("id")]
    //    public string id { get; set; }

    //    [JsonProperty("name")]
    //    public string name { get; set; }

    //    [JsonProperty("type")]
    //    public string type { get; set; }

    //    [JsonProperty("target")]
    //    public string target { get; set; }

    //    [JsonProperty("description")]
    //    public string description { get; set; }

    //    [JsonProperty("system")]
    //    public bool system { get; set; }

    //    [JsonProperty("readonly")]
    //    public bool readonly { get; set; }

    //[JsonProperty("required")]
    //public bool required { get; set; }
    //    }

    public class Roles
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("useDocsACL")]
        public bool UseDocsACL { get; set; }

        [JsonProperty("notify")]
        public bool Notify { get; set; }

        [JsonProperty("ACL")]
        public ACL ACL { get; set; }

        [JsonProperty("triggers")]
        public Triggers Triggers { get; set; }

        [JsonProperty("fields")]
        public IList<Field> Fields { get; set; }

        [JsonProperty("indexes")]
        public IList<object> Indexes { get; set; }

        [JsonProperty("system")]
        public bool System { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("linkTimeout")]
        public int LinkTimeout { get; set; }
    }

    //    public class Field
    //{

    //    [JsonProperty("id")]
    //    public string id { get; set; }

    //    [JsonProperty("name")]
    //    public string name { get; set; }

    //    [JsonProperty("type")]
    //    public string type { get; set; }

    //    [JsonProperty("target")]
    //    public string target { get; set; }

    //    [JsonProperty("description")]
    //    public string description { get; set; }

    //    [JsonProperty("system")]
    //    public bool system { get; set; }

    //    [JsonProperty("readonly")]
    //    public bool readonly { get; set; }

    //[JsonProperty("required")]
    //public bool required { get; set; }
    //    }

    public class Users
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("useDocsACL")]
        public bool UseDocsACL { get; set; }

        [JsonProperty("notify")]
        public bool Notify { get; set; }

        [JsonProperty("ACL")]
        public ACL ACL { get; set; }

        [JsonProperty("triggers")]
        public Triggers Triggers { get; set; }

        [JsonProperty("fields")]
        public IList<Field> Fields { get; set; }

        [JsonProperty("indexes")]
        public IList<object> Indexes { get; set; }

        [JsonProperty("system")]
        public bool System { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("linkTimeout")]
        public int LinkTimeout { get; set; }
    }

    public class Schemas
    {

        [JsonProperty("devices")]
        public Devices Devices { get; set; }

        [JsonProperty("roles")]
        public Roles Roles { get; set; }

        [JsonProperty("users")]
        public Users Users { get; set; }
    }

    public class AccessKeys
    {

        [JsonProperty("fileKey")]
        public string FileKey { get; set; }

        [JsonProperty("masterKey")]
        public string MasterKey { get; set; }

        [JsonProperty("messageKey")]
        public string MessageKey { get; set; }

        [JsonProperty("scriptKey")]
        public string ScriptKey { get; set; }

        [JsonProperty("websocketKey")]
        public string WebsocketKey { get; set; }
    }

    public class ClientKeys
    {

        [JsonProperty("android")]
        public string Android { get; set; }

        [JsonProperty("ios")]
        public string Ios { get; set; }

        [JsonProperty("javascript")]
        public string Javascript { get; set; }

        [JsonProperty("winphone")]
        public string Winphone { get; set; }
    }

    public class ACLPublic
    {

        [JsonProperty("create")]
        public bool Create { get; set; }

        [JsonProperty("read")]
        public bool Read { get; set; }

        [JsonProperty("remove")]
        public bool Remove { get; set; }

        [JsonProperty("update")]
        public bool Update { get; set; }
    }

    public class Forgot
    {

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }

    public class Reg
    {

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }

    public class MailTemplates
    {

        [JsonProperty("forgot")]
        public Forgot Forgot { get; set; }

        [JsonProperty("reg")]
        public Reg Reg { get; set; }
    }

    public class Smtp
    {
    }

    public class IosCertificate
    {

        [JsonProperty("notBefore")]
        public DateTime NotBefore { get; set; }

        [JsonProperty("notAfter")]
        public DateTime NotAfter { get; set; }

        [JsonProperty("isDevelop")]
        public bool IsDevelop { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Settings
    {

        [JsonProperty("emailVerified")]
        public bool EmailVerified { get; set; }

        [JsonProperty("sessionTimeout")]
        public int SessionTimeout { get; set; }

        [JsonProperty("androidApiKey")]
        public string AndroidApiKey { get; set; }

        [JsonProperty("gcmSenderId")]
        public string GcmSenderId { get; set; }

        [JsonProperty("mailTemplates")]
        public MailTemplates MailTemplates { get; set; }

        [JsonProperty("smtp")]
        public Smtp Smtp { get; set; }

        [JsonProperty("iosCertificate")]
        public IosCertificate IosCertificate { get; set; }
    }

    public class Storage
    {

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }

    public class App
    {

        [JsonProperty("_id")]
        public string _id { get; set; }

        [JsonProperty("appId")]
        public string AppId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("serverId")]
        public string ServerId { get; set; }

        [JsonProperty("limits")]
        public Limits Limits { get; set; }

        [JsonProperty("schemas")]
        public Schemas Schemas { get; set; }

        [JsonProperty("accessKeys")]
        public AccessKeys AccessKeys { get; set; }

        [JsonProperty("clientKeys")]
        public ClientKeys ClientKeys { get; set; }

        [JsonProperty("ACLPublic")]
        public ACLPublic ACLPublic { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }

        [JsonProperty("storage")]
        public Storage Storage { get; set; }

        [JsonProperty("npm")]
        public string Npm { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty("members")]
        public IList<string> Members { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("readonly")]
        public bool Readonly { get; set; }

        [JsonProperty("lastAccess")]
        public DateTime LastAccess { get; set; }

        [JsonProperty("totalUsed")]
        public int TotalUsed { get; set; }

        [JsonProperty("dataSize")]
        public int DataSize { get; set; }

        [JsonProperty("indexSize")]
        public int IndexSize { get; set; }

        [JsonProperty("filesStorageSize")]
        public int FilesStorageSize { get; set; }
    }

    public class Example
    {

        [JsonProperty("app")]
        public App App { get; set; }

        [JsonProperty("error")]
        public bool Error { get; set; }
    }


}
