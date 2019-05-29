using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSThread
{

    delegate int DelegateSquareUp(int x);

    class Program
    {
        static void Main(string[] args)
        {
            DelegateSquareUp squaUp = new DelegateSquareUp(x => x * x);
            int res = squaUp.Invoke(4);
            Console.WriteLine("Result is : {0}", res);
            Console.Read();
        }
        //static Func<int, int> SquareUp = x => x * x;
    }
}
