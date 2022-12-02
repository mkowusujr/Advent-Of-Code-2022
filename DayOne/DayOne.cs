namespace AdventOfCode2022.Solutions;

public static class DayOne {
    static string SolutionDirectory = Path.Combine(Directory.GetCurrentDirectory(), "DayOne");

    public static void ExecuteSoultions(string challengeOption, string inputFileName){
        string filePath = Path.Combine(SolutionDirectory, inputFileName);
        var elvesAndTheirCalories = new Dictionary<int, int>();
        elvesAndTheirCalories.Add(1, 0);

        switch(challengeOption){
            case "c2":
                Console.WriteLine();
                break;
            default:
                (int elfPostion, int elfsCalories) = FindElfWithTheMostCalories(filePath);
                Console.WriteLine($"The elf with the most calories is #{elfPostion}, and they had {elfsCalories} calories");
                break;
        }
    }



    private static (int, int) FindElfWithTheMostCalories(string fileName) {
        var largestKeyValuePair = (0, 0);
        
        int currentElf = 1;
        var elvesAndTheirCalories = new Dictionary<int, int>();
        elvesAndTheirCalories.Add(currentElf, 0);

        var inputFile = File.ReadLines(fileName);
        foreach (var line in inputFile)
        {
            if (line.Equals("")){
                if(elvesAndTheirCalories[currentElf] >= largestKeyValuePair.Item2){
                    largestKeyValuePair = (currentElf, elvesAndTheirCalories[currentElf]);
                }

                currentElf ++;
                elvesAndTheirCalories.Add(currentElf, 0);
            }
            else {
                string currentline = line.Trim();
                elvesAndTheirCalories[currentElf] += Int32.Parse(currentline);
            }
        }

        return largestKeyValuePair;
    }
}
