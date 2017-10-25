using DesignPattern.工厂方法;
using DesignPattern.装饰者模式;
using System;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 策略模式

            //var duck = new RedDuck(new FlyWithRocket(), new QuackBehavior());
            //var blueDuck = new BlueDuck(new FlyNoWay(), new MuteQuack());
            //duck.Display();
            //duck.PerformFly();
            //duck.PerformQuack();

            //blueDuck.Display();
            //blueDuck.PerformFly();
            //blueDuck.PerformQuack();

            #endregion

            #region 装饰者模式
            //Beverage beverage = new Espresso(3);
            //beverage = new Mocha(beverage);
            //beverage = new Mocha(beverage);
            //beverage = new Whilp(beverage);
            //beverage = new Soy(beverage);
            //Console.WriteLine(beverage.GetDescription() + " 价格： " + beverage.Cost() + " 容量：" + beverage.GetSize());
            #endregion

            #region 工厂方法

            PizzaStore store = new JLPizzaStore();
            Pizza pizza = store.OrderPizza("NY");
            Pizza pizza2 = store.OrderPizza("ZJG");
            #endregion

        }
    }
}
