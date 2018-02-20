using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.ScorocodeObjects
{
    // Редакция 2.001 от 09.02.2018 ДГБ
    // Basen on Java file
    //  Created by Peter Staranchuk on 10/11/16

    public class ScorocodeCoreInfo
    {
        private String applicationId;
        private String clientKey;
        private String masterKey;
        private String fileKey;
        private String messageKey;
        private String scriptKey;
        private String websocketKey;

        private String sessionId;

        public ScorocodeCoreInfo(String applicationId, String clientKey, String masterKey, 
            String fileKey, String messageKey, String scriptKey, String webSocket)
        {
            this.applicationId = applicationId;
            this.clientKey = clientKey;
            this.masterKey = masterKey;
            this.fileKey = fileKey;
            this.messageKey = messageKey;
            this.scriptKey = scriptKey;
            this.websocketKey = webSocket;
        }

        public String getApplicationId()
        {
            if (applicationId == null)
            {

                throw new Exception("you must initialize Scorocode SDK first. User init(...) method of ScorocodeSdk class.");
            }

           return applicationId;
        }

        public String getClientKey()
        {
            if (clientKey == null)
            {
                throw new Exception("you must initialize Scorocode SDK first. User init(...) method of ScorocodeSdk class.");
            }

            return clientKey;
        }

        public String getMasterKey()
        {
            return masterKey;
        }

        public String getFileKey()
        {
            return fileKey;
        }

        public String getMessageKey()
        {
            return messageKey;
        }

        public String getSessionId()
        {
            return sessionId;
        }

        public String getMasterOrFileKey()
        {
            return masterKey ?? fileKey;
        }

        public String getMasterOrMessageKey()
        {
            return masterKey ?? messageKey;
        }

        public String getMasterOrScriptKey()
        {
            return masterKey ?? scriptKey;
        }

        public String getWebsocketKey()
        {
            return websocketKey;
        }

        public void setSessionId(String sessionId)
        {
            this.sessionId = sessionId;
        }
    }
}

