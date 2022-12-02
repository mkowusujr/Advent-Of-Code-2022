namespace AdventOfCode2022.Solutions;

public static class DayOne
{
    static string SolutionDirectory = Path.Combine(Directory.GetCurrentDirectory(), "DayOne");

    public static void ExecuteSoultions(string challengeOption, string inputFileName)
    {
        string filePath = Path.Combine(SolutionDirectory, inputFileName);
        var elvesAndTheirCalories = new Dictionary<int, int>();
        elvesAndTheirCalories.Add(1, 0);

        switch (challengeOption)
        {
            case "s2":
                List<(int, int)> keyValuePairs = FindElvesWithTheMostCalories(filePath);
                int calorieSum = GetSumOfTopThreeBiggestCalorieCounts(keyValuePairs);
                Console.WriteLine($"The sum of the top three calorie counts is {calorieSum}");
                break;
            default:
                (int elfPostion, int elfsCalories) = FindElvesWithTheMostCalories(filePath)[0];
                Console.WriteLine($"The elf with the most calories is #{elfPostion}, and they had {elfsCalories} calories");
                break;
        }
    }

    private static List<(int, int)> FindElvesWithTheMostCalories(string fileName)
    {
        var defaultKeyValuePair = (0, 0);
        var largestKeyValuePairs = new List<(int, int)>(3);
        largestKeyValuePairs.Add(defaultKeyValuePair);
        largestKeyValuePairs.Add(defaultKeyValuePair);
        largestKeyValuePairs.Add(defaultKeyValuePair);

        int currentElf = 1;
        var elvesAndTheirCalories = new Dictionary<int, int>();
        elvesAndTheirCalories.Add(currentElf, 0);

        var inputFile = File.ReadLines(fileName);
        foreach (var line in inputFile)
        {
            if (line.Equals(""))
            {
                largestKeyValuePairs = SetLargestKeyValuePairs(largestKeyValuePairs, (currentElf, elvesAndTheirCalories[currentElf]));

                currentElf++;
                elvesAndTheirCalories.Add(currentElf, 0);
            }
            else
            {
                string currentline = line.Trim();
                elvesAndTheirCalories[currentElf] += Int32.Parse(currentline);
            }
        }

        return largestKeyValuePairs;
    }

    private static List<(int, int)> SetLargestKeyValuePairs(List<(int, int)> largestKeyValuePairs, (int, int) newKeyValuePair)
    {
        if (newKeyValuePair.Item2 > largestKeyValuePairs[0].Item2)
        {
            largestKeyValuePairs[2] = largestKeyValuePairs[1];
            largestKeyValuePairs[1] = largestKeyValuePairs[0];
            largestKeyValuePairs[0] = newKeyValuePair;
        }
        else if (newKeyValuePair.Item2 > largestKeyValuePairs[1].Item2)
        {
            largestKeyValuePairs[2] = largestKeyValuePairs[1];
            largestKeyValuePairs[1] = newKeyValuePair;
        }
        else if (newKeyValuePair.Item2 > largestKeyValuePairs[2].Item2)
        {
            largestKeyValuePairs[2] = newKeyValuePair;
        }

        return largestKeyValuePairs;
    }

    private static int GetSumOfTopThreeBiggestCalorieCounts(List<(int, int)> largestKeyValuePairs){
        return largestKeyValuePairs.Select(kvp => kvp.Item2).Sum();
    }
}
