namespace Leetcode.NumIslands.BFS;

/// <summary>
/// https://leetcode.com/problems/number-of-islands/solution/
/// 200. Number of Islands
/// </summary>
public partial class Solution
{
    int m, n;
    bool[] visited = new bool[0];

    /// <summary>
    /// Runtime: 206 ms, faster than 35.57% of C# online submissions for Number of Islands.
    /// Memory Usage: 44.7 MB, less than 39.74% of C# online submissions for Number of Islands.
    /// </summary>
    public int NumIslands2(char[][] grid)
    {
        m = grid.Length;
        n = grid[0].Length;
        visited = new bool[m * n];
        int islands = 0;

        Queue<int> neighbors = new Queue<int>();

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == '1' && !visited[n * i + j])
                {
                    islands++;
                    neighbors.Enqueue(n * i + j);

                    while (neighbors.Count > 0)
                    {
                        var idx = neighbors.Dequeue();

                        int row = idx / n;
                        int col = idx % n;

                        if (grid[row][col] == '0' || visited[idx])
                            continue;

                        visited[idx] = true;

                        if ((col + 1 < n) && !visited[n * row + (col + 1)] && grid[row][col + 1] == '1')
                            neighbors.Enqueue(n * row + (col + 1));
                        if ((row + 1 < m) && !visited[n * (row + 1) + col] && grid[row + 1][col] == '1')
                            neighbors.Enqueue(n * (row + 1) + col);
                        if ((col - 1 >= 0) && !visited[n * row + (col - 1)] && grid[row][col - 1] == '1')
                            neighbors.Enqueue(n * row + (col - 1));
                        if ((row - 1 >= 0) && !visited[n * (row - 1) + col] && grid[row - 1][col] == '1')
                            neighbors.Enqueue(n * (row - 1) + col);
                    }

                }

            }
        }
        return islands;
    }

    /// <summary>
    /// Runtime: 207 ms
    /// Memory Usage: 44.3 MB
    /// </summary>
    public int NumIslands(char[][] grid)
    {
        m = grid.Length;
        n = grid[0].Length;
        visited = new bool[m * n];
        int islands = 0;

        Queue<int> neighbors = new Queue<int>();

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == '1' && !visited[n * i + j])
                {
                    islands++;
                    neighbors.Enqueue(n * i + j);

                    while (neighbors.Count > 0)
                    {
                        var idx = neighbors.Dequeue();

                        int row = idx / n;
                        int col = idx % n;

                        if (row > m || row < 0 || col > n || col < 0)
                            continue;

                        if (grid[row][col] == '0' || visited[idx])
                            continue;

                        visited[idx] = true;

                        if ((col + 1 < n))
                            neighbors.Enqueue(n * row + (col + 1));
                        if ((row + 1 < m))
                            neighbors.Enqueue(n * (row + 1) + col);
                        if ((col - 1 >= 0))
                            neighbors.Enqueue(n * row + (col - 1));
                        if ((row - 1 >= 0))
                            neighbors.Enqueue(n * (row - 1) + col);
                    }

                }

            }
        }
        return islands;
    }



}