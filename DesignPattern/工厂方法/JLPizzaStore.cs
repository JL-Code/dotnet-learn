using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.工厂方法
{
    public class JLPizzaStore : PizzaStore
    {
        SimplePizzaFactory factory;
        public JLPizzaStore()
        {
            factory = new SimplePizzaFactory();
        }

        protected override Pizza CreatePizza(string type)
        {
            return factory.CreatePizza(type);
        }
    }
}
