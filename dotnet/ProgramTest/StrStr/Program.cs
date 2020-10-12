using System;

namespace StrStr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StrStr("hello","ll"));
        }
        static int StrStr(string haystack, string needle)
        {

            return haystack.IndexOf(needle);
        }
    }
}
