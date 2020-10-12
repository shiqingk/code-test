using System;

namespace TwoSum
{
    /// <summary>
    /// https://leetcode-cn.com/problems/two-sum/
    /// 给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。
    ///你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。
    ///示例:
    ///给定 nums = [2, 7, 11, 15], target = 9
    ///因为 nums[0] + nums[1] = 2 + 7 = 9
    ///所以返回[0, 1]
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] res = TwoSum(new int[] { 2, 7, 11, 15 }, 18);
            Console.WriteLine(res[0] + "," + res[1]);

            res = TwoSum(new int[] { 3, 3 }, 6);
            Console.WriteLine(res[0] + "," + res[1]);
        }

        static int[] TwoSum(int[] nums, int target)
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
                        break;
                    }
                }
            }
            return n;
        }
    }
}
