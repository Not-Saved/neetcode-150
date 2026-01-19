namespace leetcode;

public class Lc57
{
    public static void Run()
    {
        int[][] n = [[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]];
        Console.WriteLine("[" +
                          string.Join(",", InsertOnePass(n, [4, 8]).Select(a => $"[{string.Join(",", a)}]")) +
                          "]");
    }

    private static int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var res = new List<int[]>();
        var i = 0;
        while (i < intervals.Length && newInterval[0] > intervals[i][1])
        {
            res.Add(intervals[i]);
            i++;
        }

        while (i < intervals.Length && intervals[i][0] <= newInterval[1])
        {
            newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
            newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
            i++;
        }

        res.Add(newInterval);

        while (i < intervals.Length)
        {
            res.Add(intervals[i]);
            i++;
        }

        return res.ToArray();
    }

    private static int[][] InsertOnePass(int[][] intervals, int[] newInterval)
    {
        var res = new List<int[]>();
        foreach (var interval in intervals)
        {
            if (interval[0] > newInterval[1])
            {
                res.Add(newInterval);
                newInterval = interval;
            }
            else if (newInterval[0] > interval[1])
            {
                res.Add(interval);
            }
            else
            {
                newInterval[0] = Math.Min(newInterval[0], interval[0]);
                newInterval[1] = Math.Max(newInterval[1], interval[1]);
            }
        }

        res.Add(newInterval);
        return res.ToArray();
    }
}