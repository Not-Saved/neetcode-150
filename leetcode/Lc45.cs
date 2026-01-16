namespace leetcode;

public static class Lc45
{
    public static void Run()
    {
        int[] nums = [1, 1, 2, 2, 1, 2, 1, 3, 2, 1, 2, 1];
        Console.WriteLine(JumpGreedy(nums));
    }

    private static int JumpDp(int[] nums)
    {
        var n = nums.Length;
        var jumps = new int[n];
        jumps[n - 1] = 0;
        for (var i = n - 2; i >= 0; i--)
        {
            jumps[i] = n + 1;
            for (var j = nums[i]; j >= 1; j--)
            {
                if (i + j >= n - 1 || jumps[i] == 1)
                {
                    jumps[i] = 1;
                    break;
                }

                if (jumps[i + j] + 1 < jumps[i]) jumps[i] = jumps[i + j] + 1;
            }
        }

        return jumps[0];
    }

    private static int JumpGreedy(int[] nums)
    {
        var farthest = 0;
        var jumps = 0;
        var maxJump = 0;
        for (var i = 0; i < nums.Length - 1; i++)
        {
            farthest = Math.Max(i + nums[i], farthest);
            if (i == maxJump)
            {
                maxJump = farthest;
                jumps++;
            }
        }

        return jumps;
    }
}