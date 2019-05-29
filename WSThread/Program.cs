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
        private delegate void callback(IAsyncResult async);
        private static System.Threading.ReaderWriterLockSlim rwls;
        private static int val = 0;

        static void Main(string[] args)
        {
            rwls = new System.Threading.ReaderWriterLockSlim();
            DELG Read1 = (state) =>
            {
                string thread = (string)state;
                while (true)
                {
                    rwls.EnterReadLock();
                    try
                    {
                        Console.WriteLine("Thread -> {0} -- Message -> {1}", thread, val.ToString());
                    }
                    finally
                    {
                        rwls.ExitReadLock();
                    }
                    System.Threading.Thread.Sleep(2000);
                }
            };


            DELG Write1 = (state) =>
            {
                string thread = (string)state;
                int[] tb = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
                for (int i = 0; i < 10; i++)
                {
                    rwls.EnterWriteLock();
                    try
                    {
                        val = tb[i];
                        Console.WriteLine("Changement de val par Thread -> {0}", thread);
                    }
                    finally
                    {
                        rwls.ExitWriteLock();
                    }
                    System.Threading.Thread.Sleep(3000);
                }
            };
            DELG Write2 = (state) =>
            {
                string thread = (string)state;
                int[] tb = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
                for (int i = 0; i < 10; i++)
                {
                    rwls.EnterWriteLock();
                    try
                    {
                        val = tb[i];
                        Console.WriteLine("Changement de val par Thread -> {0}", thread);
                    }
                    finally
                    {
                        rwls.ExitWriteLock();
                    }
                    System.Threading.Thread.Sleep(3000);
                }
            };

            System.Threading.Thread t1 = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Read1.Invoke));
            System.Threading.Thread t2 = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Read1.Invoke));
            System.Threading.Thread t3 = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Write1.Invoke));
            System.Threading.Thread t4 = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Write1.Invoke));
            t1.Start((object)("T1"));
            t2.Start((object)("T2"));
            t3.Start((object)("T3"));
            t4.Start((object)("T4"));
            Console.Read();
        }
    }

}
