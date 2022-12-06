namespace AdventOfCode2022.Solutions;
using AdventOfCode2022.Utils.ExtentionMethods;

public static class DaySix
{
    static string SolutionDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Day #6");

    public static void ExecuteSoultions(string challengeOption, string inputFileName)
    {
        string filePath = Path.Combine(SolutionDirectory, inputFileName);

        int firstMarkerCharacterAt = ParseFile(
            filePath,
            gameStrategy: challengeOption.Equals("s2") ? 2 : 1
        );
        Console.WriteLine(
            $"The first marker after character {firstMarkerCharacterAt}"
        );
    }

    private static int ParseFile(string fileName, int gameStrategy)
    {
        int firstMarkerCharacterAt = 0;

        string inputLine = File.ReadLines(fileName).First();

        for (var i = 0; i < inputLine.Length - 4; i++)
        {
            string currentPacket = inputLine.Substring(startIndex: i, length: 4);
            if (currentPacket.Distinct().ToList().Count == 4)
            {
                firstMarkerCharacterAt = i + 4;
                break;
            }
        }
        return firstMarkerCharacterAt;
    }
}
