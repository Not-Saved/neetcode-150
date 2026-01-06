namespace leetcode;

public static class Lc11
{
    public static void Run()
    {
        int[] height = [1,8,6,2,5,4,8,3,7];
        Console.WriteLine(MaxArea(height));
    }


    private static int MaxArea(int[] height)
    {
        int l = 0, r = height.Length - 1;
        var maxVolume = 0;
        while (l != r)
        {
            var volume = Math.Min(height[l], height[r]) * (r - l);
            if (volume > maxVolume) maxVolume = volume;
            if (height[l] < height[r]) l++;
            else r--;
        }

        return maxVolume;
    }
}