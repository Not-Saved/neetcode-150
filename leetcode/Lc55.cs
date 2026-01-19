namespace leetcode;

public class Lc55
{
    public static void Run()
    {
        int[] n = [3, 2, 1, 0, 4];
        Console.WriteLine(CanJump(n));
    }

    private static bool CanJump(int[] nums)
    {
        var maxJump = 0;
        var n = 0;
        while (n < nums.Length)
        {
            if (n > maxJump) return false;
            maxJump = Math.Max(maxJump, n + nums[n]);
            n++;
        }

        return true;
    }
}