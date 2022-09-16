namespace Leetcode.NumIslands.DFS;

/// <summary>
/// https://leetcode.com/problems/number-of-islands/solution/
/// 200. Number of Islands
/// </summary>
public partial class Solution
{
    int m, n;
    bool[] visited = new bool[0];

    /// <summary>
    /// Runtime: 238 ms, faster than 17.19% of C# online submissions for Number of Islands.
    /// Memory Usage: 44.1 MB, less than 85.36% of C# online submissions for Number of Islands.
    /// </summary>
    public int NumIslands(char[][] grid)
    {
        m = grid.Length;
        n = grid[0].Length;
        visited = new bool[m * n];
        int islands = 0;

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == '1' && !visited[n * i + j])
                {
                    dfs(i, j, grid);
                    islands++;
                }
            }
        }
        return islands;
    }

    private void dfs(int i, int j, char[][] grid)
    {
        if (i < 0 || i >= m || j < 0 || j >= n)
            return;

        if (grid[i][j] == '0')
            return;

        if (!visited[n * i + j])
            visited[n * i + j] = true;
        else
            return;

        if (j + 1 < n)
            dfs(i, j + 1, grid);

        if (i + 1 < m)
            dfs(i + 1, j, grid);

        if (j - 1 >= 0)
            dfs(i, j - 1, grid);

        if (i - 1 >= 0)
            dfs(i - 1, j, grid);
    }


}