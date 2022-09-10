using System.Text;

public partial class Solution
{
    /// <summary>
    /// Runtime: 82 ms, faster than 88.37% of C# online submissions for Fraction to Recurring Decimal.
    /// Memory Usage: 37.1 MB, less than 9.30% of C# online submissions for Fraction to Recurring Decimal.
    /// </summary>
    public string FractionToDecimal1(int numerator, int denominator)
    {
        if (numerator == 0)
            return "0";

        long quotient = (long)numerator / (long)denominator;
        long remainder = (long)numerator % (long)denominator;

        if (remainder == 0)
            return quotient.ToString();

        var dict = new Dictionary<long, int>();
        var list = new List<int>();
        var idx = 0;

        while (true)
        {
            dict.Add(remainder, idx);

            remainder = remainder * 10;
            idx++;

            var result = (int)(remainder / denominator);
            remainder = remainder % denominator;
            list.Add(result);

            if (remainder == 0 || dict.ContainsKey(remainder))
                break;
        }

        var sb = new StringBuilder();
        if (quotient == 0 &&
            (
                (numerator > 0 && denominator < 0) ||
                (numerator < 0 && denominator > 0)
            )
        )
            sb.Append("-");
        sb.Append(quotient);
        sb.Append(".");

        int matchIdx = dict.ContainsKey(remainder) ? dict[remainder] : -1;
        for (var i = 0; i < list.Count; i++)
        {
            if (i == matchIdx)
                sb.Append("(");
            sb.Append(Math.Abs(list[i]));
        }

        if (matchIdx >= 0)
            sb.Append(")");

        return sb.ToString();
    }

    /// <summary>
    /// Runtime: 66 ms, faster than 100.00% of C# online submissions for Fraction to Recurring Decimal.
    /// Memory Usage: 37.1 MB, less than 9.30% of C# online submissions for Fraction to Recurring Decimal.
    /// </summary>
    public string FractionToDecimal(int numerator, int denominator)
    {
        if (numerator == 0)
            return "0";

        long quotient = (long)numerator / (long)denominator;
        long remainder = (long)numerator % (long)denominator;

        if (remainder == 0)
            return quotient.ToString();

        var dict = new Dictionary<long, int>();
        var list = new List<string>();

        if (quotient == 0 && (numerator < 0 ^ denominator < 0))
            list.Add("-");

        list.Add(quotient.ToString());
        list.Add(".");

        var idx = list.Count;

        while (remainder != 0)
        {
            dict.Add(remainder, idx);

            remainder = remainder * 10;
            idx++;

            list.Add(Math.Abs(remainder / denominator).ToString());
            remainder = remainder % denominator;

            if (dict.ContainsKey(remainder))
            {
                list.Insert(dict[remainder], "(");
                list.Add(")");

                break;
            }
        }

        var sb = new StringBuilder();
        foreach (var item in list)
            sb.Append(item);

        return sb.ToString();

    }


}