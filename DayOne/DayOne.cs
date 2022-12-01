namespace AdventOfCode2022.Solutions;

public static class DayOne {
    static readonly string SolutionDirectory = Directory.GetCurrentDirectory();

    public static void ExecuteSoultionOne(string inputFileName){
        string filePath = Path.Combine(SolutionDirectory, inputFileName);
        Console.WriteLine(filePath);
    }

}