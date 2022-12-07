namespace AdventOfCode2022.Solutions;
using AdventOfCode2022.Utils.ExtentionMethods;

public static class DaySeven
{
    static string SolutionDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Day #7");

    public static void ExecuteSoultions(string challengeOption, string inputFileName)
    {
        string filePath = Path.Combine(SolutionDirectory, inputFileName);

        if (challengeOption.Equals("s2"))
        {
            int sizeOfDirectoryToDelete = ParseFile(filePath, gameStrategy: 2);
            Console.WriteLine($"Thee size of the directory to delete is {sizeOfDirectoryToDelete}");
        }
        else
        {
            int sum = ParseFile(filePath, gameStrategy: 1);
            Console.WriteLine(
                $"The sum the sizes of the directories with a total size of at most 100000 is {sum}"
            );
        }
    }

    private static DeviceStorageDirectory SetupHomeDirectory(string fileName)
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

        return homeDirectory;
    }

    private static int ParseFile(string fileName, int gameStrategy)
    {
        DeviceStorageDirectory homeDirectory = SetupHomeDirectory(fileName);
        // Console.WriteLine(homeDirectory);
        int sizeOfDirectoryToDelete = 0;

        if (gameStrategy == 2)
        {
            const int TotalDiskSpace = 70_000_000;
            const int SpaceNeededForUpdate = 30_000_000;
            int spaceUnused = TotalDiskSpace - homeDirectory.GetDirectorySize();
            int spaceNeeded = SpaceNeededForUpdate - spaceUnused;
            // Console.WriteLine($"I need {spaceNeeded}");

            List<DeviceStorageDirectory> canidatesForDeletion = homeDirectory
                .GetCanidatesForDeletion(spaceNeeded)
                .Distinct()
                .OrderBy(directory => directory.GetDirectorySize())
                .ToList();

            sizeOfDirectoryToDelete = canidatesForDeletion
                .Select(d => d.GetDirectorySize())
                .First();
        }
        return gameStrategy == 1
            ? homeDirectory.GetDirectoriesWithLessThan100KSize()
            : sizeOfDirectoryToDelete;
    }
}
