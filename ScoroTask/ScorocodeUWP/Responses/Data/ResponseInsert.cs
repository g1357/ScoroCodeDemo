using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses.Data
{
    public class ResponseInsert : ResponseCodes
    {

        private Dictionary<string, object> _result;
        public Dictionary<string, object> Result
        {
            get { return _result; }
            set { _result = value;  }
        }

        public DocumentInfo GetResult()
        {
            return new DocumentInfo(_result);
        }
    }
}