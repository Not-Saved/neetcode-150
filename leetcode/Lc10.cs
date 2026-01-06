namespace leetcode;

public static class Lc10
{
    public static void Run()
    {
        const string s = "ab";
        const string p = "a****b";
        Console.WriteLine(IsMatch(s, p));
    }

    private static bool?[,] cache;

    private static bool IsMatch(string s, string p)
    {
        cache = new bool?[s.Length, p.Length];
        return Match(s, p, 0, 0);
    }

    private static bool Match(string s, string p, int i, int j)
    {
        if (cache[i, j] != null)
        {
            return cache[i, j].Value;
        }

        //base case 
        if (i >= s.Length && j >= p.Length) return true;
        if (j >= p.Length) return false;

        //check if single character match
        var match = i < s.Length && (s[i] == p[j] || p[j] == '.');

        //peek to see if * and then try both roads, not using the pattern or using it if it matches
        if (j + 1 < p.Length && p[j + 1] == '*')
        {
            cache[i, j] = Match(s, p, i, j + 2) || (match && Match(s, p, i + 1, j));
            return cache[i, j].Value;
        }

        //after handling * we can simply act on the match and skip to next char for both string and pattern
        if (match)
        {
            cache[i, j] = Match(s, p, i + 1, j + 1);
            return cache[i, j].Value;
        }

        return false;
    }
}