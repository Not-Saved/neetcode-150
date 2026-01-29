using System.Text;

namespace leetcode.utils;

public static class ToString
{
    public static string ArrayToString<T>(T[] array)
    {
        return $"[{string.Join(", ", array)}]";
    }

    public static string ListNodeToString(ListNode? node)
    {
        var sb = new StringBuilder();

        while (node != null)
        {
            sb.Append(node.Val);
            if (node.Next != null)
                sb.Append(" -> ");

            node = node.Next;
        }

        return sb.ToString();
    }
}