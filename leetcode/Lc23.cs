namespace leetcode;

public class Lc23
{
    private class ListNode(int val = 0, ListNode? next = null)
    {
        public int val = val;
        public ListNode? next = next;
    }

    public static void Run()
    {
        var lists = new[]
        {
            null,
            new ListNode(-1, new ListNode(5, new ListNode(11))),
            null,
            new ListNode(6, new ListNode(10))
        };

        PrintList(MergeKList(lists));
    }

    private static ListNode MergeKList(ListNode[] lists)
    {
        if (lists.Length == 0) return null;
        return MergeKListRecursive(lists, 0,  lists.Length - 1);
    }

    private static ListNode MergeKListRecursive(ListNode[] lists, int left, int right)
    {
        if (left == right)
        {
            return lists[left];
        }

        var mid = (right + left) / 2;
        var list1 = MergeKListRecursive(lists, left, mid);
        var list2 = MergeKListRecursive(lists, mid + 1, right);
        return MergeLists(list1, list2);
    }

    private static ListNode MergeLists(ListNode list1, ListNode list2)
    {
        var head = new ListNode();
        var dummy = head;
        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
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

        dummy.next = list1 ?? list2;
        return head.next;
    }

    private static ListNode MergeKListsMinHeap(ListNode[] lists)
    {
        var minHeap = new PriorityQueue<int, int>();
        foreach (var list in lists)
        {
            var dummy = list;
            while (dummy != null)
            {
                minHeap.Enqueue(dummy.val, dummy.val);
                dummy = dummy.next;
            }
        }

        var head = new ListNode();
        var dummy2 = head;
        while (minHeap.Count > 0)
        {
            int smallest = minHeap.Dequeue();
            dummy2.next = new ListNode(smallest);
            dummy2 = dummy2.next;
        }

        return head.next;
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