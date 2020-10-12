using System;

namespace LongestPalindrome
{
    /// <summary>
    /// https://leetcode-cn.com/problems/longest-palindromic-substring/
    /// 给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。
    /// 示例 1：
    /// 输入: "babad"
    /// 输出: "bab"
    /// 注意: "aba" 也是一个有效答案。
    /// 示例 2：
    /// 输入: "cbbd"
    /// 输出: "bb"
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LongestPalindrome2("abcda"));
            Console.WriteLine(LongestPalindrome2("abb"));
            Console.WriteLine(LongestPalindrome2("aa"));
            Console.WriteLine(LongestPalindrome2("aba"));
            Console.WriteLine(LongestPalindrome2("acbb"));
            Console.WriteLine(LongestPalindrome2("abdac"));
            Console.WriteLine(LongestPalindrome2("aacdfcaa"));

            Console.WriteLine(LongestPalindrome2("civilwartestingwhetherthatnaptionoranynartionsoconceivedandsodedicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometodedicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirlivesthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButinalargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebravelmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddordetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverforgetwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedworkwhichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicatedtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevotiontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresolvethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirthoffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth"));

            //Console.WriteLine(LongestPalindrome(""));
            //Console.WriteLine(LongestPalindrome("b"));
            //Console.WriteLine(LongestPalindrome("cb"));
            //Console.WriteLine(LongestPalindrome("bb"));
            //Console.WriteLine(LongestPalindrome("bbb"));
            //Console.WriteLine(LongestPalindrome("cbbd"));
            //Console.WriteLine(LongestPalindrome("abccd"));
            //Console.WriteLine(LongestPalindrome("csascacacacb"));
            //Console.WriteLine(LongestPalindrome("civilwartestingwhetherthatnaptionoranynartionsoconceivedandsodedicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometodedicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirlivesthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButinalargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebravelmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddordetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverforgetwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedworkwhichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicatedtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevotiontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresolvethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirthoffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth"));
        }

        static string LongestPalindrome2(string s)
        {
            if (s.Length < 3)
            {
                if (s.Length == 2 && !(s.Substring(0, 1) == s.Substring(1, 1)))
                {
                    return s.Substring(0, 1);
                }
                else
                {
                    return s;
                }
            }
            char[] str1 = s.ToCharArray();
            char[] str2 = s.ToCharArray();
            Array.Reverse(str2);
            int[][] arr = new int[s.Length][];
            int maxLen = 0;
            int n = 0;
            for (int i = 0; i < s.Length; i++)
            {
                arr[i] = new int[s.Length];
                for (int j = 0; j < s.Length; j++)
                {
                    if (str1[i] == str2[j])
                    {
                        if (i == 0 || j == 0)
                        {
                            arr[i][j] = 1;
                        }
                        else
                        {
                            arr[i][j] = str1[i - 1] == str2[j - 1] ? arr[i - 1][j - 1] + 1 : 1;
                        }
                        if (arr[i][j] > maxLen)
                        {
                            int maxLenn = maxLen;
                            int nn = n;
                            maxLen = arr[i][j];
                            n = i - maxLen + 1;
                            bool flag = (maxLen > 1) && (str1[n] == str1[maxLen + n - 1]);
                            if (!flag)
                            {
                                maxLen = maxLenn;
                                n = nn;
                            }
                        }
                    }
                }
            }
            return maxLen > 0 ? s.Substring(n, maxLen) : s.Substring(0, 1);
        }

        static string LongestPalindrome(string s)
        {
            if (s.Length == 2)
            {
                return s.Substring(0, 1).Equals(s.Substring(1, 1)) ? s : s.Substring(0, 1);
            }
            else if (s.Length == 1)
            {
                return s;
            }
            string maxStr = "";
            int maxLen = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                for (int j = s.Length; j > i + 1; j--)
                {
                    Boolean strEqual = Reverse(s.Substring(i, j - i)).Equals(s.Substring(i, j - i));
                    if (strEqual & (j - i > maxLen))
                    {
                        maxStr = s.Substring(i, j - i);
                        maxLen = j - i;
                        break;
                    }
                }
            }
            return maxLen == 0 & s.Length > 0 ? s.Substring(0, 1) : maxStr;
        }

        static string Reverse(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return string.Join("", arr);
        }
    }
}
