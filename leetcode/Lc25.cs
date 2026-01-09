namespace leetcode;

public class Lc25
{
    private class ListNode(int val = 0, ListNode? next = null)
    {
        public int val = val;
        public ListNode? next = next;
    }

    public static void Run()
    {
        var map = new Dictionary<int, ListNode>();
        map.ContainsKey(4);
        var l1 = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6))))));
        PrintList(ReverseKGroup(l1, 2));
    }

    private static ListNode ReverseKGroup(ListNode head, int k)
    {
        ListNode result = null;
        var count = 1;
        
        var dummy = new ListNode(0, head);
        var left = dummy;
        while (head != null)
        {
            var nextNode = head.next;
            if (count % k == 0)
            {
                head.next = null;
                var newLeft = left.next;
                ReverseList(left.next, nextNode, left);
             
                left = newLeft;
            }
            head = nextNode;
            count++;
        }

        return dummy.next;
    }

    private static void ReverseList(ListNode head, ListNode left, ListNode right)
    {
        ListNode current = null;
        while (head != null)
        {
            current = head;
            head = head.next;
            current.next = left;
            left = current;
        }

        right?.next = current;
    }

    private static void PrintList(ListNode head)
    {
        ListNode current = head;
        while (current != null)
        {
            Console.Write(current.val);
            if (current.next != null)
                Console.Write(" -> ");
            current = current.next;
        }

        Console.WriteLine();
    }
}