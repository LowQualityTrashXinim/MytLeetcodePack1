using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodePlayGround.LeetCode
{
    internal class LeetCode_ValidParentheses
    {
        public static void TestCase()
        {
            string s = "[([]])";
            Console.WriteLine($"The following brackets sequence valid status is : {IsValid(s)}");
        }
        public static bool IsValid(string s)
        {
            short branchless1 = 0;
            short branchless2 = 0;
            short branchless3 = 0;
            char PreviousOpenType = ' ';
            char CurrentOpenType = ' ';
            char CurrentCloseType = ' ';
            for (int i = 0; i < s.Length; i++)
            {
                if (branchless1 < 0 || branchless2 < 0 || branchless3 < 0)
                {
                    return false;
                }
                if (s[i] == '(')
                {
                    if (CurrentOpenType != ' ')
                    {//({[])}
                        PreviousOpenType = CurrentOpenType;
                    }
                    CurrentOpenType = s[i];
                    branchless1++;
                    continue;
                }
                else if (s[i] == '[')
                {
                    if (CurrentOpenType != ' ')
                    {//({[])}
                        PreviousOpenType = CurrentOpenType;
                    }
                    CurrentOpenType = s[i];
                    branchless2++;
                    continue;
                }
                else if (s[i] == '{')
                {
                    if (CurrentOpenType != ' ')
                    {//({[])}
                        PreviousOpenType = CurrentOpenType;
                    }
                    CurrentOpenType = s[i];
                    branchless3++;
                    continue;
                }
                else if (s[i] == ')')
                {
                    CurrentCloseType = s[i];
                    branchless1--;
                }
                else if (s[i] == ']')
                {
                    CurrentCloseType = s[i];
                    branchless2--;
                }
                else if (s[i] == '}')
                {
                    CurrentCloseType = s[i];
                    branchless3--;
                }
                if (CurrentOpenType == ' ')//(([]))
                {
                    if (PreviousOpenType != ' ')
                    {
                        CurrentOpenType = PreviousOpenType;
                        PreviousOpenType = ' ';
                    }
                    else
                    {
                        continue;
                    }
                }
                if (CurrentCloseType == ' ')
                {
                    continue;
                }
                if (MatchType(CurrentOpenType, CurrentCloseType))
                {
                    CurrentOpenType = ' ';
                    CurrentCloseType = ' ';
                    continue;
                }
                return false;
            }
            return branchless1 == 0 && branchless2 == 0 && branchless3 == 0;
        }
        public static bool MatchType(char open, char close)
        {
            if (open == '(')
            {
                return close == ')';
            }
            if (open == '{')
            {
                return close == '}';
            }
            if (open == '[')
            {
                return close == ']';
            }
            return false;
        }
    }
}
