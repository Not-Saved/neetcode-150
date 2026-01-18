namespace leetcode;

public static class Lc46
{
    public static void Run()
    {
        int[] s = [1, 2, 3];
        Console.WriteLine(PermuteHeaps(s));
    }

    private static List<IList<int>> PermuteHeaps(int[] nums)
    {
        var result = new List<IList<int>>();
        HeapsAlgorithm(nums.Length, nums, result);
        return result;
    }

    private static void HeapsAlgorithm(int n, int[] nums, IList<IList<int>> result)
    {
        if (n == 1)
        {
            result.Add(new List<int>(nums));
            return;
        }

        for (var i = 0; i < n; i++)
        {
            HeapsAlgorithm(n - 1, nums, result);
            if (n % 2 == 0)
            {
                Swap(nums, i, n - 1);
            }
            else
            {
                Swap(nums, 0, n - 1);
            }
        }
    }

    private static void Swap(int[] nums, int i, int j)
    {
        (nums[i], nums[j]) = (nums[j], nums[i]);
    }

    private static List<IList<int>> Permute(int[] nums)
    {
        var result = new List<IList<int>>();
        result.Add([nums[0]]);
        for (var i = 1; i < nums.Length; i++)
        {
            var newRes = new List<IList<int>>();
            foreach (var l in result)
            {
                for (var j = 0; j <= l.Count; j++)
                {
                    var r = new List<int>(l);
                    r.Insert(j, nums[i]);
                    newRes.Add(r);
                }
            }

            result = newRes;
        }

        return result;
    }
}