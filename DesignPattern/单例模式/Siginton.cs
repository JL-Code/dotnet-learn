using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DesignPattern.单例模式
{
    public class Siginton
    {
        static Siginton unqiueInstance;
        public double RandomNumber { get; set; }
        public string ThreadName { get; set; }
        private Siginton()
        {
            RandomNumber = new Random().Next(100);
            ThreadName = $"{Thread.CurrentThread.ManagedThreadId} ： {Thread.CurrentThread.Name}";
        }


        public static Siginton Instance
        {
            get
            {
                if (unqiueInstance == null)
                {
                    unqiueInstance = new Siginton();
                }
                return unqiueInstance;
            }
        }
    }
}
