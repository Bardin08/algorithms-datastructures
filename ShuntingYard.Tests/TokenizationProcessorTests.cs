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
    [InlineData("10.6.5+-3.22")]
    public void DoubleNumbers_DecimalPointValidation_Failed(string input)
    {
        Action action = () => _sut.Tokenize(input);
        Assert.Throws<Exception>(action);
    }
}