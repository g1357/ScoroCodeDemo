
using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScorocodeUWP;
using ScorocodeUWP.Requests.Data;
using ScorocodeUWP.Responses.Data;
using ScorocodeUWP.ScorocodeObjects;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ScorocodeSdkStateHolder stateHolder = new ScorocodeSdkStateHolder(
                /* applicationId */ "228730d6c20044fc85f8a5c8b015e0e7",
                /* clientKey */ "b93d0e6f7f0e4c18955f580c082345cc",
                /* masterKey */ "01db6a43743e4492a7bdef1a3be3a395",
                /* fileKey */ "deb3d951109d43069baba7b8e5424442",
                /* messageKey */ "80704b44194f4e1282986e5d68942848",
                /* scriptKey */ "c27ad4e97a784072b029dd02f68c347c",
                /* websocketKey */ "7b1966691002464e92066b2693135236");
            Assert.AreEqual(stateHolder.ApplicationId, "228730d6c20044fc85f8a5c8b015e0e7");
            Assert.AreEqual(stateHolder.ClientKey, "b93d0e6f7f0e4c18955f580c082345cc");
            Assert.AreEqual(stateHolder.MasterKey, "01db6a43743e4492a7bdef1a3be3a395");
            Assert.AreEqual(stateHolder.FileKey, "deb3d951109d43069baba7b8e5424442");
            Assert.AreEqual(stateHolder.MessageKey, "80704b44194f4e1282986e5d68942848");
            Assert.AreEqual(stateHolder.ScriptKey, "c27ad4e97a784072b029dd02f68c347c");
            Assert.AreEqual(stateHolder.WebSocket, "7b1966691002464e92066b2693135236");

            Assert.IsTrue(string.IsNullOrEmpty(stateHolder.SessionId));
            Assert.AreEqual(stateHolder.BaseUrl, "https://api.scorocode.ru");
        }

        //[TestMethod]
        //public async Task TestMethod2()
        //{
        //    var sc = new ScorocodeApi();
        //    ScorocodeSdkStateHolder stateHolder = new ScorocodeSdkStateHolder(
        //                    /* applicationId */ "228730d6c20044fc85f8a5c8b015e0e7",
        //                    /* clientKey */ "b93d0e6f7f0e4c18955f580c082345cc",
        //                    /* masterKey */ "01db6a43743e4492a7bdef1a3be3a395",
        //                    /* fileKey */ "deb3d951109d43069baba7b8e5424442",
        //                    /* messageKey */ "80704b44194f4e1282986e5d68942848",
        //                    /* scriptKey */ "c27ad4e97a784072b029dd02f68c347c",
        //                    /* websocketKey */ "7b1966691002464e92066b2693135236");

        //    RequestInsert requestInsert;
        //    ResponseInsert responsInsert;

        //    requestInsert = new RequestInsert(stateHolder, "tasks");
        //    responsInsert = await sc.InsertAsync(requestInsert);

        //    Assert.IsFalse(responsInsert.Error);
        //    Assert.AreEqual(responsInsert.ErrCode, "");
        //    Assert.AreEqual(responsInsert.ErrMsg, "");
        //}

        //[TestMethod]
        //public async Task TestMethod2a()
        //{
        //    var sc = new ScorocodeApi();
        //    ScorocodeSdkStateHolder stateHolder = new ScorocodeSdkStateHolder(
        //                    /* applicationId */ "228730d6c20044fc85f8a5c8b015e0e7",
        //                    /* clientKey */ "b93d0e6f7f0e4c18955f580c082345cc",
        //                    /* masterKey */ "01db6a43743e4492a7bdef1a3be3a395",
        //                    /* fileKey */ "deb3d951109d43069baba7b8e5424442",
        //                    /* messageKey */ "80704b44194f4e1282986e5d68942848",
        //                    /* scriptKey */ "c27ad4e97a784072b029dd02f68c347c",
        //                    /* websocketKey */ "7b1966691002464e92066b2693135236");

        //    RequestInsert requestInsert;
        //    ResponseInsert responsInsert;

        //    DocumentInfo docInfo = new DocumentInfo();
        //    docInfo.Put("bossComment", "Good Job!");
        //    docInfo.Put("name", "Kill Bill!");

        //    requestInsert = new RequestInsert(stateHolder, "tasks", docInfo);
        //    responsInsert = await sc.InsertAsync(requestInsert);

        //    Assert.IsFalse(responsInsert.Error);
        //    Assert.AreEqual(responsInsert.ErrCode, "");
        //    Assert.AreEqual(responsInsert.ErrMsg, "");
        //}

        [TestMethod]
        public void TestMethod2b()
        {
            Task.Run(async () =>
            {
                var sc = new ScorocodeApi();
                ScorocodeSdkStateHolder stateHolder = new ScorocodeSdkStateHolder(
                                /* applicationId */ "228730d6c20044fc85f8a5c8b015e0e7",
                                /* clientKey */ "b93d0e6f7f0e4c18955f580c082345cc",
                                /* masterKey */ "01db6a43743e4492a7bdef1a3be3a395",
                                /* fileKey */ "deb3d951109d43069baba7b8e5424442",
                                /* messageKey */ "80704b44194f4e1282986e5d68942848",
                                /* scriptKey */ "c27ad4e97a784072b029dd02f68c347c",
                                /* websocketKey */ "7b1966691002464e92066b2693135236");

                RequestInsert requestInsert;
                ResponseInsert responsInsert;

                DocumentInfo docInfo = new DocumentInfo();
                docInfo.Put("bossComment", "Good Job!");
                docInfo.Put("name", "Kill Bill!");

                requestInsert = new RequestInsert(stateHolder, "tasks", docInfo);
                responsInsert = await sc.InsertAsync(requestInsert);

                Assert.IsFalse(responsInsert.Error);
                Assert.AreEqual(responsInsert.ErrCode, "");
                Assert.AreEqual(responsInsert.ErrMsg, "");
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod5()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestMethod6()
        {
            Assert.IsTrue(true);
        }

    }
}