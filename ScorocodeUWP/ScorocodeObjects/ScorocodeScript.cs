using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class ScorocodeScript
    {
        [JsonProperty("_id")]
        private string _id;
        [JsonProperty("name")]
        private string name;
        [JsonProperty("path")]
        private string path;
        [JsonProperty("description")]
        private string description;
        [JsonProperty("code")]
        private string code;
        [JsonProperty("isActiveJob")]
        private bool isActiveJob;
        [JsonProperty("jobStartAt")]
        private string jobStartAt;
        [JsonProperty("jobType")]
        private string jobType;
        [JsonProperty("repeat")]
        private Repeat repeat;
        [JsonProperty("nextRun")]
        private string nextRun;
        [JsonProperty("ACL")]
        private List<string> ACL;

        public ScorocodeScript() { }

        public ScorocodeScript(string name, string path, string description, string code,
                               bool isActiveJob, string jobStartAt, JobType jobType, Repeat repeat, string nextRun, List<string> ACL)
        {
            this.name = name;
            this.path = path;
            this.description = description;
            this.code = code;
            this.isActiveJob = isActiveJob;
            this.jobType = jobType.GetName();
            this.repeat = repeat;
            this.jobStartAt = jobStartAt;
            this.nextRun = nextRun;
            this.ACL = ACL;
        }

        public ScorocodeScript setScriptId(string _id)
        {
            this._id = _id;
            return this;
        }

        public ScorocodeScript setScriptName(string name)
        {
            this.name = name;
            return this;
        }

        public ScorocodeScript setScriptPath(string path)
        {
            this.path = path;
            return this;
        }

        public ScorocodeScript setScriptDescription(string description)
        {
            this.description = description;
            return this;
        }

        public ScorocodeScript setScriptSourceCode(string code)
        {
            this.code = code;
            return this;
        }

        public ScorocodeScript setIsActiveJob(bool activeJob)
        {
            isActiveJob = activeJob;
            return this;
        }

        public ScorocodeScript setJobStartAt(string jobStartAt)
        {
            this.jobStartAt = jobStartAt;
            return this;
        }

        public ScorocodeScript setJobType(string jobType)
        {
            this.jobType = jobType;
            return this;
        }

        public ScorocodeScript setRepeat(Repeat repeat)
        {
            this.repeat = repeat;
            return this;
        }

        public ScorocodeScript setNextRun(string nextRun)
        {
            this.nextRun = nextRun;
            return this;
        }

        public ScorocodeScript setScriptACL(List<string> ACL)
        {
            this.ACL = ACL;
            return this;
        }

        public string getScriptName()
        {
            return name == null ? "" : name;
        }

        public string getScriptPath()
        {
            return path == null ? " " : path;
        }

        public string getScriptDescription()
        {
            return description == null ? "" : description;
        }

        public string getScriptSourceCode()
        {
            return code == null ? "" : code;
        }

        public bool IsActiveJob()
        {
            return isActiveJob;
        }

        public string getJobStartAt()
        {
            return jobStartAt == null ? "" : jobStartAt;
        }

        public string getJobType()
        {
            return jobType == null ? "" : jobType;
        }

        public Repeat getRepeat()
        {
            return repeat == null ? (new Repeat()) : repeat;
        }

        public string getNextRun()
        {
            return nextRun;
        }

        public List<string> getACL()
        {
            return ACL == null ? new List<string>() : ACL;
        }

        public string getScriptId()
        {
            return _id == null ? "" : _id;
        }

    }
    public enum JobType
    {
        CUSTOM = 0,     // "custom"
        DAILY = 1,      // "daily"
        MONTHLY = 2     // "monthly"
    }

    public static class Extensions2
    {
        private static Dictionary<int, string> jobTypeNames = new Dictionary<int, string>()
        {
            { 0, "custom" }, { 1, "daily" }, { 2, "monthly" }
        };

        public static string GetName(this JobType jobType)
        {
            int index = (int)jobType;
            return index >= 0 && index <= 2 ? jobTypeNames[index] : jobTypeNames[0];
        }

        public static Dictionary<int, string> Values(this JobType jobType)
        {
            return jobTypeNames;
        }
    }

    //private enum JobType
    //{
    //    CUSTOM(TypeCustom.getName()),
    //DAILY(TypeDaily.getName()),
    //MOTHLY(TypeMonthly.getName());

    //private string name;
    //JobType(string name)
    //{
    //    this.name = name;
    //}

    //public String getName()
    //{
    //    return name;
    //}
}