namespace leetcode;

public class Lc50
{
    public static void Run()
    {
        Console.WriteLine(MyPow(2.0, 54));
    }

    private static double MyPow(double x, int n)
    {
        return BinaryExp(x, (long)n);
    }

    private static double BinaryExp(double x, long n)
    {
        if (n == 0)
        {
            return 1;
        }

        if (n < 0)
        {
            return 1.0 / BinaryExp(x, -n);
        }

        if (n % 2 == 1)
        {
            return x * BinaryExp(x * x, n / 2);
        }

        return BinaryExp(x * x, n / 2);
    }
}