using System;

namespace ArrangeCoins
{
    class Program
    {
        static void Main(string[] args)
        {


            string a = "aaa";
            String b = new string("bbb");
            a = "aab";
            b = "bbc";
            Console.WriteLine("string a is {0},string b is {1}",a,b);
            //Console.WriteLine(a);
            //Console.WriteLine(b);
            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine(i + "," + ArrangeCoins(i));
            //}
        }
        static int ArrangeCoins(int n)
        {
            int i = 1;
            while (n > 0)
            {
                n = n - i;
                if (n < i + 1)
                {
                    return i;
                }
                i++;
            }
            return 0;
        }
    }
}
