using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.工厂方法
{
    /// <summary>
    /// 披萨店（创建者）
    /// </summary>
    public abstract class PizzaStore
    {
        /// <summary>
        /// 订披萨
        /// </summary>
        public Pizza OrderPizza(string type)
        {
            var pizza = CreatePizza(type);

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }

        protected abstract Pizza CreatePizza(string type);

    }
}
