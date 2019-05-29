using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WSThread
{

    delegate void DELG();

    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread t =
                new Thread(
                    new ThreadStart(() =>
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine("Message : {0}", i);
                            Thread.Sleep(1000);
                        }
                    }
                    )
                );
                t.Start();
        }
    }
}
