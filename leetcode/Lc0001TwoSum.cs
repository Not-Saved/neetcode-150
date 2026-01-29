namespace leetcode;

public static class Lc0001TwoSum
{
    public static int[] TwoSum(int[] nums, int target)
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