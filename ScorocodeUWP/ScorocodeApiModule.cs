using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP
{
    public static class ScorocodeApiModule
    {
        private static ScorocodeApi _scorocodeApi = new ScorocodeApi();
        public static ScorocodeApi scorocodeApi()
        {
            return _scorocodeApi;
        }
    }
}
