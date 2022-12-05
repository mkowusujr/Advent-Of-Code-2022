namespace AdventOfCode2022.Solutions;
using AdventOfCode2022.Utils.ExtentionMethods;

public static class DaySix
{
    static string SolutionDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Day #6");

    public static void ExecuteSoultions(string challengeOption, string inputFileName)
    {
        string filePath = Path.Combine(SolutionDirectory, inputFileName);

        int sum = ParseFile(filePath, gameStrategy: challengeOption.Equals("s2") ? 2 : 1);
        Console.WriteLine($"The priority sum is {sum}");
    }

    private static int ParseFile(string fileName, int gameStrategy)
    {
        int sum = 0;


        var inputFile = File.ReadLines(fileName);
        foreach (var line in inputFile)
        {
            if (gameStrategy == 1)
            {
                
            }
            else
            {
                
            }
        }
        return sum;
    }
}
