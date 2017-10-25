using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.装饰者模式
{
    /// <summary>
    /// 奶泡
    /// </summary>
    public class Whilp : CondimentDecorator
    {
        Beverage _beverage;

        public Whilp(Beverage beverage)
        {
            _beverage = beverage;
        }
        public override double Cost()
        {
            return _beverage.Cost() + 2.99;
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() + ",奶泡";
        }
    }
}
