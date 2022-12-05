namespace AdventOfCode2022.Solutions;
using AdventOfCode2022.Utils.ExtentionMethods;

public static class DayTwo
{
    static string SolutionDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Day #2");

    public static void ExecuteSoultions(string challengeOption, string inputFileName)
    {
        string filePath = Path.Combine(SolutionDirectory, inputFileName);
        int totalGameScore = ParseInputFile(filePath, gameStrategy: challengeOption.Equals("s2") ? 2 : 1);
        
        Console.WriteLine($"My total score would be {totalGameScore}");
    }

    private static int PlayRoundStrategyOne(EncryptedMove opponentsMove, EncryptedMove yourMove)
    {
        if (opponentsMove == yourMove)
        {
            return (int)GameOutcomes.Tie + (int)yourMove;
        }
        else if (
            (opponentsMove == EncryptedMove.A && yourMove == EncryptedMove.Y)
            || (opponentsMove == EncryptedMove.B && yourMove == EncryptedMove.Z)
            || (opponentsMove == EncryptedMove.C && yourMove == EncryptedMove.X)
        )
        {
            return (int)GameOutcomes.Win + (int)yourMove;
        }
        else
        {
            return (int)GameOutcomes.Loss + (int)yourMove;
        }
    }

    private static int PlayRoundStrategyTwo(EncryptedMove opponentsMove, DecryptedMove yourMove)
    {
        switch (yourMove)
        {
            case DecryptedMove.X:
                switch (opponentsMove)
                {
                    case EncryptedMove.A:
                        return (int)EncryptedMove.C + (int)yourMove;
                    case EncryptedMove.B:
                        return (int)EncryptedMove.A + (int)yourMove;
                    default:
                        return (int)EncryptedMove.B + (int)yourMove;
                }
            case DecryptedMove.Y:
                return (int)opponentsMove + (int)yourMove;
            default:
                switch (opponentsMove)
                {
                    case EncryptedMove.A:
                        return (int)EncryptedMove.B + (int)yourMove;
                    case EncryptedMove.B:
                        return (int)EncryptedMove.C + (int)yourMove;
                    default:
                        return (int)EncryptedMove.A + (int)yourMove;
                }
        }
    }

    private static int ParseInputFile(string fileName, int gameStrategy)
    {
        int totalGameScore = 0;
        var inputFile = File.ReadLines(fileName);
        foreach (var line in inputFile)
        {
            string[] inputs = line.Split(" ");

            if (gameStrategy == 1)
            {
                EncryptedMove opponentsMove = inputs[0].ToEnum<EncryptedMove>();
                EncryptedMove yourMove = inputs[1].ToEnum<EncryptedMove>();
                totalGameScore += PlayRoundStrategyOne(opponentsMove, yourMove);
            }
            else
            {
                EncryptedMove opponentsMove = inputs[0].ToEnum<EncryptedMove>();
                DecryptedMove gameOutcome = inputs[1].ToEnum<DecryptedMove>();
                totalGameScore += PlayRoundStrategyTwo(opponentsMove, gameOutcome);
            }
        }

        return totalGameScore;
    }
}
