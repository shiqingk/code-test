using CommonLeetCode.Success;
using LeetCode.Programs;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace LeetCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            Test();

            stopwatch.Stop();
            Console.WriteLine("结束" + stopwatch.Elapsed.TotalMilliseconds.ToString("0.###") + " 毫秒");
            Console.ReadKey();
        }

        /// <summary>
        /// 测试分支
        /// </summary>
        public static void Test()
        {
            //Console.WriteLine(string.Join(",", JianDanXuanZe(new int[] { 1, 4, 2, 3, 7, 3 })));
            //Console.WriteLine(string.Join(",", MaoPao(new int[] { 1, 4, 2, 3, 7, 3 })));
            //Console.WriteLine(string.Join(",", MaoPaoBetter(new int[] { 1, 4, 2, 3, 7, 3 })));
            //Console.WriteLine(string.Join(",", DirectInsert(new int[] { 1, 4, 2, 3, 7, 3 })));
            //Console.WriteLine(string.Join(",", HarfSearch(new int[] { 1, 2, 2, 4, 7, 9 }, 2)));
            Console.WriteLine(string.Join(",", NextGreatestLetter(new char[] { 'e', 'h', 'k', 'n', 's', 'x' }, 'e')));
            Console.WriteLine(string.Join(",", NextGreatestLetter(new char[] { 'e', 'h', 'k', 'n', 's', 'x' }, 'x')));
            Console.WriteLine(string.Join(",", NextGreatestLetter(new char[] { 'e', 'h', 'k', 'n', 's', 'x' }, 'k')));
            Console.WriteLine(string.Join(",", NextGreatestLetter(new char[] { 'e', 'h', 'k', 'n', 's', 'x' }, 'l')));
            Console.WriteLine(string.Join(",", NextGreatestLetter(new char[] { 'e', 'h', 'k', 'n', 's', 'x' }, 'w')));
            Console.WriteLine(string.Join(",", NextGreatestLetter(new char[] { 'e', 'e', 'e', 'e', 'e', 'n', 'n', 'n', 'n' }, 'e')));
            Console.WriteLine(string.Join(",", NextGreatestLetter(new char[] { 'c', 'f', 'g' }, 'c')));
            //Grapecity.DataViewer();
        }

        #region 744. 寻找比目标字母大的最小字母
        /// <summary>
        /// https://leetcode-cn.com/problems/find-smallest-letter-greater-than-target/
        /// </summary>
        /// <param name="letters"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static char NextGreatestLetter(char[] letters, char target)
        {
            int left = 0;
            int right = letters.Length - 1;
            int mid = (left + right) / 2;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (letters[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            if (left > letters.Length - 1)
            {
                return letters[0];
            }

            return letters[left];
        }
        #endregion

        #region 各种排序算法
        /// <summary>
        /// 二分查找,小于的都返回出去
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] HarfSearchLeetCode(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int mid = (left + right) / 2;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (nums[mid] == target)
                {
                    break;
                }
                if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    right = mid + 1;
                }
            }

            int[] ret = new int[mid];
            for (int i = 0; i < mid; i++)
            {
                ret[i] = nums[i];
            }

            return ret;
        }
        /// <summary>
        /// 二分查找,递增有序
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int HarfSearch(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                if (nums[mid] > target)
                {
                    right = mid - 1;
                    //left = mid + 1;递减数组就这样写
                }
                else
                {
                    left = mid + 1;
                    //right = mid - 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// 直接插入排序
        /// 遍历[1,len]为i，把[0,i-1]和i的比，i比j大，就结束循环
        /// a[i]就是要插入到j位置的数，先把[j+1,i-1]都移动到[j+2,i]，再把a[i]的移到[j+1]
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] DirectInsert(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i - 1;
                for (; j > 0; j--)
                {
                    if (arr[i] > arr[j])
                    {
                        break;
                    }
                }
                int tmp = arr[i];
                for (int k = i - 1; k > j; k--)
                {
                    arr[k + 1] = arr[k];
                }
                arr[j + 1] = tmp;
            }

            return arr;
        }

        /// <summary>
        /// 冒泡排序优化
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] MaoPaoBetter(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int change = 0;
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int t = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = t;
                        change = 1;
                    }
                }
                if (change == 0)
                {
                    return arr;
                }
            }

            return arr;
        }

        /// <summary>
        /// 冒泡排序
        /// 每个数相邻比较，小的往前放
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] MaoPao(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int t = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = t;
                    }
                }
            }

            return arr;
        }
        /// <summary>
        /// 简单选择
        /// 一遍遍的把i与后边所数比较，最小的跟i互换位置
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] JianDanXuanZe(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int t = arr[i];
                        arr[i] = arr[j];
                        arr[j] = t;
                    }
                }
            }

            return arr;
        }
        #endregion

        /// <summary>
        /// 正式分支
        /// </summary>
        public static void ProgramOneTest()
        {
            Console.WriteLine(ProgramOne.CuttingRope(2));

            Console.WriteLine(string.Join("", ProgramOne.PlusOne(new int[] { 8, 9, 9, 9 })));

            int[] res = ProgramOne.TwoSum(new int[] { 2, 7, 11, 15 }, 18);
            Console.WriteLine(res[0] + "," + res[1]);

            res = ProgramOne.TwoSum(new int[] { 3, 3 }, 6);
            Console.WriteLine(res[0] + "," + res[1]);
        }
    }
}
