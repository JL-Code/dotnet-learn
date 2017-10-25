using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.装饰者模式
{
    /// <summary>
    /// 蒸馏咖啡
    /// </summary>
    public class Espresso : Beverage
    {
        public Espresso()
        {
            description = "蒸馏咖啡";
        }

        public Espresso(int size)
            : base(size)
        {
            description = "蒸馏咖啡";
        }
        public override double Cost()
        {
            return 6.99;
        }

        public override string GetDescription()
        {
            return description;
        }
    }
}
