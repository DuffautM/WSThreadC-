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
            
            DELG delg = CLpara.Methode_para;
            var param = new Thread(new ThreadStart(CLpara.Methode_para));
            Thread t = new Thread(delg.Invoke);
            t.Start();
        }
    }

    static class CLpara
    {
        public static void Methode_para()
        {
            for(int i = 0; i<10; i++)
            {
                Console.WriteLine("Message : {0}", i);
                Thread.Sleep(1000);
            }
        }
    }
}
