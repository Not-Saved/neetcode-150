using System.Text;

namespace leetcode;

public static class Lc43
{
    public static void Run()
    {
        string a = "123";
        string b = "456";
        Console.WriteLine(Multiply(a, b));
    }


    private static string Multiply(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0") return "0";
        int n1 = num1.Length, n2 = num2.Length;
        int[] res = new int[n1 + n2];
        for (int i = n1 - 1; i >= 0; i--) {
            for (int j = n2 - 1; j >= 0; j--) {
                int mul = (num1[i] - '0') * (num2[j] - '0');
                int sum = mul + res[i + j + 1];
                res[i + j + 1] = sum % 10;
                res[i + j] += sum / 10;
            }
        }
        StringBuilder sb = new StringBuilder();
        foreach (int num in res) {
            if (!(sb.Length == 0 && num == 0)) sb.Append(num);
        }
        return sb.Length == 0 ? "0" : sb.ToString();
    }
}