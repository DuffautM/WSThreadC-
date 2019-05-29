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
        static Semaphore semaphore;

        static void Main(string[] args)
        {
            semaphore = new Semaphore(2, 2);
            DELG d = (state) =>
            {
                string name_thread = (string)state;
                semaphore.WaitOne();
                for(int i = 0; i<3; i++)
                {
                    ++var;
                    Console.WriteLine("Thread -> {0} -- var -> {1}", name_thread, var.ToString());
                    System.Threading.Thread.Sleep(2000);
                }
                semaphore.Release();

            };

            Thread t1 = new Thread(d.Invoke);
            Thread t2 = new Thread(d.Invoke);
            Thread t3 = new Thread(d.Invoke);
            t1.Start(((object)("T1")));
            t2.Start(((object)("T2")));
            t3.Start(((object)("T3")));
            Console.Read();

        }
    }
}
