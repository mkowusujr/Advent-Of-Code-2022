namespace AdventOfCode2022.Solutions;

public static class DayThree
{
    static string SolutionDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Day #3");

    public static void ExecuteSoultions(string challengeOption, string inputFileName)
    {
        string filePath = Path.Combine(SolutionDirectory, inputFileName);
        int totalGameScore;

        switch (challengeOption)
        {
            case "s2":
                // totalGameScore = ParseInputFile(filePath, gameStrategy: 2);
                // Console.WriteLine($"My total score would be {totalGameScore}");
                break;
            default:
                // totalGameScore = ParseInputFile(filePath, gameStrategy: 1);
                // Console.WriteLine($"My total score would be {totalGameScore}");
                break;
        }
    }

   
}
