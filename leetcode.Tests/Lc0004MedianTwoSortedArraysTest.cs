using Xunit.Abstractions;

namespace leetcode.Tests;

public class Lc0004MedianTwoSortedArraysTest(ITestOutputHelper output)
{
    [Fact]
    public void Test1()
    {
        int[] nums1 = [1, 2];
        int[] nums2 = [3, 4];

        var result = Lc0004MedianTwoSortedArrays.MedianTwoSortedArrays(nums1, nums2);

        output.WriteLine($"{result}");

        Assert.Equal(2.5, result);
    }
}