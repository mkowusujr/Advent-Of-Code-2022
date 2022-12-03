namespace AdventOfCode2022.Utils.ExtentionMethods;

public static class StringExtentionMethods
{
    public static T ToEnum<T>(this string text)
    {
        return (T)Enum.Parse(typeof(T), text);
    }
}