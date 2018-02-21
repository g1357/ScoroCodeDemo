using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.Responses
{
    // Редакция 2.001 от 09.02.2018 ДГБ
    // Basen on Java file
    //  Created by Peter Staranchuk on 5/10/16

    //POJO object

    public sealed class ResponseAppStatistic : ResponseCodes
    {
        public Result result;

        public Result getResult()
        {
            return result;
        }

        public void setResult(Result result)
        {
            this.result = result;
        }

        public class Result
        {
            public long dataSize;   // Размер данных приложения, в байтах
            public long filesSize;  // Размер файлов приложения, в байтах
            public long indexSize;  // "Размер" индексов приложения, в байтах
            public double store;    // 
        }
    }
}