// https://leetcode.com/problems/valid-number/submissions/
// 65. Valid Number

public partial class Solution
{

    // Runtime: 128 ms, faster than 37.84% of C# online submissions for Valid Number.
    // Memory Usage: 38.4 MB, less than 91.22% of C# online submissions for Valid Number.
    public bool IsNumber(string s)
    {
        if (s == null || s.Length == 0)
            return false;

        int i = 0;
        while (i < s.Length && s[i] == ' ') i++;

        int pos = -1;
        for (var j = i; j < s.Length; j++)
        {
            if (s[j] == 'e' || s[j] == 'E')
            {
                pos = j;
                break;
            }
        }

        if (pos == 0)
            return false;
        else if (pos > 0)
        {
            if (pos + 1 >= s.Length)
                return false;

            return CheckMantissa(s.Substring(i, pos - i)) &&
                CheckExponent(s.Substring(pos + 1, s.Length - pos - 1));
        }
        else
        {
            return CheckMantissa(i > 0 ? s.Substring(i) : s);
        }
    }

    private bool CheckMantissa(string s)
    {
        if (s.Length <= 0)
            return false;

        if (s == ".")
            return false;

        bool hasSign = false;
        bool hasDot = false;
        bool hasDigit = false;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '+' || s[i] == '-')
            {
                if (hasSign || hasDot || i > 0)
                    return false;
                hasSign = true;
            }
            else if (s[i] == '.')
            {
                if (hasDot)
                    return false;
                hasDot = true;
            }
            else if (s[i] >= '0' && s[i] <= '9')
            {
                if (!hasDigit)
                    hasDigit = true;
            }
            else
            {
                return false;
            }
        }
        return hasDigit;
    }

    private bool CheckExponent(string s)
    {
        if (s.Length <= 0)
            return false;

        bool hasSign = false;
        bool hasDigit = false;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '+' || s[i] == '-')
            {
                if (hasSign || i > 0)
                    return false;
                hasSign = true;
            }
            else if (s[i] >= '0' && s[i] <= '9')
            {
                if (!hasDigit)
                    hasDigit = true;
            }
            else
            {
                return false;
            }
        }
        return hasDigit;
    }
}