namespace AdventOfCode2022.Solutions;

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