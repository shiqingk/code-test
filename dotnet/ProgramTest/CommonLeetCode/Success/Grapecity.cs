using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLeetCode.Success
{
    public class Grapecity
    {
        #region 数据可视化
        /// <summary>
        /// 图表外框转角符号：
        ///     “┌”（\u250c）
        ///     “┐”（\u2510）
        ///     “└”（\u2514）
        ///     “┘”（\u2518）
        ///图表中的横、竖线：
        ///     “─”（\u2500）
        ///     “│”（\u2502）
        ///图表中的各种交叉线：
        ///     “├”（\u251c）
        ///     “┤”（\u2524）
        ///     “┬”（\u252c）
        ///     “┴”（\u2534）
        ///     “┼”（\u253c）
        ///用来拼柱子的字符：
        ///     “█”（\u2588）
        ///图表中的空格：
        ///     “ ”（\u0020）
        /// </summary>
        public static void DataViewer()
        {
            int n = /*3;// */int.Parse(Console.ReadLine());
            string order = /*"Value DESC";//*/Console.ReadLine();
            string orderKey = order.Split(" ")[0];
            string orderType = order.Split(" ")[1];
            List<Obj> objs = new List<Obj>();
            int t = 0;
            while (t < n)
            {
                string words = /*"apple 6";// */Console.ReadLine();
                objs.Add(new Obj()
                {
                    Name = words.Split(" ")[0],
                    Value = int.Parse(words.Split(" ")[1])
                });
                //objs.Add(new Obj()
                //{
                //    Name = "pineapple",
                //    Value = 10
                //});
                //objs.Add(new Obj()
                //{
                //    Name = "pen",
                //    Value = 3
                //});
                t++;
            }

            if (orderType == "DESC")
            {
                if (orderKey == "Value")
                {
                    objs = objs.OrderByDescending(x => x.Value).ToList();
                }
                else
                {
                    objs = objs.OrderByDescending(x => x.Name).ToList();
                }
            }
            else if (orderKey == "Value")
            {
                objs = objs.OrderBy(x => x.Value).ToList();
            }
            else
            {
                objs = objs.OrderBy(x => x.Name).ToList();
            }

            int MaxWordLength = objs.OrderByDescending(x => x.Name.Length).First().Name.Length;
            int MaxValueLen = objs.OrderByDescending(x => x.Value).First().Value;

            StringBuilder nameLine = new StringBuilder();
            StringBuilder valueLine = new StringBuilder();
            for (int i = 0; i < MaxWordLength; i++)
            {
                nameLine.Append("\u2500");
            }
            for (int i = 0; i < 20; i++)
            {
                valueLine.Append("\u2500");
            }

            //顶部,┌-┬-┐
            Console.Write("\u250c");//┌
            Console.Write(nameLine);//-
            Console.Write("\u252c");//┬
            Console.Write(valueLine);//-
            Console.WriteLine("\u2510");//┐
            for (int i = 0; i < objs.Count; i++)
            {
                if (i > 0 && objs.Count > 1)
                {
                    //相邻两行之间
                    // ├-┼-┤
                    Console.Write("\u251c");//├
                    Console.Write(nameLine);//-
                    Console.Write("\u253c");//│
                    Console.Write(valueLine);//-
                    Console.Write("\u2502");//│
                    Console.WriteLine();
                }

                //每行的正文,| word|█ |
                Console.Write("\u2502");//竖线
                InitName(objs[i].Name, MaxWordLength);
                Console.Write("\u2502");//竖线
                InitValue(objs[i].Value, MaxValueLen);
                Console.Write("\u2502");//竖线
                Console.WriteLine();
            }

            //底部
            // └-┴┘
            Console.Write("\u2514");//└
            Console.Write(nameLine);//-
            Console.Write("\u2534");//┴
            Console.Write(valueLine);//-
            Console.WriteLine("\u2518");//┘
        }

        private static void InitName(string name, int max)
        {
            for (int i = 0; i < max; i++)
            {
                if (max - name.Length > i)
                {
                    Console.Write("\u0020");//文字前的空格
                }
                else
                {
                    Console.Write(name.Trim());
                    break;
                }
            }
        }
        private static void InitValue(int value, int max)
        {
            for (int i = 0; i < 20; i++)
            {
                if (i < value * 20 / max)
                {
                    Console.Write("\u2588");//黑框
                }
                else
                {
                    Console.Write("\u0020");//空格
                }
            }
        }

        public class Obj
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
        #endregion

        #region 判断一个字符串是否是一个十进制数字 。
        private static bool IsNumber(string str)
        {
            string number = "123456789";
            string all = "0123456789";
            for (int i = 0; i < str.Length; i++)
            {
                char item = str[i];
                if (number.IndexOf(item) > -1)
                {
                    continue;
                }

                switch (item)
                {
                    case '.':
                        if (i == 0 || i == str.Length - 1 || str.LastIndexOf('.') != i || (str.LastIndexOf('+') > -1 && str.LastIndexOf('+') < i))
                        {
                            return false;
                        }
                        continue;
                    case '+':
                        if (i != 5 || i == str.Length - 1 || all.IndexOf(str[i + 1]) == -1)
                        {
                            return false;
                        }
                        continue;
                    case '-':
                        if (i != 0 || i == str.Length - 1 || all.IndexOf(str[i + 1]) == -1)
                        {
                            return false;
                        }
                        continue;
                    case '0':
                        if (i == 0 && str.Length == 1)
                        {
                            return true;
                        }
                        if ((str.Length > 1 && str[0] == '0' && str[1] != '.')
                            || (i == 0 && (str.Length > 1 && str[i + 1] != '.'))
                            || str.IndexOfAny(number.ToArray()) == -1)
                        {
                            return false;
                        }
                        continue;
                    case 'E':
                        if (i != 4 || str[1] != '.' || i == str.Length - 1 || str[i + 1] != '+')
                        {
                            return false;
                        }
                        continue;
                    default:
                        return false;
                }
            }

            return true;
        }
        #endregion
    }
}
