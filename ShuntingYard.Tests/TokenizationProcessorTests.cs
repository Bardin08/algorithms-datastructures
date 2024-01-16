namespace ShuntingYard.Tests;

public class TokenizationProcessorTests
{
    private readonly TokenizationProcessor _sut = new();
    
    [Theory]
    [InlineData("10+3", "10", "+", "3")]
    public void Positive_IntNumbers_Success(string input, params string[] expectedTokens)
    {
        var actualTokens = _sut.Tokenize(input);
        Assert.Equivalent(expectedTokens, actualTokens);
    }

    [Theory]
    [InlineData("-10+-3", "-10", "+", "-3")]
    public void Negative_IntNumbers_Success(string input, params string[] expectedTokens)
    {
        var actualTokens = _sut.Tokenize(input);
        Assert.Equivalent(expectedTokens, actualTokens);
    }

    [Theory]
    [InlineData("10+-3", "10", "+", "-3")]
    public void PositiveAndNegative_IntNumbers_Success(string input, params string[] expectedTokens)
    {
        var actualTokens = _sut.Tokenize(input);
        Assert.Equivalent(expectedTokens, actualTokens);
    }

    [Theory]
    [InlineData("10.65+3.65", "10.65", "+", "3.65")]
    public void Positive_DoubleNumbers_Success(string input, params string[] expectedTokens)
    {
        var actualTokens = _sut.Tokenize(input);
        Assert.Equivalent(expectedTokens, actualTokens);
    }

    [Theory]
    [InlineData("-10.65+-3.65", "-10.65", "+", "-3.65")]
    public void Negative_DoubleNumbers_Success(string input, params string[] expectedTokens)
    {
        var actualTokens = _sut.Tokenize(input);
        Assert.Equivalent(expectedTokens, actualTokens);
    }

    [Theory]
    [InlineData("10.65+-3.22", "10.65", "+", "-3.22")]
    public void PositiveAndNegative_DoubleNumbers_Success(string input, params string[] expectedTokens)
    {
        var actualTokens = _sut.Tokenize(input);
        Assert.Equivalent(expectedTokens, actualTokens);
    }

    [Theory]
    [InlineData("10.65+-3.22", "10.65", "+", "-3.22")]
    public void DoubleNumbers_DecimalPointValidation_Success(string input, params string[] expectedTokens)
    {
        var actualTokens = _sut.Tokenize(input);
        Assert.Equivalent(expectedTokens, actualTokens);
    }

    [Theory]
    [InlineData("(-10 + -7) + 18", "( -10 + -7 ) + 18")]
    [InlineData("(-10 + (-7)) + 18", "( -10 + ( -7 ) ) + 18")]
    [InlineData("((10 + 3 - 7) - 18) + 9", "( ( 10 + 3 - 7 ) - 18 ) + 9")]
    [InlineData("(2 + 5 * 8) * (4 - 2 / 9)", "( 2 + 5 * 8 ) * ( 4 - 2 / 9 )")]
    public void ExpressionWithBrackets_IsValid_Success(string input, string expected)
    {
        var expectedTokens = expected.Split(' ');
        var actualTokens = _sut.Tokenize(input);
        Assert.Equivalent(expectedTokens, actualTokens);
    }

    [Theory]
    [InlineData("2^10 + 6^2 - 22.5 / (10 * 99) ^ 83", "2 ^ 10 + 6 ^ 2 - 22.5 / ( 10 * 99 ) ^ 83")]
    [InlineData("(2^10 + 6^2)", "( 2 ^ 10 + 6 ^ 2 )")]
    [InlineData("(2^10 + (9 + 6^2)) ^ 3", "( 2 ^ 10 + ( 9 + 6 ^ 2 ) ) ^ 3")]
    public void ExpressionWithPowers_IsValid_Success(string input, string expectedTokens)
    {
        var expected = expectedTokens.Split(' ');
        var actualTokens = _sut.Tokenize(input);
        Assert.Equivalent(expected, actualTokens);
    }

    [Theory]
    [InlineData("10.6.5+-3.22")]
    public void DoubleNumbers_DecimalPointValidation_Failed(string input)
    {
        Action action = () => _sut.Tokenize(input);
        Assert.Throws<Exception>(action);
    }
}