using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.工厂方法
{
    public class SimplePizzaFactory
    {
        public Pizza CreatePizza(string type)
        {
            Pizza pizza;
            switch (type)
            {
                case "NY":
                    pizza = new NYPizza();
                    break;
                default:
                    pizza = new ZJGPizza();
                    break;
            }
            return pizza;
        }
    }
}
