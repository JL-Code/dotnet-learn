using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    public abstract class Duck
    {
        protected IFly _fly;
        protected IQuack _quack;

        /// <summary>
        /// 显示鸭子的外形
        /// </summary>
        public abstract void Display();

        /// <summary>
        /// 飞行
        /// </summary>
        public void PerformFly()
        {
            _fly.Fly();
        }

        /// <summary>
        /// 叫
        /// </summary>
        public void PerformQuack()
        {
            _quack.Quack();
        }
    }
}
