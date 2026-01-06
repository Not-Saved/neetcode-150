namespace leetcode;

public class Lc21
{
    private class ListNode(int val = 0, ListNode? next = null)
    {
        public int val = val;
        public ListNode? next = next;
    }

    public static void Run()
    {
        var l1 = new ListNode(1, new ListNode(2, new ListNode(4)));
        var l2 = new ListNode(1, new ListNode(3, new ListNode(4)));

        Console.WriteLine(MergeTwoLists(l1, l2));
    }

    private static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        var head = new ListNode();
        var dummy = head;
        while (list1 != null || list2 != null)
        {
            if (list2 == null || (list1 != null && list1.val < list2.val))
            {
                dummy.next = list1;
                list1 = list1.next;
            }
            else
            {
                dummy.next = list2;
                list2 = list2.next;
            }

            dummy = dummy.next;
        }

        return head.next != null ? head.next : null;
    }
}