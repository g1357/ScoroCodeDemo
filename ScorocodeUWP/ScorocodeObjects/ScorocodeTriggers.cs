using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class ScorocodeTriggers
    {
        [JsonProperty("beforeInsert")]
        private Trigger beforeInsert;
        [JsonProperty("afterInsert")]
        private Trigger afterInsert;
        [JsonProperty("beforeUpdate")]
        private Trigger beforeUpdate;
        [JsonProperty("afterUpdate")]
        private Trigger afterUpdate;
        [JsonProperty("beforeRemove")]
        private Trigger beforeRemove;
        [JsonProperty("afterRemove")]
        private Trigger afterRemove;
        [JsonProperty("beforeFind")]
        private Trigger beforeFind;

        public ScorocodeTriggers()
        {
            beforeInsert = new Trigger();
            afterInsert = new Trigger();
            beforeUpdate = new Trigger();
            afterUpdate = new Trigger();
            beforeRemove = new Trigger();
            afterRemove = new Trigger();
            beforeFind = new Trigger();
        }

        public ScorocodeTriggers setBeforeInsert(Trigger beforeInsert)
        {
            this.beforeInsert = beforeInsert;
            return this;
        }

        public ScorocodeTriggers setAfterInsert(Trigger afterInsert)
        {
            this.afterInsert = afterInsert;
            return this;
        }

        public ScorocodeTriggers setBeforeUpdate(Trigger beforeUpdate)
        {
            this.beforeUpdate = beforeUpdate;
            return this;
        }

        public ScorocodeTriggers setAfterUpdate(Trigger afterUpdate)
        {
            this.afterUpdate = afterUpdate;
            return this;
        }

        public ScorocodeTriggers setBeforeRemove(Trigger beforeRemove)
        {
            this.beforeRemove = beforeRemove;
            return this;
        }

        public ScorocodeTriggers setAfterRemove(Trigger afterRemove)
        {
            this.afterRemove = afterRemove;
            return this;
        }

        public ScorocodeTriggers setBeforeFind(Trigger beforeFind)
        {
            this.beforeFind = beforeFind;
            return this;
        }

        public Trigger getBeforeInsert()
        {
            return beforeInsert == null ? (new Trigger()) : beforeInsert;
        }

        public Trigger getAfterInsert()
        {
            return afterInsert == null ? (new Trigger()) : afterInsert;
        }

        public Trigger getBeforeUpdate()
        {
            return beforeUpdate == null ? (new Trigger()) : beforeUpdate;
        }

        public Trigger getAfterUpdate()
        {
            return afterUpdate == null ? (new Trigger()) : afterUpdate;
        }

        public Trigger getBeforeRemove()
        {
            return beforeRemove == null ? (new Trigger()) : beforeRemove;
        }

        public Trigger getAfterRemove()
        {
            return afterRemove == null ? (new Trigger()) : afterRemove;
        }
        public Trigger getBeforeFind()
        {
            return beforeFind == null ? (new Trigger()) : beforeFind;
        }

    }
}