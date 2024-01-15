namespace ShuntingYard.Tests;

public class EvaluationProcessorTests
{
    private readonly EvaluationProcessor _sut = new();

    [Theory]
    [InlineData("10 3 + 7 - 18 * 9 /", 12)]
    [InlineData("10 -3 * 7 + 1.8 * 9.112 /", -4.543459174714662)]
    [InlineData("10 -3 * -7 + 1.8 * 9.112 /", -7.309043020193153)]
    public void ValidTokensSequence_Success(string input, double expected)
    {
        var rpnTokens = input.Split(' ').ToList();
        var actual = _sut.Evaluate(rpnTokens);
        Assert.Equal(expected, actual);
    }
}