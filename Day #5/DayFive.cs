namespace AdventOfCode2022.Solutions;
using AdventOfCode2022.Utils.ExtentionMethods;

public static class DayFive
{
    static string SolutionDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Day #5");

    public static void ExecuteSoultions(string challengeOption, string inputFileName)
    {
        string filePath = Path.Combine(SolutionDirectory, inputFileName);

        string cratesAtTheTopOfEachStack = ParseFile(filePath, gameStrategy: challengeOption.Equals("s2") ? 2 : 1);
        Console.WriteLine($"The crates at the top of each stack is {cratesAtTheTopOfEachStack}");
    }

    private static Dictionary<int, Stack<char>> SetupCrateStacks(string fileName)
    {
        bool isFirstLine = true;
        var crates = new Dictionary<int, Stack<char>>();

        var inputFile = File.ReadLines(fileName).Reverse();
        foreach (var line in inputFile)
        {

            if (
                (!line.Equals("") && !line.StartsWith("m"))
                && (!Char.IsDigit((char)line[1])))
            {
                var initialClean = line.Replace("    ", "_").Replace(" ", "").Replace("[", "").Replace("]", "");
                Console.WriteLine(initialClean);
                if (isFirstLine == true)
                {
                    int crateStackNumber = 1;
                    foreach (char c in initialClean)
                    {
                        crates.Add(crateStackNumber, new Stack<char>());
                        Console.WriteLine($"add {crateStackNumber}");

                        crateStackNumber++;
                    }
                    isFirstLine = false;
                }
                Console.WriteLine($"length is {initialClean.Length}");
                for (var i = 1; i <= initialClean.Length; i++)
                {
                    if (!initialClean[i - 1].Equals('_'))
                    {
                        crates[i].Push(initialClean[i - 1]);
                        Console.WriteLine($"Pushing {initialClean[i - 1]} to crate stack {i}");
                    }
                }
            }

        }
        return crates;
    }

    private static string ParseFile(string fileName, int gameStrategy)
    {
        Dictionary<int, Stack<char>> crates = SetupCrateStacks(fileName);

        var inputFile = File.ReadLines(fileName);
        foreach (var line in inputFile)
        {
            if (line.StartsWith("m"))
            {
                List<int> commands = line.Replace("move ", "").Replace(" from ", ",").Replace(" to ", ",").Split(',').Select(c => Int32.Parse(c)).ToList();
                Console.WriteLine(string.Join(",", commands));
                if (gameStrategy == 1)
                {
                    for (var i = 0; i < commands[0]; i++)
                    {
                        char tempStorage = crates[commands[1]].Pop();
                        Console.WriteLine($"popped {tempStorage} from crate {commands[1]} for the {i + 1} time");
                        crates[commands[2]].Push(tempStorage);
                        Console.WriteLine($"pushed {tempStorage} from crate {commands[2]} for the {i + 1} time");
                    }
                }
                else
                {
                    Stack<char> tempStorage = new();
                    for (var i = 0; i < commands[0]; i++)
                    {
                        tempStorage.Push(crates[commands[1]].Pop());
                        Console.WriteLine($"popped {tempStorage} from crate {commands[1]} for the {i + 1} time");
                    }

                    for (var i = 0; i < commands[0]; i++)
                    {
                        crates[commands[2]].Push(tempStorage.Pop());
                        Console.WriteLine($"pushed {tempStorage} from crate {commands[2]} for the {i + 1} time");
                    }
                }
            }
        }

        string cratesAtTheTopOfEachStack = "";
        foreach (KeyValuePair<int, Stack<char>> entry in crates)
        {
            Console.WriteLine(entry.Value.Peek());
            cratesAtTheTopOfEachStack += entry.Value.Peek();
        }

        return cratesAtTheTopOfEachStack;
    }
}
