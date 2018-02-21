using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP.WebApi
{
    public struct Result
    {
        public bool Error;          // Флаг ошибки
        public string Results;       // Результат выполнения оа=перации 
                                    // (не у всех операция и если флаг - иистина)
        public string ErrCode;      // Код ошибки (если влаг - истина)
        public string ErrMessage;   // Сообщение об ошибке (если флаг - истина)
}
}
