namespace AdventOfCode2022.Solutions;
using AdventOfCode2022.Utils.ExtentionMethods;

public static class DayThree
{
    static string SolutionDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Day #3");

    public static void ExecuteSoultions(string challengeOption, string inputFileName)
    {
        string filePath = Path.Combine(SolutionDirectory, inputFileName);
        int prioritySum = FindSumOfPrioriies(
            filePath,
            gameStrategy: challengeOption.Equals("s2") ? 2 : 1
        );
        Console.WriteLine($"The priority sum is {prioritySum}");
    }

    private static int FindSumOfPrioriies(string fileName, int gameStrategy)
    {
        int prioritySum = 0;

        int lineRowNumber = 0;
        List<string> partition = new(3);

        var inputFile = File.ReadLines(fileName);
        foreach (var line in inputFile)
        {
            if (gameStrategy == 1)
            {
                string compartment1 = string.Join("", line.Take(line.Length / 2));
                string compartment2 = string.Join("", line.Skip(line.Length / 2));
                List<char> itemsInCommon = compartment1.Intersect(compartment2).ToList();
                prioritySum += itemsInCommon.Select(item => item.ToPriority()).Sum();
            }
            else
            {
                lineRowNumber++;
                partition.Add(line);
                if (lineRowNumber % 3 == 0)
                {
                    List<char> itemsInCommon = partition[0]
                        .Intersect(partition[1])
                        .Intersect(partition[2])
                        .ToList();
                    prioritySum += itemsInCommon.Select(item => item.ToPriority()).Sum();
                    partition.Clear();
                }
            }
        }
        return prioritySum;
    }
}
