namespace leetcode;

public static class Lc518
{
    public static void Run()
    {
        const int amount = 5;
        int[] coins = [1, 2, 5];
        Console.WriteLine(Change(amount, coins));
    }

    private static int Change(int amount, int[] coins)
    {
        var ways = new int[amount + 1];
        ways[0] = 1;
        foreach (var coin in coins)
        {
            for (var i = coin; i <= amount; i++)
            {
                ways[i] += ways[i - coin];
            }
        }

        Console.WriteLine(string.Join(",", ways));
        return ways[amount];
    }
}