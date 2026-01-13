namespace leetcode;

public static class Lc33
{
    public static void Run()
    {
        int[] s = [4, 5, 6, 7, 0, 1, 2];
        Console.WriteLine(Search(s, 7));
    }

    private static int Search(int[] nums, int target)
    {
        int l = 0, r = nums.Length - 1;
        while (l <= r)
        {
            var mid = (l + r) / 2;
            var midN = nums[mid];
            var lN = nums[l];
            if (midN == target) return mid;
            if (midN >= lN ? (target >= lN && target < midN) : (target >= lN || target < midN))
            {
                r = mid - 1;
            }
            else
            {
                l = mid + 1;
            }
        }

        return -1;
    }
}