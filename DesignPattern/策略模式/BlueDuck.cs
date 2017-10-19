using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    public class BlueDuck : Duck
    {
        public BlueDuck(IFly fly, IQuack quack)
        {
            _fly = fly;
            _quack = quack;
        }

        public override void Display()
        {
            Console.WriteLine("我是个蓝色的鸭子");
        }
    }
}
