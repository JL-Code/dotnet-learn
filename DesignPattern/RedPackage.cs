using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern
{
    public class RedPackage
    {
        //红包种类 小红包(2) 伴娘伴郎红包(188) 司机红包(166) 亲戚小孩红包(68) 铺床红包(188) 摄像红包（88）化妆红包（88）

        Dictionary<string, int> metadata = new Dictionary<string, int>();

        public RedPackage()
        {
            metadata.Add("One", 1);
            metadata.Add("Five", 5);
            metadata.Add("Ten", 10);
            metadata.Add("Twenty", 20);
            metadata.Add("Fifty", 50);
            metadata.Add("OneHundred", 100);
        }

        private Dictionary<string, int> Compute(int target)
        {
            var values = metadata.Values.Reverse();
            var temp = 0;
            var temps = new List<int>();
            var dict = new Dictionary<string, int>();
            //最优组合 面值纸币使用数量最少的组合
            //var optimalCombination = new List<int>();

            while (temp < target)
            {
                foreach (var item in values)
                {
                    //Console.WriteLine($"temp before:{temp}");
                    temp += item;
                    //Console.WriteLine($"temp after:{temp}");
                    //Console.WriteLine($"item :{item}");
                    if (temp > target)
                    {
                        temp -= item;
                        continue;
                    }
                    else if (temp == target)
                    {
                        temps.Add(item);
                        break;
                    }
                    else
                    {
                        temps.Add(item);
                    }
                }
            }
            temps.ForEach(s =>
            {
                if (dict.ContainsKey(s.ToString()))
                {
                    dict[s.ToString()] += 1;
                }
                else
                {
                    dict.Add(s.ToString(), 1);
                }

            });
            return dict;
        }

        public Dictionary<string, int> Run(int target, int count)
        {
            var combination = Compute(target);
            foreach (var key in combination.Keys)
            {
                combination[key] = combination[key] * count;
            }
            return combination;
        }

        public Dictionary<string, int> Run(Dictionary<int, int> redPackage)
        {
            var sum = new Dictionary<string, int>();
            var list = new List<Dictionary<string, int>>();
            foreach (var key in redPackage.Keys)
            {
                var temp = Run(key, redPackage[key]);
                list.Add(temp);
            }
            //list.ForEach(temp=>{
            //    foreach (var tempKey in temp.Keys)
            //    {
            //        if (sum.ContainsKey(tempKey))
            //        {
            //            sum[tempKey] += temp[tempKey];
            //        }
            //        else
            //        {
            //            sum.Add(tempKey, temp[tempKey]);
            //        }
            //    }
            //});
            return sum;
        }

        public void RunAndOutput(Dictionary<int, int> redPackage)
        {
            string output = "";
            foreach (var item in redPackage)
            {
                output += $"红包面值：{item.Key}， 红包个数：{item.Value} ";
            }
            var data = Run(redPackage);
            output += "\n\r";
            foreach (var item in data)
            {
                output += $"纸币面值：{item.Key}，数量：{item.Value}\n\r";
            }
            Console.WriteLine(output);
        }
    }
}
