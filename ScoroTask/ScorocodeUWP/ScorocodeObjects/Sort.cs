using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    public class Sort : Dictionary<string, int>
    {
        private Dictionary<string, string> _values;
        public Dictionary<string, string> GetValues()
        {
            return _values;
        }

        public void SetValues(Dictionary<string, string> values)
        {
            _values = values;
        }
    }
}