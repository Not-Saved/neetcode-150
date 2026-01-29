namespace leetcode;

public static class Lc0003LongestSubstringWithoutRepeatingCharacters
{
    public static int LongestSubstringWithoutRepeatingCharacters(string s)
    {
        if (s.Length == 0) return 0;
        var map = new Dictionary<char, int>();
        var max = 1;
        var left = 0;
        var right = 1;
        map.Add(s[left], left);

        while (right < s.Length)
        {
            if (!map.TryAdd(s[right], right))
            {
                left = Math.Max(left, map[s[right]] + 1);
                map[s[right]] = right;
            }

            var newMax = right - left + 1;
            if (newMax > max) max = newMax;
            right++;
        }

        return max;
    }
}