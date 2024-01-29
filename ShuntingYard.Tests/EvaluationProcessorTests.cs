namespace ShuntingYard.Tests;

public class EvaluationProcessorTests
{
    private readonly EvaluationProcessor _sut = new();

    [Theory]
    [InlineData("10 3 + 7 - 18 * 9 /", 12)]
    [InlineData("10 -3 * 7 + 1.8 * 9.112 /", -4.543459174714662)]
    [InlineData("10 -3 * -7 + 1.8 * 9.112 /", -7.309043020193153)]
    [InlineData("2 10 ^ 6 2 ^ + 22.5 10 / 99 * 83 ^ -", -7.393841812732971E+194)]
    [InlineData("2 5 8 * + 4 2 9 / - *", 158.66666666666666)]
    [InlineData("1 sin 35 34 + 67 - cos - cos 34 sin +", 0.8371667739123354)]
    public void ValidTokensSequence_Success(string input, double expected)
    {
        var rpnTokens = input.Split(' ').ToList();
        var actual = _sut.Evaluate(rpnTokens);
        Assert.Equal(expected, actual);
    }
}