using leetcode.utils;
using Xunit.Abstractions;

namespace leetcode.Tests;

public class Lc0002AddTwoNumbersTest(ITestOutputHelper output)
{
    [Fact]
    public void Test1()
    {
        var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
        var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));

        var result = Lc0002AddTwoNumbers.AddTwoNumbers(l1, l2);

        output.WriteLine(utils.ToString.ListNodeToString(result));

        var passing = new ListNode(7, new ListNode(0, new ListNode(8)));
        Assert.Equal(utils.ToString.ListNodeToString(passing), utils.ToString.ListNodeToString(result));
    }
}