using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.装饰者模式
{
    /// <summary>
    /// 综合咖啡
    /// </summary>
    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            description = "综合咖啡";
        }
        public override double Cost()
        {
            return 10.99;
        }

        public override string GetDescription()
        {
            return description;
        }
    }
}
