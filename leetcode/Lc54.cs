namespace leetcode;

public class Lc54
{
    public static void Run()
    {
        int[][] n = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
        Console.WriteLine(string.Join(", ", SpiralOrder(n)));
    }

    private static IList<int> SpiralOrder(int[][] matrix)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int x = 0;
        int y = 0;
        int dx = 1;
        int dy = 0;
        var res = new List<int>();

        for (var i = 0; i < rows * cols; i++)
        {
            res.Add(matrix[y][x]);
            matrix[y][x] = -101;

            if (!(0 <= x + dx && x + dx < cols && 0 <= y + dy && y + dy < rows) || matrix[y + dy][x + dx] == -101)
            {
                int temp = dx;
                dx = -dy;
                dy = temp;
            }

            x += dx;
            y += dy;
        }

        return res;
    }
}