using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP
{
    /// <summary>
    /// Класс для работы с пользователями приложения
    /// </summary>
    public class User
    {
        /// <summary>
        /// Создание экземпляря класса пользователь
        /// </summary>
        public User()
        {

        }

        public void Register(string userName,string eMail, string password, DocumentInfo documentContent, CallbackRegisterUser callback)
        {

        }
        public void Register(string userName, string eMail, string password, CallbackRegisterUser callback)
        {

        }

        public void Login(string eMail, string password, CallbackLoginUser callback)
        {

        }
        public void Logout(CallbackLogoutUser callbavk)
        {

        }
    }
}
