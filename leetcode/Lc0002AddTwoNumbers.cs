using leetcode.utils;

namespace leetcode;

public static class Lc0002AddTwoNumbers
{
    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode? result = null;
        ListNode? l = null;

        var borrow = 0;
        while (l1 != null || l2 != null)
        {
            var sum = 0;
            if (l1 != null)
            {
                sum += l1.Val;
                l1 = l1.Next;
            }

            ;
            if (l2 != null)
            {
                sum += l2.Val;
                l2 = l2.Next;
            }

            sum = (sum + borrow);
            borrow = sum / 10;
            sum %= 10;

            if (l == null)
            {
                l = new ListNode(sum);
                result = l;
            }
            else
            {
                l.Next = new ListNode(sum);
                l = l.Next;
            }
        }

        if (borrow == 1)
        {
            l.Next = new ListNode(borrow);
        }

        return result;
    }
}