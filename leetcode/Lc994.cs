namespace leetcode;

public class Lc994
{
    public static void Run()
    {
        var grid = new int[][]
        {
            [2, 1, 1],
            [1, 1, 0],
            [0, 1, 1]
        };
        Console.WriteLine(OrangesRotting(grid));
    }

    private static int OrangesRotting(int[][] grid)
    {
        var queue = new Queue<(int, int)>();
        var fresh = 0;
        var time = 0;
        int ROWS = grid.GetLength(0), COLS = grid[0].Length;
        for (var r = 0; r < ROWS; r++)
        {
            for (var c = 0; c < COLS; c++)
            {
                if (grid[r][c] == 1)
                {
                    fresh++;
                }

                if (grid[r][c] == 2)
                {
                    queue.Enqueue((r, c));
                }
            }
        }

        (int, int)[] directions = [(-1, 0), (1, 0), (0, -1), (0, 1)];
        while (queue.Count > 0 && fresh > 0)
        {
            var qCount = queue.Count;
            for (var _ = 0; _ < qCount; _++)
            {
                var (r, c) = queue.Dequeue();
                foreach (var (i, j) in directions)
                {
                    var rA = r + i;
                    var cA = c + j;
                    if (rA < 0 || rA >= ROWS || cA < 0 || cA >= COLS || grid[rA][cA] != 1)
                    {
                        continue;
                    }

                    grid[rA][cA] = 2;
                    fresh--;
                    queue.Enqueue((rA, cA));
                }
            }

            time++;
        }

        return fresh == 0 ? time : -1;
    }
}