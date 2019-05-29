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
            CLpara myClass = new CLpara();
            DELG delg = myClass.Methode_para;
            var param = new Thread(new ThreadStart(myClass.Methode_para));
            Thread t = new Thread(delg.Invoke);
            t.Start();
        }
    }

    class CLpara
    {
        public void Methode_para()
        {
            for(int i = 0; i<10; i++)
            {
                Console.WriteLine("Message : {0}", i);
                Thread.Sleep(1000);
            }
        }
    }
}
