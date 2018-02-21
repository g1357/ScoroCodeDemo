using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorocodeUWP
{
    public static class Class1
    {
        public static Class2 class2 = new Class2()
        {
            Field2 = "Field2"
        };
    }

    public class Class2
    {
        public string Name;
        public string Field2;
        public string Method1()
        {
            if (string.IsNullOrEmpty(Name))
            {
                Name = "Grigory";
            }
            return Name;
        }
    }

    public class Class3
    {
        public Class2 getClass2()
        {
            return Class1.class2;
        }
    }
}
