using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodePlayGround.LeetCode
{
    internal class LeetCode_RemoveDuplicates
    {
        public static int RemoveDuplicates(int[] nums)
        {
            int index = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[index])
                {
                    nums[i] = nums[index + 1];
                    index++;
                }
            }
            return index + 1;
        }
        public static int RemoveDuplicatesOriginal(int[] nums)
        {
            HashSet<int> hashsetNumber = nums.ToHashSet();
            int[] newArr = hashsetNumber.ToArray();
            for (int i = 0; i < newArr.Length; i++)
            {
                nums[i] = newArr[i];
            }
            return hashsetNumber.ToArray().Length;
        }
    }
}
