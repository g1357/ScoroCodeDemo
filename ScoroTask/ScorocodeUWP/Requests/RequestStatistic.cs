using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ScorocodeUWP.ScorocodeObjects;

namespace ScorocodeUWP.Requests
{
    // Редакция 2.001 от 09.02.2018 ДГБ
    // Basen on Java file
    //  Created by Peter Staranchuk on 5/17/16

    public class RequestStatistic
    {
        private String app;
        private String cli;
        private String acc;

        public RequestStatistic(ScorocodeCoreInfo stateHolder)
        {
            this.app = stateHolder.getApplicationId();
            this.cli = stateHolder.getClientKey();
            this.acc = stateHolder.getMasterKey();
        }

    }
}
