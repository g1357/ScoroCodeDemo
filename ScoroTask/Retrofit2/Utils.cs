using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrofit2
{
    public static class Utils
    {
        public static T checkNotNull<T>(T _object, String message)
        {
            if (_object == null)
            {
                throw new ArgumentNullException(message);
            }
            return _object;
        }
    }
}