using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.装饰者模式
{
    /// <summary>
    /// 豆奶
    /// </summary>
    public class Soy : CondimentDecorator
    {
        Beverage beverage;

        public Soy(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override double Cost()
        {
            return beverage.Cost();
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + ",豆奶";
        }
    }
}
