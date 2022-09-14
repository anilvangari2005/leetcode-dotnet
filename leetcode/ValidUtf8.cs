/// <summary>
/// https://leetcode.com/problems/utf-8-validation/submissions/
/// 393. UTF-8 Validation
/// </summary>
public partial class Solution
{
    /// <summary>
    /// Runtime: 153 ms, faster than 72.83% of C# online submissions for UTF-8 Validation.
    /// Memory Usage: 41.6 MB, less than 71.20% of C# online submissions for UTF-8 Validation.
    /// </summary>
    public bool ValidUtf8_2(int[] data)
    {
        int i = 0;
        while (i < data.Length)
        {
            if (data[i] >= 0 && data[i] <= 127)
            {
                i++;
            }
            else if (data[i] >= 192 && data[i] <= 223)
            {
                i++;
                if (i < data.Length && data[i] >= 128 && data[i] <= 191)
                    i++;
                else
                    return false;
            }
            else if (data[i] >= 224 && data[i] <= 239)
            {
                i++;
                for (int j = 0; j < 2; j++)
                {
                    if (i < data.Length && data[i] >= 128 && data[i] <= 191)
                        i++;
                    else
                        return false;
                }
            }
            else if (data[i] >= 240 && data[i] <= 247)
            {
                i++;
                for (int j = 0; j < 3; j++)
                {
                    if (i < data.Length && data[i] >= 128 && data[i] <= 191)
                        i++;
                    else
                        return false;
                }
            }
            else
            {
                return false;
            }
        }
        return true;

    }

    /// <summary>
    /// Runtime: 101 ms, faster than 98.91% of C# online submissions for UTF-8 Validation.
    /// Memory Usage: 43.6 MB, less than 8.70% of C# online submissions for UTF-8 Validation.
    /// </summary>
    public bool ValidUtf8_3(int[] data)
    {
        int i = 0;
        while (i < data.Length)
        {
            if (data[i] >= 0x00 && data[i] <= 0x7F)
            {
                i++;
            }
            else if (data[i] >= 0xC0 && data[i] <= 0xDF)
            {
                i++;
                if (i < data.Length && data[i] >= 0x80 && data[i] <= 0xBF)
                    i++;
                else
                    return false;
            }
            else if (data[i] >= 0xE0 && data[i] <= 0xEF)
            {
                i++;
                for (int j = 0; j < 2; j++)
                {
                    if (i < data.Length && data[i] >= 0x80 && data[i] <= 0xBF)
                        i++;
                    else
                        return false;
                }
            }
            else if (data[i] >= 0xF0 && data[i] <= 0xF7)
            {
                i++;
                for (int j = 0; j < 3; j++)
                {
                    if (i < data.Length && data[i] >= 0x80 && data[i] <= 0xBF)
                        i++;
                    else
                        return false;
                }
            }
            else
            {
                return false;
            }
        }
        return true;

    }

    /// <summary>
    /// Runtime: 1 ms, faster than 100.00% of Java online submissions for UTF-8 Validation.
    /// Memory Usage: 48.2 MB, less than 28.05% of Java online submissions for UTF-8 Validation.
    /// 
    /// Java code produced 1ms solution for the same algorithm
    /// 
    /// In C#
    /// Runtime: 214 ms
    /// Memory Usage: 41.8 MB
    /// </summary>
    public bool ValidUtf8(int[] data)
    {
        int i = 0;
        while (i < data.Length)
        {
            if ((data[i] & 0x80) == 0x00)
            {
                i++;
            }
            else if ((data[i] & 0xE0) == 0xC0)
            {
                i++;
                if (i < data.Length && (data[i] & 0xC0) == 0x80)
                    i++;
                else
                    return false;
            }
            else if ((data[i] & 0xF0) == 0xE0)
            {
                i++;
                for (int j = 0; j < 2; j++)
                {
                    if (i < data.Length && (data[i] & 0xC0) == 0x80)
                        i++;
                    else
                        return false;
                }
            }
            else if ((data[i] & 0xF8) == 0xF0)
            {
                i++;
                for (int j = 0; j < 3; j++)
                {
                    if (i < data.Length && (data[i] & 0xC0) == 0x80)
                        i++;
                    else
                        return false;
                }
            }
            else
            {
                return false;
            }
        }
        return true;

    }
}