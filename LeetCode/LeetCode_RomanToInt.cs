using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodePlayGround.LeetCode
{
    internal class LeetCode_RomanToInt
    {
        public static void TestCase()
        {
            Console.WriteLine("Write size of roman array : (maximum 15)");
            string num = Console.ReadLine();
            if (string.IsNullOrEmpty(num) || num.Length > 15)
            {
                ErrorHandle();
                return;
            }
            if (int.TryParse(num, out int number))
            {
                string arr = "";
                Console.WriteLine("Write number until roman array is filled : ");
                Console.WriteLine("Note : use number from 1 to 6 to write roman");
                string helpful = "";
                for (int i = 0; i <= 6; i++)
                {
                    helpful += $"{i} = {WeigthToChar((byte)i)} || ";
                }
                Console.WriteLine(helpful);
                num = Console.ReadLine();
                if (string.IsNullOrEmpty(num) || num.Length > number)
                {
                    ErrorHandle();
                    return;
                }
                for (int i = 0; i < num.Length; i++)
                {
                    if (byte.TryParse(num[i].ToString(), out byte b))
                    {
                        arr += WeigthToChar(b);
                    }
                }
                int romanNumberAsInt = RomanToInt(arr);
                Console.WriteLine($"Roman number converted are : {romanNumberAsInt}");
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
        public static int RomanToInt(string s)
        {
            int strLength = s.Length;
            if (strLength < 1 || strLength > 15)
            {
                return 0;
            }
            int number = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (i + 1 >= s.Length)
                {
                    number += RomanValue(s[i]);
                    break;
                }
                if (WeightCheck(s[i], s[i + 1]))
                {
                    number += RomanValue(s[i]);
                }
                else
                {
                    number -= RomanValue(s[i]);
                }
            }
            return number;
        }
        /// <summary>
        /// The higher the weight, meaning that the roman in the question is larger
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns>
        /// Return true if char to check have bigger or equal weight than char to compare<br/>
        /// Return false if char to check have less weigth than char to compare
        /// </returns>
        private static bool WeightCheck(char cToCheck, char cToCompare)
        {
            return WeightAssign(cToCheck) >= WeightAssign(cToCompare);
        }
        private static byte WeightAssign(char c)
        {
            switch (c)
            {
                case 'I': return 0;
                case 'V': return 1;
                case 'X': return 2;
                case 'L': return 3;
                case 'C': return 4;
                case 'D': return 5;
                case 'M': return 6;
            }
            return 0;
        }
        private static char WeigthToChar(byte w)
        {
            switch (w)
            {
                case 0: return 'I';
                case 1: return 'V';
                case 2: return 'X';
                case 3: return 'L';
                case 4: return 'C';
                case 5: return 'D';
                case 6: return 'M';
            }
            return ' ';
        }
        private static int RomanValue(char c)
        {
            switch (c)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default: return 0;
            }
        }
    }
}