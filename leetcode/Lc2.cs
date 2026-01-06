namespace leetcode;

public static class Lc2
{
    public class ListNode
    {
        public readonly int Val;
        public ListNode? Next;

        public ListNode(int val = 0, ListNode? next = null)
        {
            Val = val;
            Next = next;
        }

        public void Print()
        {
            var l = this;
            var s = "";
            while (l != null)
            {
                s = l.Val + s;
                l = l.Next;
            }

            Console.WriteLine(s);
        }
    }

    public static void Run()
    {
        var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
        var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
        var result = AddTwoNumbers(l1, l2);
        result.Print();
    }


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