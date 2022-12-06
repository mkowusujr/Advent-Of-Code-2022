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
        Console.WriteLine($"The first marker after character {firstMarkerCharacterAt}");
    }

    private static int ParseFile(string fileName, int gameStrategy)
    {
        int characterAtMaker = 0;

        string inputLine = File.ReadLines(fileName).First();
        if (gameStrategy == 1)
        {
            int maxPacketLength = 4;

            for (var i = 0; i < inputLine.Length - maxPacketLength; i++)
            {
                string currentPacket = inputLine.Substring(startIndex: i, length: maxPacketLength);
                if (currentPacket.Distinct().ToList().Count == maxPacketLength)
                {
                    characterAtMaker = i + maxPacketLength;
                    break;
                }
            }
        }
        else
        {
            int maxMessageMakerLength = 14;
            for (var i = 0; i < inputLine.Length - maxMessageMakerLength; i++)
            {
                string currentPacket = inputLine.Substring(
                    startIndex: i,
                    length: maxMessageMakerLength
                );
                if (currentPacket.Distinct().ToList().Count == maxMessageMakerLength)
                {
                    characterAtMaker = i + maxMessageMakerLength;
                    break;
                }
            }
        }

        return characterAtMaker;
    }
}
