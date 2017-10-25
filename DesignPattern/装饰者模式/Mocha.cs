using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.装饰者模式
{
    /// <summary>
    /// 摩卡
    /// </summary>
    public class Mocha : CondimentDecorator
    {
        Beverage _beverage;

        public Mocha(Beverage beverage)
        {
            _beverage = beverage;
        }
        public override double Cost()
        {
            return _beverage.Cost() + 4.99;
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() + ",摩卡";
        }
    }
}
