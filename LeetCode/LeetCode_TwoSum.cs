using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodePlayGround.LeetCode
{
    public static class LeetCode_TwoSum
    {
        public static void TestCase()
        {
            Console.WriteLine("Write size of array : ");
            string num = Console.ReadLine();
            if (string.IsNullOrEmpty(num))
            {
                ErrorHandle();
                return;
            }
            if (int.TryParse(num, out int number))
            {
                int[] arr = new int[number];
                Console.WriteLine("Write number until array is filled : ");
                for (int i = 0; i < number; i++)
                {
                    num = Console.ReadLine();
                    if (string.IsNullOrEmpty(num))
                    {
                        ErrorHandle();
                        return;
                    }
                    if (int.TryParse(num, out int a))
                    {
                        arr[i] = a;
                    }
                    else
                    {
                        ErrorHandle();
                        return;
                    }
                }
                Console.WriteLine("Write expected two sum :");
                num = Console.ReadLine();
                if (string.IsNullOrEmpty(num))
                {
                    ErrorHandle();
                    return;
                }
                if (int.TryParse(num, out int n))
                {
                    TwoSum(arr, n);
                }
                else
                {
                    ErrorHandle();
                }
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
        public static int[] TwoSum(int[] nums, int target)
        {
            if (nums.Length < 2 || nums.Length > 10000
                || target == int.MinValue || target == int.MaxValue)
            {
                return Array.Empty<int>();
            }
            if (nums.Length == 2)
            {
                if (nums[0] + nums[1] == target)
                {
                    return [0, 1];
                }
            }
            int indexOutside = 0;
            for (int i = indexOutside + 1; i < nums.Length; i++)
            {
                //Increases because either found a index that should be skipped
                if (nums[indexOutside] + nums[i] != target)
                {
                    if (i == nums.Length - 1 && indexOutside < nums.Length)
                    {
                        indexOutside++;
                        i = indexOutside;
                        if (i >= nums.Length)
                        {
                            break;
                        }
                    }
                    continue;
                }
                return [indexOutside, i];
            }
            return Array.Empty<int>();
        }
    }
}
