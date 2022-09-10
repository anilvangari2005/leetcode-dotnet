using System.Text;

// 2384. Largest Palindromic Number
// https://leetcode.com/problems/largest-palindromic-number/
public partial class Solution
{
    /// <summary>
    /// Runtime: 206 ms         31.93%
    /// Memory Usage: 41 MB     88.24%
    /// </summary>
    public string LargestPalindromic(string num)
    {
        var counts = new int[10];
        for (var i = 0; i < num.Length; i++)
        {
            counts[int.Parse(num[i].ToString())]++;
        }

        StringBuilder left = new StringBuilder();
        for (var i = 9; i >= 0; i--)
        {
            while (counts[i] > 1)
            {
                if (left.Length == 0 && i == 0) break;
                left.Append(i.ToString());
                counts[i] = counts[i] - 2;
            }
        }

        string mid = "";
        for (var i = 9; i >= 0; i--)
        {
            if (counts[i] > 0)
            {
                mid = i.ToString();
                break;
            }
        }

        var leftStr = left.ToString();

        left.Append(mid);
        for (var i = leftStr.Length - 1; i >= 0; i--)
        {
            left.Append(leftStr[i]);
        }
        return left.ToString();
    }
}