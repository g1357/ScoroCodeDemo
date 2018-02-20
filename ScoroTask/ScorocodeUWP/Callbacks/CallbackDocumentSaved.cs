using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP
{
    public class CallbackDocumentSaved
    {
        public delegate void OnDocumentSaved();
        public delegate void OnDocumentSavedFailed(string errorCode, string errorMessage);

        public OnDocumentSaved onDocumentSaved;
        public OnDocumentSavedFailed onDocumentSavedFailed;
    }
}
