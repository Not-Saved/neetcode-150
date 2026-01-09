namespace leetcode;

public static class Lc39
{
    public static void Run()
    {
        const int target = 7;
        int[] candidates = [2,3,5,7];
        foreach (var innerList in CombinationSum(candidates, target))
        {
            Console.WriteLine(string.Join(", ", innerList));
        }
    }

    private static IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        var res = new List<IList<int>>();
        var comb = new List<int>();
        CombinationSumRec(res, candidates, target, 0, comb);

        return res;
    }

    private static void CombinationSumRec(IList<IList<int>> res, int[] candidates, int total, int idx, IList<int> comb)
    {
        if (total == 0)
        {
            res.Add(new List<int>(comb));
            return;
        }

        if (total < 0 || idx >= candidates.Length)
        {
            return;
        }

        comb.Add(candidates[idx]);
        CombinationSumRec(res, candidates, total - candidates[idx], idx, comb);
        comb.RemoveAt(comb.Count - 1);
        CombinationSumRec(res, candidates, total, idx + 1, comb);
    }

    private static IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        var ways = new Dictionary<int, IList<IList<int>>>();
        foreach (var candidate in candidates)
        {
            for (var i = candidate; i <= target; i++)
            {
                if (!ways.ContainsKey(i - candidate))
                {
                    ways.Add(i - candidate, []);
                }

                if (!ways.ContainsKey(i))
                {
                    ways.Add(i, []);
                }

                if (i == candidate)
                {
                    ways[i].Add([i]);
                }

                foreach (var way in ways[i - candidate])
                {
                    var newWay = new List<int>(way);
                    newWay.Add(candidate);
                    ways[i].Add(newWay);
                }
            }
        }

        return ways.ContainsKey(target) ? ways[target] : [];
    }
}