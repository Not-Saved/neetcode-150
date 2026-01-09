namespace leetcode;

public static class Lc40
{
    public static void Run()
    {
        const int target = 8;
        int[] candidates = [10,1,2,7,6,1,5];
        //[10,7,6,5,2,1,1]
      
        foreach (var innerList in CombinationSum(candidates, target))
        {
            Console.WriteLine(string.Join(", ", innerList));
        }
    }

    private static IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        var res = new List<IList<int>>();
        var comb = new List<int>();
        Array.Sort(candidates);
        CombinationSumRec(res, candidates, target, 0, comb, null);

        return res;
    }

    private static void CombinationSumRec(IList<IList<int>> res, int[] candidates, int total, int idx, IList<int> comb, int? lastTried)
    {
        if (total == 0 )
        {
            res.Add(new List<int>(comb));
            return;
        }

        if (total < 0 || idx >= candidates.Length)
        {
            return;
        }
        
        if (candidates[idx] != lastTried)
        {
            comb.Add(candidates[idx]);
            CombinationSumRec(res, candidates, total - candidates[idx], idx + 1, comb, lastTried);
            comb.RemoveAt(comb.Count - 1);
        }
        CombinationSumRec(res, candidates, total, idx + 1, comb, candidates[idx]);
    }
}