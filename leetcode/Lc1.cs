namespace leetcode;

public static class Lc1
{
    public static void Run()
    {
        int[] nums = [1, 2, 3, 4];
        Console.WriteLine("[{0}]", string.Join(", ", TwoSum(nums, 6)));
    }

    private static int[] TwoSum(int[] nums, int target)
    {
        var map = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var result = map.TryGetValue(target - nums[i], out var mapEl);
            if (result)
            {
                return [mapEl, i];
            }

            map.TryAdd(nums[i], i);
        }

        return [];
    }
}