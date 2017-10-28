using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DesignPattern.单例模式
{
    public class SigintonTest
    {
        public void Test()
        {
            Thread t1 = new Thread(new ThreadStart(Action));
            Thread t2 = new Thread(new ThreadStart(Action));
            t1.Start();
            t2.Start();
        }


        public void Action()
        {
            for (int i = 0; i < 30; i++)
            {
                var instance = Siginton.Instance;
                Console.WriteLine(instance.RandomNumber);
                Console.WriteLine(instance.ThreadName);
            }
        }
    }
}
