using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSThread
{

    class Program
    {
        static void Main(string[] args)
        {
            var myVar = new MyClass();
            myVar.foo = 4;
            myVar.bar = "test";

            var anonymousVar = new { i = 0, s = "test" };
        }
    }

    //Creating a class is only useful when it is needed more than once, 
    //in the case of only used once, an anonymous type is useful when it is readonly
    public class MyClass
    {
        public int foo;
        public string bar;
    }
}
