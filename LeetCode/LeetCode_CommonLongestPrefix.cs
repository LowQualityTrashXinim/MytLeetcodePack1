using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodePlayGround.LeetCode
{
    internal class LeetCode_CommonLongestPrefix
    {
        public static void TestCase()
        {
            string[] strs = ["flower", "flow", "flight"];
            //Xinim ver faster yay
            Console.WriteLine($"Common prefix are (Xinim ver) : {LongestCommonPrefix(strs)}");


            Console.WriteLine($"Common prefix are (Common fastest) : {LongestCommonPrefixV2(strs)}");
        }
        public static string LongestCommonPrefix(string[] strs)
        {
            Stopwatch sw = Stopwatch.StartNew();
            if (strs.Length < 2)
            {
                return strs[0];
            }
            string prefix = string.Empty;
            int UniIndex = 0;
            for (int i = 0; i < strs.Length; i++)
            {
                string str = strs[i];
                if (UniIndex >= str.Length)
                {
                    if (prefix.Length > str.Length)
                    {
                        prefix = prefix.Substring(0, prefix.Length - 1);
                    }
                    break;
                }
                if (i == 0)
                {
                    prefix += str[UniIndex];
                    continue;
                }
                if (str[UniIndex] != prefix[UniIndex])
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                    break;
                }
                if (i + 1 >= strs.Length)
                {
                    UniIndex++;
                    i = -1;
                }
            }
            if (prefix.Length >= 1)
            {
                sw.Stop();
                Console.WriteLine("Total time : " + sw.ToString());
                return prefix;
            }
            else
            {
                sw.Stop();
                Console.WriteLine("Total time : " + sw.ToString());
                return string.Empty;
            }
        }
        public static string LongestCommonPrefixV2(string[] strs)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Array.Sort(strs);
            string first = strs[0];
            string last = strs[strs.Length - 1];

            int minLength = Math.Min(first.Length, last.Length);

            int i = 0;

            while (i < minLength && first[i] == last[i])
            {
                i++;
            }
            string output = first.Substring(0, i);
            sw.Stop();
            Console.WriteLine("Total time : " + sw.ToString());
            return output;

        }
    }
}
