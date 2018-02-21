using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP
{
    public class CallbackLoginUser
    {
        public delegate void OnLoginSucceed(ResponseLogin responseLogin);
        public delegate void OnLoginFailed(string errorCode, string errorMessage);

        public OnLoginSucceed onLoginSucceed;
        public OnLoginFailed onLoginFailed;

    }
}
