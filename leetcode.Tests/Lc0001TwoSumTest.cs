using Xunit.Abstractions;

namespace leetcode.Tests;

public class Lc0001TwoSumTest(ITestOutputHelper output)
{
    [Fact]
    public void Test1()
    {
        int[] nums = [1, 2, 3, 4];
        const int target = 6;

        var result = Lc0001TwoSum.TwoSum(nums, target);

        output.WriteLine(utils.ToString.ArrayToString(result));

        Assert.Equal([1, 3], result);
    }
}