using System;
using System.Collections;

namespace SingleNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SingleNumber(new int[] { 2, 3, 4, 4, 2 }));
        }

        static int SingleNumber2(int[] nums)
        {
            int res = nums[0];
            foreach (int t in nums)
            {
                res ^= t;
            }
            return res;
        }

        static int SingleNumber(int[] nums)
        {
            Hashtable ht = new Hashtable();
            for (int i = 0; i < nums.Length; i++)
            {
                if (ht.ContainsKey(nums[i]))
                {
                    ht[nums[i]] = 2;
                }
                else
                {
                    ht.Add(nums[i], 1);
                }
            }
            foreach (int t in ht.Keys)
            {
                if (ht[t].ToString().Equals("1"))
                {
                    return t;
                }
            }
            return nums[0];
        }
    }
}
