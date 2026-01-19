using System.Text;

namespace leetcode;

public static class Lc51
{
    public static void Run()
    {
        foreach (var list in SolveNQueens(1))
        {
            Console.WriteLine(string.Join(",", list));
        }
    }

    private static HashSet<int> cols = [];
    private static HashSet<int> posDiag = [];
    private static HashSet<int> negDiag = [];

    private static List<IList<string>> SolveNQueens(int n)
    {
        var result = new List<IList<string>>();
        var board = new List<StringBuilder>();
        for (var i = 0; i < n; i++)
        {
            board.Add(new());
            board[i].Append('.', n);
        }

        SolveNQueensBacktrack(n, 0, result, board);
        return result;
    }

    private static void SolveNQueensBacktrack(int n, int row, List<IList<string>> result, List<StringBuilder> board)
    {
        if (row == n)
        {
            result.Add(board.Select(x => x.ToString()).ToList());
            return;
        }

        for (var col = 0; col < n; col++)
        {
            var pDiag = col - row;
            var nDiag = col + row;
            if (cols.Contains(col) || posDiag.Contains(pDiag) || negDiag.Contains(nDiag))
            {
                continue;
            }

            cols.Add(col);
            posDiag.Add(pDiag);
            negDiag.Add(nDiag);
            board[row][col] = 'Q';
            SolveNQueensBacktrack(n, row + 1, result, board);
            board[row][col] = '.';
            cols.Remove(col);
            posDiag.Remove(pDiag);
            negDiag.Remove(nDiag);
        }
    }
}