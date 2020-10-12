using System;
using System.Linq;
using System.Text;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MajorityElement(new int[] {1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}));
            Console.ReadKey();
        }
        //https://leetcode-cn.com/problems/majority-element/
        static int MajorityElement(int[] nums)
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
        //https://leetcode-cn.com/problems/count-primes/
        static int CountPrimes(int n)
        {
            if (n < 3)
            {
                return 0;
            }
            int sum = 0;
            for (int i = 2; i < n; i++)
            {
                Boolean flag = true;
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

        //https://leetcode-cn.com/problems/flipping-an-image/
        static int[][] FlipAndInvertImage(int[][] A)
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
        /// <summary>
        /// https://leetcode-cn.com/problems/length-of-last-word/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static int LengthOfLastWord(string s)
        {
            string[] str = s.Trim().Split(" ");
            return str[str.Length - 1].Length;
        }
        static public int Reverse(int x)
        {
            StringBuilder y = new StringBuilder();
            char[] z = x >= 0 ? x.ToString().ToCharArray() : (-1 * x).ToString().ToCharArray();
            for (int i = z.Length - 1; i > -1; i--)
            {
                y.Append(z[i]);
            }
            try
            {
                return x >= 0 ? int.Parse(y.ToString()) : (-1) * int.Parse(y.ToString());
            }
            catch
            {
                return 0;
            }
        }
    }
}
