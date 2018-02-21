using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP
{
    public class CallbackRegisterUser
    {
        public delegate void OnRegisterSucceed();
        public delegate void OnRegisterFailed(string errorCode, string errorMessage);

        public OnRegisterSucceed onRegisterSucced;
        public OnRegisterFailed onRegisterFailed;
    }

    public class test
    {
        //public test()
        //{
        //    Testing(new CallbackRegisterUser()
        //    {
        //        onRegisterSucced = delegate () { },
        //        onRegisterFailed = delegate (string eC, string eM) { }
        //    });
        //}

        //public void  Testing(CallbackRegisterUser callback)
        //{

        //}
    }
}
