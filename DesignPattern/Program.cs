using System;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var duck = new RedDuck(new FlyWithRocket(), new QuackBehavior());
            var blueDuck = new BlueDuck(new FlyNoWay(), new MuteQuack());
            duck.Display();
            duck.PerformFly();
            duck.PerformQuack();

            blueDuck.Display();
            blueDuck.PerformFly();
            blueDuck.PerformQuack();
        }
    }
}
