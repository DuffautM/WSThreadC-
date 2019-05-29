using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WSThread
{
    class Program
    {
        private delegate void DELG(object state);
        private static int var = 0;
        private static object _Lock = new object ();

        static void Main(string[] args)
        {
            DELG d = (state) =>
            {
                lock (_Lock)
                {
                    string name_thread = (string)state;
                    ++var;
                    Console.WriteLine("Thread -> {0} -- var -> {1}", name_thread, var.ToString());
                    System.Threading.Thread.Sleep(2000);
                }
            };

            Thread t1 = new Thread(d.Invoke);
            Thread t2 = new Thread(d.Invoke);
            t1.Start(((object)("T1")));
            t2.Start(((object)("T2")));
            Console.Read();

        }
    }
}
