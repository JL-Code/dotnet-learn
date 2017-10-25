using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.工厂方法
{
    public class ZJGPizza : Pizza
    {
        public ZJGPizza()
            : base("芝加哥披萨", "厚饼", "小番茄酱", new List<string>() { "意大利白干酪" })
        {

        }
    }
}
