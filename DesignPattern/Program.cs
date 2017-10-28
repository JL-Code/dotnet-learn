using DesignPattern.工厂方法;
using DesignPattern.装饰者模式;
using System;
using System.Collections.Generic;

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

            //PizzaStore store = new JLPizzaStore();
            //Pizza pizza = store.OrderPizza("NY");
            //Pizza pizza2 = store.OrderPizza("ZJG");
            #endregion

            var package = new RedPackage();
            //伴娘伴郎红包 188*6 铺床红包188*4 司机红包166*6 小舅子红包188*1 
            //亲戚小孩红包68*10 摄像红包128*1 化妆红包68*1 开门红包10*40 小红包2*100
            var temp = package.Run(new Dictionary<int, int> {
                { 188, 11 },
                { 166, 6 },
                { 128, 1 },
                { 68, 11 },
                { 10, 40 },
                { 2, 100 }
            });
            Console.WriteLine(temp);
        }
    }
}
