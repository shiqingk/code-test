using System;

namespace AddBinary
{
    /// <summary>
    /// https://leetcode-cn.com/problems/add-binary/
    /// 给定两个二进制字符串，返回他们的和（用二进制表示）。
    //输入为非空字符串且只包含数字 1 和 0。
    //示例 1:
    //输入: a = "11", b = "1"
    //输出: "100"
    //示例 2:
    //输入: a = "1010", b = "1011"
    //输出: "10101"
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AddBinary("1010", "1011"));
            //Console.WriteLine(AddBinary("10100000100100110110010000010101111011011001101110111111111101000000101111001110001111100001101", "110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011"));

        }
        /// <summary>
        /// 只在字符串很短的情况下有效
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static string AddBinary(string a, string b)
        {
            return Convert.ToString(Convert.ToInt32(a, 2) + Convert.ToInt32(b, 2), 2);
        }

        static string AddBinary2(string a, string b)
        {
            string[] m = a.Split("");
            string[] n = b.Split("");
            
            return "";
        }
    }
}
