// https://leetcode.com/problems/string-to-integer-atoi/submissions/
// 8. String to Integer (atoi)

public partial class Solution
{
    /// Runtime: 121 ms, faster than 19.96% of C# online submissions for String to Integer (atoi).
    /// Memory Usage: 36.8 MB, less than 89.18% of C# online submissions for String to Integer (atoi).
    public int MyAtoi(string s)
    {
        if (s == null || s.Length == 0)
            return 0;

        int i = 0;
        while (i < s.Length && s[i] == ' ') i++;

        bool isPositive = true;
        if (i < s.Length && (s[i] == '+' || s[i] == '-'))
        {
            isPositive = (s[i] == '+');
            i++;
        }

        int result = 0;
        int lowerBoundary = int.MinValue / 10;
        int upperBoundary = int.MaxValue / 10;
        int lowerRemainder = int.MinValue % 10;
        int upperRemainder = int.MaxValue % 10;

        for (; i < s.Length; i++)
        {
            int decimalVal = s[i] - 0x30;

            if (decimalVal >= 0 && decimalVal <= 9)
            {
                if (isPositive)
                {
                    if (result > upperBoundary ||
                       (result == upperBoundary && decimalVal > upperRemainder))
                        return int.MaxValue;
                }
                else
                {
                    if (result < lowerBoundary ||
                       (result == lowerBoundary && decimalVal > -lowerRemainder))
                        return int.MinValue;
                }

                if (isPositive)
                    result = result * 10 + decimalVal;
                else
                    result = result * 10 - decimalVal;
            }
            else
                break;
        }
        return result;

    }

    // Runtime: 116 ms, faster than 25.40% of C# online submissions for String to Integer (atoi).
    // Memory Usage: 37.2 MB, less than 44.04% of C# online submissions for String to Integer (atoi).
    public int MyAtoi2(string s)
    {
        if (s == null || s.Length == 0)
            return 0;

        short i = 0;
        while (i < s.Length && s[i] == ' ') i++;

        bool isPositive = true;
        if (i < s.Length && (s[i] == '+' || s[i] == '-'))
        {
            isPositive = (s[i] == '+');
            i++;
        }

        long result = 0;
        for (; i < s.Length; i++)
        {
            // if (result >= int.MaxValue || result <= int.MinValue)
            //     break;

            short decimalVal = (short)(s[i] - 0x30);

            if (decimalVal >= 0 && decimalVal <= 9)
            {
                if (isPositive)
                    result = result * 10 + decimalVal;
                else
                    result = result * 10 - decimalVal;
            }
            else
                break;
        }

        if (result >= int.MaxValue)
            return int.MaxValue;
        else if (result <= int.MinValue)
            return int.MinValue;
        else
            return (int)result;
    }

    // Runtime: 70 ms, faster than 91.81% of C# online submissions for String to Integer (atoi).
    // Memory Usage: 38.8 MB, less than 13.60% of C# online submissions for String to Integer (atoi).
    public int MyAtoi3(string s)
    {
        if (s == null || s.Length == 0)
            return 0;

        short i = 0;
        while (i < s.Length && s[i] == ' ') i++;

        bool isPositive = true;
        if (i < s.Length && (s[i] == '+' || s[i] == '-'))
        {
            isPositive = (s[i] == '+');
            i++;
        }

        long result = 0;
        for (; i < s.Length; i++)
        {
            if (result >= int.MaxValue || result <= int.MinValue)
                break;

            int decimalVal = s[i] - 0x30;

            if (decimalVal >= 0 && decimalVal <= 9)
            {
                if (isPositive)
                    result = result * 10 + decimalVal;
                else
                    result = result * 10 - decimalVal;
            }
            else
                break;
        }

        if (result >= int.MaxValue)
            return int.MaxValue;
        else if (result <= int.MinValue)
            return int.MinValue;
        else
            return (int)result;
    }

    // Runtime: 67 ms, faster than 94.91% of C# online submissions for String to Integer (atoi).
    // Memory Usage: 39.1 MB, less than 7.22% of C# online submissions for String to Integer (atoi).
    public int MyAtoi4(string s)
    {
        if (s == null || s.Length == 0)
            return 0;

        int i = 0;
        while (i < s.Length && s[i] == ' ') i++;

        bool isPositive = true;
        if (i < s.Length && (s[i] == '+' || s[i] == '-'))
        {
            isPositive = (s[i] == '+');
            i++;
        }

        long result = 0;
        for (; i < s.Length; i++)
        {
            if (result >= int.MaxValue || result <= int.MinValue)
                break;

            int decimalVal = s[i] - 0x30;

            if (decimalVal >= 0 && decimalVal <= 9)
            {
                if (isPositive)
                    result = result * 10 + decimalVal;
                else
                    result = result * 10 - decimalVal;
            }
            else
                break;
        }

        if (result >= int.MaxValue)
            return int.MaxValue;
        else if (result <= int.MinValue)
            return int.MinValue;
        else
            return (int)result;
    }
}
