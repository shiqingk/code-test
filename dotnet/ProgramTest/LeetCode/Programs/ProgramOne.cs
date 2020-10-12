using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LeetCode.Programs
{
    public class ProgramOne
    {

        #region 单例模式
        private static ProgramOne program;
        private static readonly object obj = new object();
        public static ProgramOne InstanceCreationEditor()
        {
            lock (obj)
            {
                if (program == null)
                {
                    program = new ProgramOne();
                }

                return program;
            }
        }
        #endregion

        #region 剑指 Offer 38. 字符串的排列
        /// <summary>
        /// https://leetcode-cn.com/problems/zi-fu-chuan-de-pai-lie-lcof/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string[] Permutation(string s)
        {
            if (s.Length == 1)
            {
                return new string[] { s };
            }
            HashSet<string> list = new HashSet<string>();
            for (int i = 0; i < s.Length; i++)
            {
                string item = s.Substring(i, 1);
                string[] sub = Permutation(s[0..i] + s[(i + 1)..]);
                foreach (var tmp in sub)
                {
                    string end = item + tmp;
                    if (end.Length == s.Length && !list.Contains(end))
                    {
                        list.Add(end);
                        list.Add(tmp + item);
                    }
                }
            }

            return list.ToArray();
        }
        #endregion

        #region 有序数组中找出传入的数字重复次数
        /// <summary>
        /// https://leetcode-cn.com/problems/zai-pai-xu-shu-zu-zhong-cha-zhao-shu-zi-lcof/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int Search(int[] nums, int target)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < target)
                {
                    continue;
                }
                if (nums[i] > target)
                {
                    break;
                }
                count++;
            }

            return count;
        }
        #endregion

        #region 32. 最长有效括号，目前超长时存在超时问题
        /// <summary>
        /// https://leetcode-cn.com/problems/longest-valid-parentheses/
        /// 给定一个只包含 '(' 和 ')' 的字符串，找出最长的包含有效括号的子串的长度。
        /// 示例 1:
        ///     输入: "(()"
        ///     输出: 2
        ///     解释: 最长有效括号子串为 "()"
        /// 示例 2:
        ///     输入: ")()())"
        ///     输出: 4
        ///     解释: 最长有效括号子串为 "()()"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LongestValidParentheses(string s)
        {
            int max = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                for (int j = i + 1; j <= s.Length; j++)
                {
                    string str = s[i..j];
                    if (str.Length % 2 == 0 && str.Length > max && IsTrueStr(str))
                    {
                        max = str.Length;
                    }
                }
            }

            return max;
        }

        public static bool IsTrueStr(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char cr = s[i];
                switch (cr)
                {
                    case '(':
                        count++;
                        continue;
                    case ')':
                        if (count == 0)
                        {
                            return false;
                        }
                        count--;
                        continue;
                    default:
                        continue;
                }
            }

            return count == 0;
        }
        #endregion

        #region 1470. 重新排列数组
        /// <summary>
        /// 1470. 重新排列数组
        /// 给你一个数组 nums ，数组中有 2n 个元素，按 [x1,x2,...,xn,y1,y2,...,yn] 的格式排列。
        /// 请你将数组按[x1, y1, x2, y2, ..., xn, yn] 格式重新排列，返回重排后的数组。
        /// https://leetcode-cn.com/problems/shuffle-the-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[] Shuffle(int[] nums, int n)
        {
            int[] arr = new int[n * 2];
            for (int i = 0, index = 0; i < n; i++, index += 2)
            {
                arr[index] = nums[i];
                arr[index + 1] = nums[n + i];
            }

            return arr;
        }
        #endregion

        #region 647. 回文子串数量,待调试
        /// <summary>
        /// 给定一个字符串，你的任务是计算这个字符串中有多少个回文子串。
        ///具有不同开始位置或结束位置的子串，即使是由相同的字符组成，也会被计为是不同的子串。
        /// https://leetcode-cn.com/problems/palindromic-substrings/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int CountSubstrings(string s)
        {
            int num = s.Length;
            int sum = s.Length;
            var dp = new int[sum, sum];
            for (int i = sum - 1; i >= 0; i--)
            {
                dp[i, i] = 1;
                for (int j = i + 1; j < sum; j++)
                {
                    var str = s[i..j];
                    if (s[i] == s[j])
                    {
                        if (j - i == 1)
                        {
                            dp[i, j] = 1;
                        }
                        else
                        {
                            dp[i, j] = dp[i + 1, j - 1];
                        }
                    }
                    else
                    {
                        dp[i, j] = 0;
                    }

                    num += dp[i, j];
                }
            }

            return num;
        }
        #endregion

        #region 面试题50. 第一个只出现一次的字符
        /// <summary>
        /// https://leetcode-cn.com/problems/di-yi-ge-zhi-chu-xian-yi-ci-de-zi-fu-lcof/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static char FirstUniqChar(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s.IndexOf(s[i]) == i && s.LastIndexOf(s[i]) == i)
                {
                    return s[i];
                }
            }

            return ' ';
        }
        #endregion

        #region 面试题14- I. 剪绳子
        /// <summary>
        /// https://leetcode-cn.com/problems/jian-sheng-zi-lcof/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int CuttingRope(int n)
        {
            if (n <= 3)
            {
                return n - 1;
            }

            return (n % 3) switch
            {
                0 => Convert.ToInt32(Math.Pow(3, n / 3)),
                1 => Convert.ToInt32(Math.Pow(3, n / 3 - 1) * 4),
                _ => Convert.ToInt32(Math.Pow(3, n / 3) * 2),
            };
        }
        #endregion

        #region 66. 加一
        /// <summary>
        /// https://leetcode-cn.com/problems/plus-one/
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] != 9)
                {
                    digits[i]++;
                    return digits;
                }
                else
                {
                    digits[i] = 0;
                }
            }

            digits = new int[digits.Length + 1];
            digits[0] = 1;

            return digits;
        }
        #endregion

        #region 169. 多数元素
        /// <summary>
        /// 给定一个大小为 n 的数组，找到其中的多数元素。多数元素是指在数组中出现次数大于 ⌊ n/2 ⌋ 的元素。
        /// 你可以假设数组是非空的，并且给定的数组总是存在多数元素。
        /// https://leetcode-cn.com/problems/majority-element/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MajorityElement(int[] nums)
        {
            if (nums.Length < 2)
            {
                return nums.Length == 1 ? 1 : 0;
            }
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int flag = 0;
                for (int j = 0; j < nums.Length - 1 - i; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        int tmp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = tmp;
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    break;
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + " ");
            }
            Console.WriteLine();
            int sum = 1;
            int n = 0;
            int harf = nums.Length % 2 == 0 ? (nums.Length / 2) : (nums.Length / 2) + 1;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                {
                    sum++;
                    n = nums[i];
                    if (sum == harf)
                    {
                        break;
                    }
                }
                else
                {
                    sum = 1;
                    n = 0;
                }
            }
            return n;
        }
        #endregion

        #region 204. 计数质数
        /// <summary>
        /// 统计所有小于非负整数 n 的质数的数量
        /// https://leetcode-cn.com/problems/count-primes/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int CountPrimes(int n)
        {
            if (n < 3)
            {
                return 0;
            }
            int sum = 0;
            for (int i = 2; i < n; i++)
            {
                bool flag = true;
                for (int j = 2; j <= i / 2; j++)
                {
                    if (i % j == 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    sum++;
                }
            }
            return sum;
        }
        #endregion

        #region 832. 翻转图像
        /// <summary>
        /// https://leetcode-cn.com/problems/flipping-an-image/
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int[][] FlipAndInvertImage(int[][] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                Array.Reverse(A[i]);
                for (int j = 0; j < A[0].Length; j++)
                {
                    A[i][j] = A[i][j] == 0 ? 1 : 0;
                }
            }
            return A;
        }
        #endregion

        #region 58. 最后一个单词的长度
        /// <summary>
        /// https://leetcode-cn.com/problems/length-of-last-word/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLastWord(string s)
        {
            string[] str = s.Trim().Split(" ");
            return str[^1].Length;
        }
        #endregion

        #region 1. 两数之和
        /// <summary>
        /// /// <summary>
        /// https://leetcode-cn.com/problems/two-sum/
        /// 给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。
        ///你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。
        ///示例:
        ///给定 nums = [2, 7, 11, 15], target = 9
        ///因为 nums[0] + nums[1] = 2 + 7 = 9
        ///所以返回[0, 1]
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            int[] n = new int[2];
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        n[0] = i;
                        n[1] = j;
                        return n;
                    }
                }
            }
            return n;
        }
        #endregion
    }
}
