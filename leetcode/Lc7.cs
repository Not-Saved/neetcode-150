namespace leetcode;

public static class Lc7
{
    public static void Run()
    {
        const int x = 1534236469;
        Console.WriteLine(Reverse(x));
    }

    private static int Reverse(int x)
    {
        var result = 0;
        var mult = x < 0 ? -1 : 1;

        x *= mult;
      
        while (x > 0)
        {
            if(result * 10 / 10 != result) return 0;
            result = result * 10 + x % 10;
            x /= 10;
        }

        result *= mult;

        return result;
    }
    
   

}