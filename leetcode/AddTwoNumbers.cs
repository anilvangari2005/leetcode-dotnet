
// https://leetcode.com/problems/add-two-numbers/
// 2. Add Two Numbers

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public partial class Solution
{
    /// <summary>
    /// Runtime: 98 ms           94.21%
    /// Memory Usage: 39.5 MB    32.44%
    /// </summary>
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode root = null;
        ListNode prev = null;

        var node1 = l1;
        var node2 = l2;
        var carry = 0;
        while (node1 != null || node2 != null)
        {

            var current = new ListNode();
            int tmp = (carry +
                        (node1 != null ? node1.val : 0) +
                        (node2 != null ? node2.val : 0)
                       );
            current.val = tmp % 10;
            carry = tmp / 10;

            if (prev == null)
                root = current;
            else
                prev.next = current;

            prev = current;
            node1 = node1 != null ? node1.next : null;
            node2 = node2 != null ? node2.next : null;
        }

        if (carry > 0)
            prev.next = new ListNode(carry);

        return root;
    }
}