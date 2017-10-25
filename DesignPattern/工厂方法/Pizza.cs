using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.工厂方法
{
    /// <summary>
    /// 披萨 基类型
    /// </summary>
    public abstract class Pizza
    {
        //名称
        string name;
        //面团类型
        string dough;
        //酱料类型
        string sauce;
        //一套佐料
        List<string> toppings = new List<string>();

        public Pizza(string name, string dough, string sauce, List<string> toppings)
        {
            this.name = name;
            this.dough = dough;
            this.sauce = sauce;
            this.toppings = toppings;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name => name;

        /// <summary>
        /// 烘烤
        /// </summary>
        public void Bake() {
            Console.WriteLine("烤25分钟");
        }

        /// <summary>
        /// 切片
        /// </summary>
        public void Cut() {
            Console.WriteLine("把比萨饼切成对角片");
        }

        /// <summary>
        /// 装箱
        /// </summary>
        public void Box() {
            Console.WriteLine("将比萨饼放在官方比萨店的盒子里");
        }

        /// <summary>
        /// 披萨制作准备
        /// </summary>
        public void Prepare()
        {
            Console.WriteLine("Preparing " + name);
            Console.WriteLine("Tossing " + dough);
            Console.WriteLine("Adding " + sauce);
            Console.WriteLine("Adding ");
            toppings.ForEach(t =>
            {
                Console.WriteLine($" {t} ");
            });
        }
    }
}
