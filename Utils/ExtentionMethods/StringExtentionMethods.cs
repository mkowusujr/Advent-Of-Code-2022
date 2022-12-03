namespace AdventOfCode2022.Utils.ExtentionMethods;

public static class StringExtentionMethods
{
    public static T ToEnum<T>(this string text)
    {
        return (T)Enum.Parse(typeof(T), text);
    }

    public static int ToPriority(this char item)
    {
        int asciiValue = (int)item;
        return asciiValue < 91? asciiValue - 38 : asciiValue - 96;
    }
}