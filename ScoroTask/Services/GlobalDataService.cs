using ScorocodeUWP.ScorocodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoroTask.Services
{
    public class GlobalDataService
    {
        public ScorocodeSdkStateHolder stateHolder = new ScorocodeSdkStateHolder(
                            /* applicationId */ "228730d6c20044fc85f8a5c8b015e0e7",
                            /* clientKey */ "b93d0e6f7f0e4c18955f580c082345cc",
                            /* masterKey */ "01db6a43743e4492a7bdef1a3be3a395",
                            /* fileKey */ "deb3d951109d43069baba7b8e5424442",
                            /* messageKey */ "80704b44194f4e1282986e5d68942848",
                            /* scriptKey */ "c27ad4e97a784072b029dd02f68c347c",
                            /* websocketKey */ "7b1966691002464e92066b2693135236");
    }
}
