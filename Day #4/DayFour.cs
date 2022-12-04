namespace AdventOfCode2022.Solutions;
using AdventOfCode2022.Utils.ExtentionMethods;

public static class DayFour
{
    static string SolutionDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Day #4");

    public static void ExecuteSoultions(string challengeOption, string inputFileName)
    {
        string filePath = Path.Combine(SolutionDirectory, inputFileName);

        int numberOfPairs = ParseFile(filePath, gameStrategy: challengeOption.Equals("s2") ? 2 : 1);
        Console.WriteLine($"The number of pairs is {numberOfPairs}");
    }

    private static int ParseFile(string fileName, int gameStrategy)
    {
        int numberOfPairs = 0;

        var inputFile = File.ReadLines(fileName);
        foreach (var line in inputFile)
        {
            int[] assignments = line.Split(new Char[] { ',', '-' })
                .Select(item => Int32.Parse(item))
                .ToArray();
            
            if (
                (gameStrategy == 1)
                && (
                    (assignments[0] >= assignments[2] && assignments[1] <= assignments[3])
                    || (assignments[2] >= assignments[0] && assignments[3] <= assignments[1])
                )
            )
            {
                numberOfPairs++;
            }
            
            if (
                (gameStrategy == 2)
                && (
                    (assignments[0] <= assignments[3] && assignments[1] >= assignments[2])
                    || (assignments[2] >= assignments[0] && assignments[3] <= assignments[0])
                )
            )
            {
                numberOfPairs++;
            }
        }
        return numberOfPairs;
    }
}
