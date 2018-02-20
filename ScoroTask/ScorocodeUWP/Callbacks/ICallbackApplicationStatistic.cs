using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ScorocodeUWP.Responses;

namespace ScorocodeUWP.Callbacks
{
    public interface ICallbackApplicationStatistic
    {
        void onRequestSucceed(ResponseAppStatistic appStatistic);
        void onRequestFailed(String errorCode, String errorMessage);
    }
}
