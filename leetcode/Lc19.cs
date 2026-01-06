namespace leetcode;

public class Lc19
{
    private class ListNode(int val = 0, ListNode? next = null)
    {
        public int val = val;
        public ListNode? next = next;
    }

    public static void Run()
    {
        var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        Console.WriteLine(RemoveNthFromEnd(head, 2));
    }

    private static ListNode? RemoveNthFromEnd(ListNode head, int n)
    {
        var fromEnd = NthFromEnd(head, n);
        return fromEnd == n ? head.next : head;
    }

    private static int NthFromEnd(ListNode node, int n)
    {
        var fromEnd = 1;
        if (node.next != null)
        {
            fromEnd += NthFromEnd(node.next, n);
        }

        if (fromEnd == n + 1)
        {
            node.next = node.next.next;
        }

        return fromEnd;
    }
}