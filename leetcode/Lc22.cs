namespace leetcode;

public class Lc22
{
    public static void Run()
    {
        const int numberOfParen = 3;
        Console.WriteLine(string.Join(",", GenerateParenthesis(numberOfParen)));
    }

    private static IList<string> GenerateParenthesis(int n)
    {
        var results = new List<string>();
        if (n == 0) return results;
        if (n == 1)
        {
            results.Add("()");
            return results;
        }

        Generate(results, "(", 1, 0, n);
        return results;
    }

    private static void Generate(IList<string> results, string combination, int left, int right,
        int n)
    {
        if (combination.Length == n * 2)
        {
            results.Add(combination);
            return;
        }

        if (left < n)
        {
            Generate(results, combination + "(", left + 1, right, n);
        }

        if (right < left)
        {
            Generate(results, combination + ")", left, right + 1, n);
        }
    }
}