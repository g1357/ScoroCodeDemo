using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP
{
    /// <summary>
    /// Класс методов обратного вызова при удалении документа
    /// </summary>
    public class CallbackRemoveDocument
    {
        /// <summary>
        /// Выполняется при успешном удалении документа
        /// </summary>
        /// <param name="responseRemove">Результаты удаления</param>
        public delegate void OnRemoveSuccess(ResponseRemove responseRemove);
        /// <summary>
        /// Выполняется при неудачном удалении документа
        /// </summary>
        /// <param name="errorCode">Код ошибки</param>
        /// <param name="errorMessage">Сообщение об ошибке</param>
        public delegate void OnRemoveFailed(string errorCode, string errorMessage);

        public OnRemoveSuccess onRemoveSuccess;
        public OnRemoveFailed onRemoveFailed;
    }
}
