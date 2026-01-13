namespace leetcode;

public static class Lc42
{
    public static void Run()
    {
        int[] nums = [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1];
        Console.WriteLine(TrapTwoPointers(nums));
    }

    private static int TrapTwoPointers(int[] heights)
    {
        var water = 0;
        int l = 0,
            r = heights.Length - 1;

        int maxL = heights[l], maxR = heights[r];
        while (l < r)
        {
            if (maxL > maxR)
            {
                r--;
                maxR = Math.Max(heights[r], maxR);
                water += maxR - heights[r];
            }
            else
            {
                l++;
                maxL = Math.Max(heights[l], maxL);
                water += maxL - heights[l];
            }
        }

        return water;
    }

    private static int TrapMonotonicStack(int[] heights)
    {
        var stack = new Stack<int>();
        var water = 0;
        for (var r = 0; r < heights.Length; r++)
        {
            var h = heights[r];
            while (stack.Count > 0 && heights[stack.Peek()] < h)
            {
                var m = stack.Pop();
                if (stack.Count == 0) break;
                
                var l = stack.Peek();
                water += (Math.Min(heights[l], heights[r]) - heights[m]) * (r - l - 1);
             
            }

            stack.Push(r);
        }

        return water;
    }
}