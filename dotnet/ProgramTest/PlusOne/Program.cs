using System;
using System.Linq;

namespace PlusOne
{
    /// <summary>
    /// https://leetcode-cn.com/problems/plus-one/
    /// 给定一个由整数组成的非空数组所表示的非负整数，在该数的基础上加一。
    //最高位数字存放在数组的首位， 数组中每个元素只存储单个数字。
    //你可以假设除了整数 0 之外，这个整数不会以零开头。
    //示例 1:
    //输入: [1,2,3]
    //输出: [1,2,4]
    //解释: 输入数组表示数字 123。
    //示例 2:
    //输入: [4,3,2,1]
    //输出: [4,3,2,2]
    //解释: 输入数组表示数字 4321。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", PlusOne(new int[] { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 })));

            Console.WriteLine(string.Join(",", PlusOne2(new int[] { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 })));
        }
        static int[] PlusOne(int[] array)
        {
            if (array[array.Length - 1] != 9)
            {
                array[array.Length - 1]++;
            }
            else
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] != 9)
                    {
                        array[i]++;
                        break;
                    }
                    else
                    {
                        array[i] = 0;
                    }
                }
            }
            if (array[0] == 0)
            {
                int[] arr = new int[array.Length + 1];
                (new int[] { 1 }).CopyTo(arr, 0);
                array.CopyTo(arr, 1);
                return arr;
            }
            else
            {
                return array;
            }
        }

        static int[] PlusOne2(int[] array)
        {
            //情况一，末尾不为9
            if (array[array.Length - 1] != 9)
            {
                array[array.Length - 1]++;
                return array;
            }
            //情况二，末尾为9，不是全为9
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] != 9)
                {
                    array[i]++;
                    return array;
                }
                array[i] = 0;
            }
            //情况三，这种情况下，第二种方案也会执行一遍才到这里
            int[] arr = new int[array.Length + 1];
            arr[0] = 1;
            return arr;
        }
    }
}
