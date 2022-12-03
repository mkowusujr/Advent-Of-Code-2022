namespace AdventOfCode2022.Solutions;
using AdventOfCode2022.Utils.ExtentionMethods;

public static class DayThree
{
    static string SolutionDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Day #3");

    public static void ExecuteSoultions(string challengeOption, string inputFileName)
    {
        string filePath = Path.Combine(SolutionDirectory, inputFileName);
        // int totalGameScore;

        switch (challengeOption)
        {
            case "s2":
                // totalGameScore = ParseInputFile(filePath, gameStrategy: 2);
                // Console.WriteLine($"My total score would be {totalGameScore}");
                break;
            default:
                int prioritySum = FindSumOfPrioriies(filePath);
                Console.WriteLine($"The priority sum is {prioritySum}");
                break;
        }
    }

    private static int FindSumOfPrioriies(string fileName)
    {
        int prioritySum = 0;

        var inputFile = File.ReadLines(fileName);
        foreach (var line in inputFile)
        {
            string compartment1 = string.Join("", line.Take(line.Length / 2));
            string compartment2 = string.Join("", line.Skip(line.Length / 2));
            List<char> itemsInCommon = compartment1.Intersect(compartment2).ToList();
            prioritySum += itemsInCommon.Select(item => item.ToPriority()).Sum();
        }
        return prioritySum;
    }
}
