namespace leetcode;

public class Lc567
{
    public static void Run()
    {
        Console.WriteLine(CheckInclusion("ab", "eidbaooo"));
    }


    private static bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length)
        {
            return false;
        }

        var count1 = new Dictionary<char, int>();
        var count2 = new Dictionary<char, int>();

        for (int i = 0; i < s1.Length; i++)
        {
            count1[s1[i]] = count1.GetValueOrDefault(s1[i]) + 1;
            count2[s2[i]] = count2.GetValueOrDefault(s2[i]) + 1;
        }

        if (DictionariesAreEqual(count1, count2))
        {
            return true;
        }

        var l = 0;
        for (var r = s1.Length; r < s2.Length; r++)
        {
            count2[s2[r]] = count2.GetValueOrDefault(s2[r]) + 1;

            count2[s2[l]]--;
            if (count2[s2[l]] == 0) count2.Remove(s2[l]);
            l++;

            if (DictionariesAreEqual(count1, count2))
            {
                return true;
            }
        }

        return false;
    }

    private static bool DictionariesAreEqual(Dictionary<char, int> d1, Dictionary<char, int> d2)
    {
        if (d1.Count != d2.Count)
            return false;

        foreach (var kvp in d1)
        {
            if (!d2.TryGetValue(kvp.Key, out var value) || kvp.Value != value)
                return false;
        }

        return true;
    }
}