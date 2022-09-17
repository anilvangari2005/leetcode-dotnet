namespace Leetcode.MaximumScore.TopDown;

/// <summary>
/// 1770. Maximum Score from Performing Multiplication Operations
/// https://leetcode.com/problems/maximum-score-from-performing-multiplication-operations/
/// </summary>
public partial class Solution
{
    Dictionary<int, int> scoreMap = new Dictionary<int, int>();
    int lengthM, lengthN;

    /// <summary>
    /// Runtime: 1088 ms, faster than 44.44% of C# online submissions for Maximum Score from Performing Multiplication Operations.
    /// Memory Usage: 132.1 MB, less than 28.24% of C# online submissions for Maximum Score from Performing Multiplication Operations.
    /// 
    /// Top down recursive technique with memoization performs poorly when compared to bottom-up non-recursion approach.
    /// </summary>
    public int MaximumScore(int[] nums, int[] multipliers)
    {
        lengthM = multipliers.Length;
        lengthN = nums.Length;

        return helper(0, 0, nums, multipliers);
    }

    private int helper(int i, int x, int[] nums, int[] multipliers)
    {
        if (x == lengthM)
            return 0;

        int key = lengthM * x + i;
        if (scoreMap.ContainsKey(key))
            return scoreMap[key];

        int left = nums[i] * multipliers[x] + helper(i + 1, x + 1, nums, multipliers);
        int right = nums[i + lengthN - x - 1] * multipliers[x] + helper(i, x + 1, nums, multipliers);
        int score = left > right ? left : right;
        scoreMap[key] = score;
        return score;
    }

}