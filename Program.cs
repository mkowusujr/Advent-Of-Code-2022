namespace AdventOfCode2022;
internal class Program
{
    /// <summary>
    /// CLI to run solution for Advent Of Code 2022
    /// </summary>
    static void Main()
    {
        string dayOption = Environment.GetCommandLineArgs()[1];
        string inputFileOption = Environment.GetCommandLineArgs()[2];

        string inputFileName = SelectedInputFileName(inputFileOption);
        ExecuteSolutionsForSpecifiedDay(dayOption, inputFileName);
    }

    /// <summary>
    /// Executes the soultion for the specified day
    /// </summary>
    /// <param name="dayOption">The day to run the solution for. Ex: "d1"</param>
    /// <param name="inputFileName">The name of the input file</param>
    private static void ExecuteSolutionsForSpecifiedDay(string dayOption, string inputFileName) {
        dayOption = dayOption.ToLower();

        switch(dayOption) {
            case "d1":
                Solutions.DayOne.ExecuteSoultionOne(inputFileName);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(dayOption), $"Unexpected day option: {dayOption}");
        }
    }

    /// <summary>
    /// Selects the input file to use to execute the solution with
    /// </summary>
    /// <param name="inputFileOption">The Input filename. Ex: "a" for input file 1</param>
    /// <returns>THe filename to use in the solution execution</returns>
    private static string SelectedInputFileName(string inputFileOption) => inputFileOption switch
    {
        "a" => "input-1.text",
        "b" => "input-2.text",
        "c" => "input-3.txt",
        _ => throw new ArgumentOutOfRangeException(nameof(inputFileOption), $"Unexpected input file option: {inputFileOption}")
    };
}
