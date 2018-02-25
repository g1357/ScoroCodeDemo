using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class ScorocodeACL
    {
        private List<string> create;
        private List<string> read;
        private List<string> remove;
        private List<string> update;

        public ScorocodeACL() { }

        public ScorocodeACL(List<string> create, List<string> read, List<string> remove, List<string> update)
        {
            this.create = create;
            this.read = read;
            this.remove = remove;
            this.update = update;
        }

        public List<string> getCreate()
        {
            //return create == null ? (new List<string>()) : create;
            return create ?? new List<string>();
        }

        public List<string> getRead()
        {
            return read == null ? (new List<string>()) : read;
        }

        public List<string> getRemove()
        {
            return remove == null ? (new List<string>()) : remove;
        }

        public List<string> getUpdate()
        {
            return update == null ? (new List<string>()) : update;
        }
    }
}