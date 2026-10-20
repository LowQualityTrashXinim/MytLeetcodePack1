using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodePlayGround.LeetCode
{
    internal class LeetCode_IntToRoman
    {
        public static void TestCase()
        {
            Console.WriteLine(IntToRoman(3749));
            Console.WriteLine(IntToRoman(58));
            Console.WriteLine(IntToRoman(1994));
        }
        public static string IntToRoman(int num)
        {
            if (num <= 0 || num >= 4000)
            {
                return "";
            }
            string R = "";

            Dictionary<char, int> roman = new Dictionary<char, int>
            {
                { 'I', 0 },
                { 'V', 0 },
                { 'X', 0 },
                { 'L', 0 },
                { 'C', 0 },
                { 'D', 0 },
                { 'M', 0 },
            };

            int remain = num % 1000;
            int numberToCal = num;
            if (num >= 1000)
            {
                int Thousand = numberToCal / 1000;
                numberToCal -= 1000 * Thousand;
                roman['M'] = Thousand;
            }

            if (numberToCal >= 500 && numberToCal < 900)
            {
                int fiveHund = numberToCal / 500;
                numberToCal -= 500 * fiveHund;
                roman['D'] = fiveHund;
            }

            if (numberToCal >= 100)
            {
                int hundred = numberToCal / 100;
                numberToCal -= 100 * hundred;
                roman['C'] = hundred;
            }

            if (numberToCal >= 50 && numberToCal < 90)
            {
                int fithty = numberToCal / 50;
                numberToCal -= 50 * fithty;
                roman['L'] = fithty;
            }

            if (numberToCal >= 10)
            {
                int ten = numberToCal / 10;
                numberToCal -= 10 * ten;
                roman['X'] = ten;
            }

            if (numberToCal >= 5 && numberToCal < 9)
            {
                int five = numberToCal / 5;
                numberToCal -= 5 * five;
                roman['V'] = five;
            }

            roman['I'] = numberToCal;

            for (int i = roman.Keys.Count - 1; i >= 0; i--)
            {
                char Key = roman.Keys.ElementAt(i);
                int value = roman[Key];
                if (value > 0)
                {
                    if (value >= 9)
                    {
                        int adjustIndex = i + 2;
                        if (adjustIndex >= 0 && adjustIndex < roman.Keys.Count)
                        {
                            char Key2 = roman.Keys.ElementAt(adjustIndex);
                            R += $"{Key}{Key2}";
                        }
                    }
                    else if (value >= 4)
                    {
                        int adjustIndex = i + 1;
                        if (adjustIndex >= 0 && adjustIndex < roman.Keys.Count)
                        {
                            char Key2 = roman.Keys.ElementAt(adjustIndex);
                            R += $"{Key}{Key2}";
                        }
                    }
                    else if (value == 1)
                    {
                        R += $"{Key}";
                    }
                    else
                    {
                        int adjustIndex = i - 1;
                        if (Key == 'M' || value < 4)
                        {
                            for (int a = 0; a < value; a++)
                            {
                                R += $"{Key}";
                            }
                        }
                        else if (adjustIndex >= 0 && adjustIndex < roman.Keys.Count)
                        {
                            char Key2 = roman.Keys.ElementAt(adjustIndex);
                            for (int a = 0; a < value; a++)
                            {
                                R += $"{Key}";
                            }
                            R += $"{Key2}";
                        }
                        else
                        {
                            for (int a = 0; a < value; a++)
                            {
                                R += $"{Key}";
                            }
                        }
                    }
                }
            }
            return R;
        }
    }
}
