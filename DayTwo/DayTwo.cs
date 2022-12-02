namespace AdventOfCode2022.Solutions;

public static class DayTwo
{
    static string SolutionDirectory = Path.Combine(Directory.GetCurrentDirectory(), "DayTwo");

    public static void ExecuteSoultions(string challengeOption, string inputFileName)
    {
        string filePath = Path.Combine(SolutionDirectory, inputFileName);
        int totalGameScore;

        switch (challengeOption)
        {
            case "s2":
                totalGameScore = ParseInputFile(filePath, gameStrategy: 2);
                Console.WriteLine($"My total score would be {totalGameScore}");
                break;
            default:
                totalGameScore = ParseInputFile(filePath, gameStrategy: 1);
                Console.WriteLine($"My total score would be {totalGameScore}");
                break;
        }
    }

    enum HandShape
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    enum EncryptedMove
    {
        A = HandShape.Rock,
        B = HandShape.Paper,
        C = HandShape.Scissors,
        X = HandShape.Rock,
        Y = HandShape.Paper,
        Z = HandShape.Scissors,
    }

    enum GameOutcomes
    {
        Loss = 0,
        Tie = 3,
        Win = 6
    }

    enum DecryptedMove
    {
        X = GameOutcomes.Loss,
        Y = GameOutcomes.Tie,
        Z = GameOutcomes.Win
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

    private static (EncryptedMove, EncryptedMove) TurnPlayerInputsToEncryptedMoveEnum(
        string[] playerInputs
    )
    {
        EncryptedMove opponentsMove;
        EncryptedMove yourMove;

        Enum.TryParse<EncryptedMove>(playerInputs[0], out opponentsMove);
        Enum.TryParse<EncryptedMove>(playerInputs[1], out yourMove);
        return (opponentsMove, yourMove);
    }

    private static (EncryptedMove, DecryptedMove) TurnPlayerInputsToStrategyTwoEnumPair(
        string[] playerInputs
    )
    {
        EncryptedMove opponentsMove;
        DecryptedMove gameOutcome;

        Enum.TryParse<EncryptedMove>(playerInputs[0], out opponentsMove);
        Enum.TryParse<DecryptedMove>(playerInputs[1], out gameOutcome);
        return (opponentsMove, gameOutcome);
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
                (EncryptedMove opponentsMove, EncryptedMove yourMove) =
                    TurnPlayerInputsToEncryptedMoveEnum(inputs);
                totalGameScore += PlayRoundStrategyOne(opponentsMove, yourMove);
            }
            else
            {
                (EncryptedMove opponentsMove, DecryptedMove gameOutcome) =
                    TurnPlayerInputsToStrategyTwoEnumPair(inputs);
                totalGameScore += PlayRoundStrategyTwo(opponentsMove, gameOutcome);
            }
        }

        return totalGameScore;
    }
}
