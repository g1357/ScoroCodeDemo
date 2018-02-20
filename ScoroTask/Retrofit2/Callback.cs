using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrofit2
{
    public class Callback<T>
    {
        public delegate void OnResponse(Call<T> call, Response<T> response);
        public OnResponse onResponse;

        public delegate void OnFailure(Call<T> call, Exception t);
        public OnFailure onFailure;
    }
}
