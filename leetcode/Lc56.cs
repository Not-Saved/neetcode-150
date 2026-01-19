namespace leetcode;

public class Lc56
{
    public static void Run()
    {
        int[][] n = [[1, 3], [2, 6], [8, 10], [15, 18]];
        Console.WriteLine("[" +
                          string.Join(",", Merge(n).Select(a => $"[{string.Join(",", a)}]")) +
                          "]");
    }

    private static int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (x, y) => x[0] - y[0]);
        var merged = new List<int[]> { intervals[0] };
        var j = 0;
        for (var i = 1; i < intervals.Length; i++)
        {
            var prev = merged[j];
            var current = intervals[i];
            if (current[0] <= prev[1])
            {
                merged[j][1] = Math.Max(current[1], prev[1]);
            }
            else
            {
                merged.Add(intervals[i]);
                j++;
            }
        }

        return merged.ToArray();
    }
}