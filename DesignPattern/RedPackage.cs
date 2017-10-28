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
            metadata.Add("1", 1);
            metadata.Add("5", 5);
            metadata.Add("10", 10);
            metadata.Add("20", 20);
            metadata.Add("50", 50);
            metadata.Add("100", 100);
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
            var dict = new Dictionary<string, int>();
            foreach (var key in combination.Keys)
            {
                if (dict.ContainsKey(key))
                {
                    dict[key] = combination[key] * count;
                }
                else
                {
                    dict.Add(key, combination[key] * count);
                }
            }
            return dict;
        }

        public Dictionary<string, int> Run(Dictionary<int, int> redPackage)
        {
            var sum = new Dictionary<string, int>();
            foreach (var key in redPackage.Keys)
            {
                var temp = Run(key, redPackage[key]);
                foreach (var mkey in metadata.Keys)
                {
                    if (sum.ContainsKey(mkey))
                    {
                        if (temp.ContainsKey(mkey))
                            sum[mkey] += temp[mkey];
                    }
                    else
                    {
                        if (temp.ContainsKey(mkey))
                            sum.Add(mkey, temp[mkey]);
                    }
                }
            }
            return sum;
        }

        public void RunAndOutput(Dictionary<int, int> redPackage)
        {
            var total = 0;
            string output = "红包清单\n\r";
            foreach (var item in redPackage)
            {
                output += $"红包面值：{item.Key}， 红包个数：{item.Value}\n\r";
            }
            var data = Run(redPackage);
            output += "\n\r\n\r";
            output += "零钱清单：";
            foreach (var key in data.Keys)
            {
                output += $"纸币面值：{key}，所需纸币数量：{data[key]}\n\r";
                total += Convert.ToInt32(key) * data[key];
            }
            output += $"总金额：{total}";
            Console.WriteLine(output);
        }
    }
}
