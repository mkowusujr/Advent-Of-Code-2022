namespace AdventOfCode2022.Solutions;

public record DeviceStorageFile
{
    public string FileName { get; init; } = string.Empty;
    public int FileSize { get; init; }
    public DeviceStorageDirectory? ParentDirectory { get; init; }

    public override string ToString()
    {
        return $"- {FileName} (file, size={FileSize})";
    }
}

public class DeviceStorageDirectory
{
    public string DirectoryName { get; init; } = string.Empty;
    public DeviceStorageDirectory? ParentDirectory { get; init; }
    public List<DeviceStorageDirectory> ChildrenDirectories { get; private set; } = new();
    public List<DeviceStorageFile> ChildrenFiles { get; private set; } = new();

    public void AddChildrenFile(DeviceStorageFile file)
    {
        ChildrenFiles.Add(file);
    }

    public void AddChildrenDirectory(DeviceStorageDirectory directory)
    {
        ChildrenDirectories.Add(directory);
    }

    public int GetDirectorySize()
    {
        int sum = 0;
        foreach (var childDirectory in ChildrenDirectories)
        {
            sum += childDirectory.GetDirectorySize();
        }

        foreach (var childFile in ChildrenFiles)
        {
            sum += childFile.FileSize;
        }

        return sum;
    }

    public int GetDirectoriesWithLessThan100KSize()
    {
        int sum = 0;
        const int MaxDirectorySize = 100_000;

        foreach (var childDirectory in ChildrenDirectories)
        {
            sum +=
                childDirectory.GetDirectorySize() <= MaxDirectorySize
                    ? childDirectory.GetDirectorySize()
                    : 0;
            sum += childDirectory.GetDirectoriesWithLessThan100KSize();
        }

        return sum;
    }

    public List<DeviceStorageDirectory> GetCanidatesForDeletion(int sizeRequirement)
    {
        List<DeviceStorageDirectory> canidatesForDeletion = new();
        if (GetDirectorySize() > sizeRequirement)
        {
            canidatesForDeletion.Add(this);
        }

        foreach (var childDirectory in ChildrenDirectories)
        {
            if (childDirectory.GetDirectorySize() > sizeRequirement)
            {
                canidatesForDeletion.Add(childDirectory);
            }

            canidatesForDeletion.AddRange(childDirectory.GetCanidatesForDeletion(sizeRequirement));
        }

        return canidatesForDeletion;
    }

    public override string ToString()
    {
        return ToString(directoryLevelDown: 1);
    }

    public string ToString(int directoryLevelDown)
    {
        string directoryContents = $"- {DirectoryName} (dir,  size={GetDirectorySize()})";

        string tabs = "";
        for (var i = 0; i < directoryLevelDown; i++)
        {
            tabs += "\t";
        }

        foreach (var childDirectory in ChildrenDirectories)
        {
            directoryContents +=
                $"\n{tabs}{childDirectory.ToString(directoryLevelDown: directoryLevelDown + 1)}";
        }

        foreach (var childFile in ChildrenFiles)
        {
            directoryContents += $"\n{tabs}{childFile}";
        }

        return directoryContents;
    }
}

public static class DeviceStorageExtentionMethods
{
    public static DeviceStorageFile ToDeviceStorageFile(
        this string input,
        DeviceStorageDirectory currentDirectory
    )
    {
        string fileSize = input.Split(" ")[0];
        string fileName = input.Split(" ")[1];
        return new DeviceStorageFile
        {
            FileSize = Int32.Parse(fileSize),
            FileName = fileName,
            ParentDirectory = currentDirectory
        };
    }

    public static DeviceStorageDirectory ToDeviceStorageDirectory(
        this string input,
        DeviceStorageDirectory currentDirectory
    )
    {
        string directoryName = input.Split(" ")[1];
        return new DeviceStorageDirectory
        {
            DirectoryName = directoryName,
            ParentDirectory = currentDirectory
        };
    }
}
