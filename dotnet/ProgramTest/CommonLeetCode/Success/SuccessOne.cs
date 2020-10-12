using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonLeetCode.Success
{
    public static class SuccessOne
    {
        #region 葡萄城笔试题
        #region 杨辉三角，两种思想，递归更高效
        private static long GetNum(int n, int m)
        {
            if (n == m || m == 1) return 1;

            long[,] arr = new long[n, m];
            for (int i = 0; i < n; i++)
            {
                arr[i, 0] = 1;
                for (int j = 1; j < m; j++)
                {
                    if (i < j)
                        continue;
                    if (i == j)
                    {
                        arr[i, j] = 1;
                        continue;
                    }

                    arr[i, j] = arr[i - 1, j - 1] + arr[i - 1, j];
                }
            }

            return arr[n - 1, m - 1];
        }

        private static long GetNum2(int n, int m)
        {
            if (n == m || m == 1) return 1;

            return GetNum2(n - 1, m - 1) + GetNum2(n - 1, m);
        }
        #endregion

        #region 判断素数，尽可能高效
        /// <summary>
        /// 题目8：计算一个尽可能大的素数
        /// 编程语言：不限
        /// 题目描述：在有限的时间内，计算出一个尽可能大的素数。
        /// https://www.grapecity.com.cn/career/challenge
        /// 
        /// https://www.cnblogs.com/hznudreamer/p/12405761.html
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static bool IsPrime(int n)
        {
            if (n == 2 || n == 3)
            {
                return true;
            }
            if (n % 6 != 1 && n % 6 != 5)
            {
                return false;
            }
            for (int i = 5; i <= (int)Math.Sqrt(n); i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion
        #endregion

        #region 20. 有效的括号
        /// <summary>
        /// https://leetcode-cn.com/problems/valid-parentheses/
        /// 给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串，判断字符串是否有效。
        /// 有效字符串需满足：
        ///     左括号必须用相同类型的右括号闭合。
        ///     左括号必须以正确的顺序闭合。
        ///     注意空字符串可被认为是有效字符串。
        /// 示例 1:
        ///     输入: "()"
        ///     输出: true
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsValid(string s)
        {
            List<char> chars = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                char cr = s[i];
                char cchar;
                switch (cr)
                {
                    case '(':
                    case '[':
                    case '{':
                        chars.Add(cr);
                        continue;
                    case ')':
                        cchar = '(';
                        break;
                    case ']':
                        cchar = '[';
                        break;
                    case '}':
                        cchar = '{';
                        break;
                    default:
                        continue;
                }

                if (!chars.Any() || chars.LastIndexOf(cchar) != chars.Count - 1)
                {
                    return false;
                }

                chars.RemoveAt(chars.Count - 1);
            }

            return chars.Count == 0;
        }
        #endregion

        #region 343. 整数拆分
        /// <summary>
        /// https://leetcode-cn.com/problems/integer-break/
        /// 给定一个正整数 n，将其拆分为至少两个正整数的和，并使这些整数的乘积最大化。 返回你可以获得的最大乘积。
        /// 示例 1:
        ///     输入: 2
        ///     输出: 1
        ///     解释: 2 = 1 + 1, 1 × 1 = 1。
        /// 示例 2:
        ///     输入: 10
        ///     输出: 36
        ///     解释: 10 = 3 + 3 + 4, 3 × 3 × 4 = 36。
        /// 说明: 你可以假设 n 不小于 2 且不大于 58。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int IntegerBreak(int n)
        {
            if (n < 4)
            {
                return n - 1;
            }
            if (n % 3 == 0)
            {
                return (int)Math.Pow(3, n / 3);
            }
            if (n % 3 == 1)
            {
                return (int)Math.Pow(3, n / 3 - 1) * 4;
            }

            return (int)Math.Pow(3, n / 3) * (n % 3 == 1 ? 4 : n % 3);
        }
        #endregion

        #region 509. 斐波那契数
        /// <summary>
        /// https://leetcode-cn.com/problems/fibonacci-number/
        /// 斐波那契数，通常用 F(n) 表示，形成的序列称为斐波那契数列。该数列由 0 和 1 开始，后面的每一项数字都是前面两项数字的和。也就是：
        //      F(0) = 0,   F(1) = 1
        //      F(N) = F(N - 1) + F(N - 2), 其中 N > 1.
        //  给定 N，计算 F(N)。
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static int Fib(int n)
        {
            if (n <= 2)
            {
                return n < 1 ? 0 : 1;
            }

            return Fib(n - 1) + Fib(n - 2);
        }
        #endregion

        #region 367. 有效的完全平方数
        /// <summary>
        /// https://leetcode-cn.com/problems/valid-perfect-square/
        /// 给定一个正整数 num，编写一个函数，如果 num 是一个完全平方数，则返回 True，否则返回 False。
        /// 说明：不要使用任何内置的库函数，如 sqrt。
        /// 示例 1：
        ///     输入：16
        ///     输出：True
        /// 示例 2：
        ///     输入：14
        ///     输出：False
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsPerfectSquare(int num)
        {
            if (num == 0)
            {
                return false;
            }
            int i = 1;
            while (num > 0)
            {
                num -= i;
                i += 2;
            }

            return num == 0;
        }
        #endregion
    }
}
