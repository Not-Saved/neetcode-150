using System.Text;

namespace leetcode;

public class Lc17
{
    public static void Run()
    {
        const string digits = "292";
        Console.WriteLine(string.Join(", ", LetterCombinations(digits)));
    }


    private static IList<string> LetterCombinations(string digits)
    {
        var result = new List<string>();
        if (digits.Length == 0) return result;

        string[] map =
        {
            "", "", "abc", "def", "ghi",
            "jkl", "mno", "pqrs", "tuv", "wxyz"
        };

        var combinations = 1;
        foreach (var d in digits)
            combinations *= map[d - '0'].Length;

        for (var i = 0; i < combinations; i++)
        {
            var k = combinations;
            var sb = "";

            foreach (var d in digits)
            {
                var letters = map[d - '0'];
                k /= letters.Length;
                sb += letters[(i / k) % letters.Length];
            }

            result.Add(sb);
        }

        return result;
    }
}