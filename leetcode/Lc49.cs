namespace leetcode;

public class Lc49
{
    public static void Run()
    {
        string[] digits = ["eat", "tea", "tan", "ate", "nat", "bat"];
        Console.WriteLine(string.Join(", ", GroupAnagrams(digits)));
    }


    private static List<IList<string>> GroupAnagrams(string[] strs)
    {
        var map = new Dictionary<string, IList<string>>();
        foreach (var word in strs)
        {
            var count = new char[26];
            foreach (var c in word) count[c - 'a']++;
            var key = new string(count);
            if (map.ContainsKey(key))
            {
                map[key].Add(word);
            }
            else
            {
                map.Add(key, new List<string> { word });
            }
        }

        var res = new List<IList<string>>(map.Values);
        return res;
    }
}