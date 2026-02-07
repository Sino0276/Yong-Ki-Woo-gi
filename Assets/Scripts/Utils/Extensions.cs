using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public static class Extensions
{
    private static readonly string[] koreanUnit = { "만", "억", "조", "경", "해" };

    public static string ToKoreanUnitString(this int value)
    {
        return ToKoreanUnitString(value.ToString());
    }

    public static string ToKoreanUnitString(this float value)
    {
        return ToKoreanUnitString(value.ToString("F0"));
    }

    public static string ToKoreanUnitString(this string value)
    {
        string result = "";

        string[] units = Regex.Replace(value, @"\B(?=(\d{4})+(?!\d))", ",").Split(',').Reverse().ToArray();

        for (int i = 0; i < units.Length; i++)
        {
            if (i == 0)
            {
                result = $"{units[i]}";
                continue;
            }
            result = $"{units[i]}{koreanUnit[i - 1]}{result}";
        }

        return result;
    }
}