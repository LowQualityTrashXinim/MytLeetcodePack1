using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodePlayGround.LeetCode
{
    internal class LeetCode_MergeTwoLists
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            List<int> listsort = new();
            if (list1 != null)
            {
                AddBasicValueToList(list1, ref listsort);
            }
            if (list2 != null)
            {
                AddBasicValueToList(list2, ref listsort);
            }
            listsort.Sort();

            if (listsort.Count < 1)
            {
                return null;
            }

            return AddValueToList(new(), ref listsort, 0);
        }
        private void AddBasicValueToList(ListNode listnode, ref List<int> list)
        {
            if (listnode != null)
            {
                list.Add(listnode.val);
                AddBasicValueToList(listnode.next, ref list);
            }
        }
        public ListNode AddValueToList(ListNode listnode, ref List<int> list, int count)
        {
            if (count < list.Count)
            {
                listnode.val = list[count];
                if (count + 1 != list.Count)
                {
                    listnode.next = AddValueToList(new(), ref list, ++count);
                }
            }
            return listnode;
        }
    }
    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}

