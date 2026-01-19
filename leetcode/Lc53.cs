namespace leetcode;

public class Lc53
{
    public static void Run()
    {
        int[] nums = [-2, 1, -3, 4, -1, 2, 1, -5, 4];
        Console.WriteLine(string.Join(", ", MaxSubArray(nums)));
    }


    private static int MaxSubArray(int[] nums)
    {
        var max = 0;
        var sum = 0;
        var n = 0;
        while (n < nums.Length)
        {
            if (sum < 0) sum = 0;
            sum += nums[n];
            max = Math.Max(max, sum);
            n++;
        }

        return max;
    }
    
    private int MaxSubArrayQuadratic(int[] nums) {
        var max = nums[0];
        for(var i=0; i<nums.Length; i++){
            var sum = 0;
            for(var j=i; j<nums.Length; j++){
                sum+= nums[j];
                max = Math.Max(max, sum);
            }
        }
        return max;
    }
}