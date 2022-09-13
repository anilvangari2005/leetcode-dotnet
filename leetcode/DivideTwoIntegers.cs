
/// <summary>
/// https://leetcode.com/problems/divide-two-integers/
/// 29. Divide Two Integers
/// </summary>
public partial class Solution
{
    /// <summary>
    /// Runtime: 36 ms, faster than 68.53% of C# online submissions for Divide Two Integers.
    /// Memory Usage: 25.1 MB, less than 98.73% of C# online submissions for Divide Two Integers.
    /// </summary>
    public int DivideTwoIntegers(int dividend, int divisor)
    {
        const int OVERFLOW_THRESHOLD = Int32.MinValue >> 1;

        bool negativeSign = (dividend < 0) ^ (divisor < 0);

        if (dividend > 0)
            dividend = -dividend;

        if (divisor > 0)
            divisor = -divisor;

        if (divisor < dividend)
            return 0;

        int result = 0;
        int remainder = dividend;
        int product = -1;
        int tmp = divisor;

        while (true)
        {
            if (tmp < remainder)
            {
                break;
            }

            if (tmp + tmp < remainder || tmp < OVERFLOW_THRESHOLD)
            {
                remainder = remainder - tmp;
                result = result + product;
                tmp = divisor;
                product = -1;
            }
            else
            {
                product = product + product;
                tmp = tmp + tmp;
            }
        }

        if (result == Int32.MinValue && !negativeSign)
            return Int32.MaxValue;

        return negativeSign ? result : -result;
    }
}