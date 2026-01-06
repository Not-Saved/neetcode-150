namespace leetcode;

public static class Lc5
{
    public static void Run()
    {
        const string s = "abbd";
        Console.WriteLine(LongestPalindrome(s));
    }

    private static string LongestPalindromeDp(string s)
    {
        var maxLen = 0;
        var start = 0;
        var n = s.Length;
        bool[,] dp = new bool[n, n];
        for (var len = 1; len <= n; len++)
        {
            for (var l = 0; l + len - 1 < n; l++)
            {
                var r = l + len - 1;
                if (s[l] == s[r] && (len <= 2 || dp[l + 1, r - 1]))
                {
                    dp[l, r] = true;
                    if (len > maxLen)
                    {
                        start = l;
                        maxLen = len;
                    }
                }

                ;
            }
        }

        PrintUpperTriangle(dp, s);
        return s.Substring(start, maxLen);
    }

    private static string LongestPalindrome(string s)
    {
        if (s.Length <= 2) return s;
        var maxLen = 0;
        var start = 0;
        for (var i = 0; i < s.Length; i++)
        {
            int l = i, r = i;
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                var length = r - l + 1;
                if (length > maxLen)
                {
                    maxLen = length;
                    start = l;
                }

                l--;
                r++;
            }

            l = i;
            r = i+1;
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                var length = r - l + 1;
                if (length > maxLen)
                {
                    maxLen = length;
                    start = l;
                }

                l--;
                r++;
            }
        }

        return s.Substring(start, maxLen);
    }

    static void PrintUpperTriangle(bool[,] dp, string s)
    {
        int n = s.Length;

        Console.Write("    ");
        for (int j = 0; j < n; j++)
            Console.Write(j + " ");
        Console.WriteLine();

        for (int i = 0; i < n; i++)
        {
            Console.Write(i + " | ");
            for (int j = 0; j < n; j++)
            {
                if (j < i)
                    Console.Write("  ");
                else
                    Console.Write(dp[i, j] ? "T " : "F ");
            }

            Console.WriteLine("  " + s[i]);
        }
    }
}