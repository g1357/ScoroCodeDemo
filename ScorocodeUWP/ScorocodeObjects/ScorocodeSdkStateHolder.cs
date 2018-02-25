using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    // Редакция 1.001 от 09.02.2018 ДГБ
    // Basen on Java file
    //  Created by Peter Staranchuk on 10/11/16

    public class ScorocodeSdkStateHolder
    {
        private static string PROD_BASE_URL = @"https://api.scorocode.ru";
        public string BaseUrl
        {
            get { return PROD_BASE_URL; }
            set { PROD_BASE_URL = value; }
        }

        private string applicationId;
        public string ApplicationId
        {
            get
            {
                if (applicationId == null)
                {
                    throw new Exception("you must initialize Scorocode SDK first. User init(...) method of ScorocodeSdk class.");
                }
                return applicationId;
            }
            set { applicationId = value; }
        }
        private string clientKey;
        public string ClientKey
        {
            get
            {
                if (clientKey == null)
                {
                    throw new Exception("you must initialize Scorocode SDK first. User init(...) method of ScorocodeSdk class.");
                }
                return clientKey;
            }
            set { clientKey = value; }
        }

        private string masterKey;
        public string MasterKey
        {
            get { return masterKey; }
            set { masterKey = value; }
        }

        private string fileKey;
        public string FileKey
        {
            get { return fileKey; }
            set { fileKey = value; }
        }

        private string messageKey;
        public string MessageKey
        {
            get { return messageKey; }
            set { messageKey = value; }
        }

        private string scriptKey;
        public string ScriptKey
        {
            get { return scriptKey; }
            set { scriptKey = value; }
        }

        private string webSocket;
        public string WebSocket
        {
            get { return webSocket; }
            set { webSocket = value; }
        }

        private string sessionId;
        public string SessionId
        {
            get { return sessionId; }
            set { sessionId = value; }
        }

        public ScorocodeSdkStateHolder(String applicationId, String clientKey, String masterKey, 
            String fileKey, String messageKey, String scriptKey, String webSocket)
        {
            this.applicationId = applicationId;
            this.clientKey = clientKey;
            this.masterKey = masterKey;
            this.fileKey = fileKey;
            this.messageKey = messageKey;
            this.scriptKey = scriptKey;
            this.webSocket = webSocket;
        }

        public string  MasterOrFileKey => masterKey != null ? masterKey : fileKey;

        public String MasterOrMessageKey => masterKey != null ? masterKey : messageKey;

        public String MasterOrScriptKey => masterKey != null ? masterKey : scriptKey;
    }
}