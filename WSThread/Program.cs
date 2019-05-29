using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSThread
{

    delegate int DelegateAddNumbers(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            DelegateAddNumbers handler = AddNumbers;
            int res = handler(10, 15);
            int res2 = handler.Invoke(20, 22);
            Console.WriteLine("Result is : {0}, {1}", res, res2);
            Console.Read();
        }

        static int AddNumbers(int x, int y)
        {
            return x + y;
        }
    }
}
