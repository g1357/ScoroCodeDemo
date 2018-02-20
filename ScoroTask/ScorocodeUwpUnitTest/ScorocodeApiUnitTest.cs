
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScorocodeUWP;
using ScorocodeUWP.Requests;
using ScorocodeUWP.Responses;
using ScorocodeUWP.ScorocodeObjects;

namespace ScorocodeUwpUnitTest
{
    [TestClass]
    public class ScorocodeApiUnitTest
    {
        [TestMethod]
        public async void TestMethod_RegisterUser1()
        {
            string UserName = "";
            string EMail = "";
            string Password = "";

            var sc = new ScorocodeApi();
            ScorocodeSdkStateHolder stateHolder = new ScorocodeSdkStateHolder(
                /* applicationId */ "",
                /* clientKey */     "",
                /* masterKey */     "",
                /* fileKey */       "",
                /* messageKey */    "",
                /* scriptKey */     "",
                /* webSocket */     ""
            );
            RequestRegisterUser requestRegisterUsers;

            Dictionary<string, object> doc = new Dictionary<string, object>()
            {
                { "key1", "value1" },
                { "key2", "value2" }
            };
            DocumentInfo docInfo = new DocumentInfo(doc);
            requestRegisterUsers = new RequestRegisterUser(stateHolder,
                UserName, EMail, Password, docInfo);
            ResponseCodes responsCodes = await sc.RegisterAsync(requestRegisterUsers);
        }
    }
}
