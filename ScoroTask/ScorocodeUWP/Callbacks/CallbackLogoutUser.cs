using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP
{
    public class CallbackLogoutUser
    {
        public delegate void OnLogoutSucceed();
        public delegate void OnLogoutFailed(string errorCode, string eroorMessage);

        public OnLogoutSucceed onLogoutSucceed;
        public OnLogoutFailed onLogoutFailed;
    }
}
