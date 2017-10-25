using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.工厂方法
{
    public class NYPizza : Pizza
    {
        public NYPizza()
            : base("纽约披萨", "薄饼", "大番茄酱", new List<string>() { "意大利高级干酪" })
        {

        }
    }
}
