namespace Leetcode.MaximumScore.BottomUp;

/// <summary>
/// 1770. Maximum Score from Performing Multiplication Operations
/// https://leetcode.com/problems/maximum-score-from-performing-multiplication-operations/
/// </summary>
public partial class Solution
{

    Dictionary<int, int> scoreMap = new Dictionary<int, int>();
    int lengthM, lengthN;

    /// <summary>
    /// Runtime: 500 ms, faster than 73.61% of C# online submissions for Maximum Score from Performing Multiplication Operations.
    /// Memory Usage: 131 MB, less than 28.24% of C# online submissions for Maximum Score from Performing Multiplication Operations.
    /// </summary>
    public int MaximumScore(int[] nums, int[] multipliers)
    {
        lengthM = multipliers.Length;
        lengthN = nums.Length;

        int left, right, score;

        for (var x = lengthM - 1; x >= 0; x--)
        {
            for (var i = 0; i <= x; i++)
            {
                left = nums[i] * multipliers[x] + getScore(i + 1, x + 1);
                right = nums[i + lengthN - x - 1] * multipliers[x] + getScore(i, x + 1);
                score = left > right ? left : right;
                setScore(i, x, score);
            }
        }

        return getScore(0, 0);
    }

    private int getScore(int i, int x)
    {
        if (x == lengthM) return 0;
        return scoreMap[lengthM * x + i];
    }

    private void setScore(int i, int x, int score)
    {
        scoreMap[lengthM * x + i] = score;
    }
}