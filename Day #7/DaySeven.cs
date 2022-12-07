namespace AdventOfCode2022.Solutions;
using AdventOfCode2022.Utils.ExtentionMethods;

public static class DaySeven
{
    static string SolutionDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Day #7");

    public static void ExecuteSoultions(string challengeOption, string inputFileName)
    {
        string filePath = Path.Combine(SolutionDirectory, inputFileName);

        int sum = ParseFile(filePath, gameStrategy: challengeOption.Equals("s2") ? 2 : 1);
        Console.WriteLine(
            $"The sum the sizes of the directories with a total size of at most 100000 is {sum}"
        );
    }

    private static DeviceStorageDirectory SetupHomeDirectory(string fileName, int gameStrategy)
    {
        DeviceStorageDirectory? currentDirectory = new DeviceStorageDirectory
        {
            DirectoryName = "/",
            ParentDirectory = null
        };
        DeviceStorageDirectory homeDirectory = currentDirectory;

        List<string> dd = new List<string>();
        bool creationMode = false;

        var inputFile = File.ReadLines(fileName).Skip(1);
        foreach (var line in inputFile)
        {
            if (gameStrategy == 1)
            {
                creationMode = line.Equals("$ ls") || !line.StartsWith("$ cd");

                if (creationMode && line.StartsWith("dir"))
                {
                    currentDirectory?.AddChildrenDirectory(
                        line.ToDeviceStorageDirectory(currentDirectory)
                    );
                }
                if (creationMode && (!line.StartsWith("dir") && !line.StartsWith("$")))
                {
                    currentDirectory?.AddChildrenFile(line.ToDeviceStorageFile(currentDirectory));
                }

                if (line.StartsWith("$ cd") && line.Contains(".."))
                {
                    currentDirectory = currentDirectory?.ParentDirectory;
                }
                if (line.StartsWith("$ cd") && !line.Contains(".."))
                {
                    string directoryBeingAccessed = line.Split(" ")[2];
                    currentDirectory = currentDirectory?.ChildrenDirectories.First(
                        directory => directory.DirectoryName.Equals(directoryBeingAccessed)
                    );
                }
            }
            else { }
        }

        return homeDirectory;
    }

    private static int ParseFile(string fileName, int gameStrategy)
    {
        DeviceStorageDirectory homeDirectory = SetupHomeDirectory(
            fileName,
            gameStrategy: gameStrategy
        );
        Console.WriteLine(homeDirectory);

        return homeDirectory.GetDirectoriesWithLessThan100KSize();
    }
}
