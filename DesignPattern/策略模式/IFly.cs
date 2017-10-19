using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    public interface IFly
    {
        void Fly();
    }

    public interface IQuack
    {
        void Quack();
    }

    public class FlyNoWay : IFly
    {
        public void Fly()
        {
            Console.WriteLine("懵逼，我不会飞呀！");
        }
    }

    public class FlyWithWings : IFly
    {
        public void Fly()
        {
            Console.WriteLine("我飞起来了！");
        }
    }

    public class FlyWithRocket : IFly
    {
        public void Fly()
        {
            Console.WriteLine("火箭助推起飞了！");
        }
    }

    public class QuackBehavior : IQuack
    {
        public void Quack()
        {
            Console.WriteLine("嘎嘎嘎嘎嘎！");
        }
    }

    public class Squack : IQuack
    {
        public void Quack()
        {
            Console.WriteLine("吱吱吱吱吱吱！");
        }
    }

    public class MuteQuack : IQuack
    {
        public void Quack()
        {
            Console.WriteLine("我不会叫！");
        }
    }
}
