namespace Leetcode.NumIslands.DSU;

/// <summary>
/// https://leetcode.com/problems/number-of-islands/solution/
/// 200. Number of Islands
/// </summary>
public partial class Solution
{
    /// <summary>
    /// Runtime: 233 ms, faster than 19.40% of C# online submissions for Number of Islands.
    /// Memory Usage: 44 MB, less than 85.36% of C# online submissions for Number of Islands.
    /// </summary>
    public int NumIslands(char[][] grid)
    {
        if (grid == null || grid.Length == 0)
        {
            return 0;
        }

        int rowCount = grid.Length;
        int colCount = grid[0].Length;
        UnionFind uf = new UnionFind(grid);
        for (int row = 0; row < rowCount; ++row)
        {
            for (int col = 0; col < colCount; ++col)
            {
                if (grid[row][col] == '1')
                {
                    grid[row][col] = '0';
                    if (row - 1 >= 0 && grid[row - 1][col] == '1')
                    {
                        uf.union(row * colCount + col, (row - 1) * colCount + col);
                    }
                    if (row + 1 < rowCount && grid[row + 1][col] == '1')
                    {
                        uf.union(row * colCount + col, (row + 1) * colCount + col);
                    }
                    if (col - 1 >= 0 && grid[row][col - 1] == '1')
                    {
                        uf.union(row * colCount + col, row * colCount + col - 1);
                    }
                    if (col + 1 < colCount && grid[row][col + 1] == '1')
                    {
                        uf.union(row * colCount + col, row * colCount + col + 1);
                    }
                }
            }
        }

        return uf.Count;
    }


}

public class UnionFind
{
    // # of connected components
    public int Count { get; set; }
    int[] parent;
    int[] rank;

    public UnionFind(char[][] grid)
    {
        Count = 0;
        int m = grid.Length;
        int n = grid[0].Length;
        parent = new int[m * n];
        rank = new int[m * n];

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (grid[i][j] == '1')
                {
                    parent[i * n + j] = i * n + j;
                    ++Count;
                }
                rank[i * n + j] = 0;
            }
        }
    }

    public int find(int i)
    {
        // path compression
        if (parent[i] != i) parent[i] = find(parent[i]);
        return parent[i];
    }

    public void union(int x, int y)
    {
        // union with rank
        int rootx = find(x);
        int rooty = find(y);
        if (rootx != rooty)
        {
            if (rank[rootx] > rank[rooty])
            {
                parent[rooty] = rootx;
            }
            else if (rank[rootx] < rank[rooty])
            {
                parent[rootx] = rooty;
            }
            else
            {
                parent[rooty] = rootx; rank[rootx] += 1;
            }
            --Count;
        }
    }

}