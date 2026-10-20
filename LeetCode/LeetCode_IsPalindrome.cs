using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodePlayGround.LeetCode
{
    public static class LeetCode_IsPalindrome
    {
        public static void TestCase()
        {
            Console.WriteLine("Write any number to test : ");
            string num = Console.ReadLine();
            if (string.IsNullOrEmpty(num))
            {
                ErrorHandle();
                return;
            }
            if (int.TryParse(num, out int number))
            {
                Console.WriteLine($"test result return : {IsPalindrome(number)}");
            }
            else
            {
                ErrorHandle();
            }
        }
        private static void ErrorHandle()
        {
            Console.WriteLine("Error, Repeated the test case");
            TestCase();
        }
        public static bool IsPalindrome(int x)
        {
            if (x < 0 || x == int.MaxValue)
            {
                return false;
            }
            if (x < 10)
            {
                return true;
            }
            if (x < 100)
            {
                if (x % 11 == 0)
                {
                    return true;
                }
            }
            char[] palindrome = x.ToString().ToCharArray();
            for (int i = 0; i < palindrome.Length / 2; i++)
            {
                if (palindrome[i] != palindrome[^(i + 1)])
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsPalindrome_MathOnly(int x)
        {
            if (x < 0 || x == int.MaxValue)
            {
                return false;
            }
            if (x < 10)
            {
                return true;
            }
            if (x < 100)
            {
                if (x % 11 == 0)
                {
                    return true;
                }
            }
            int num = x, a = 0;
            while (num > 0)
            {
                a = a * 10 + num % 10;
                num /= 10;
            }
            return a == x;
        }
    }
}
