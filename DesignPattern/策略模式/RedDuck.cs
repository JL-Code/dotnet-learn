using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    public class RedDuck : Duck
    {

        public RedDuck(IFly fly, IQuack quack)
        {
            _fly = fly;
            _quack = quack;
        }

        public override void Display()
        {
            Console.WriteLine("我是红色的鸭子");
        }
    }
}
