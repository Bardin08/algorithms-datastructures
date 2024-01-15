namespace ShuntingYard.Tests;

public class TokenizationProcessorTests
{
    [Theory]
    [InlineData("10+3", "10", "+", "3")]
    public void Positive_IntNumbers_Success(string input, params string[] expectedTokens)
    {
        var tokenizer = new TokenizationProcessor();
        var actualTokens = tokenizer.Tokenize(input);
        Assert.Equivalent(expectedTokens, actualTokens);
    }

    [Theory]
    [InlineData("-10+-3", "-10", "+", "-3")]
    public void Negative_IntNumbers_Success(string input, params string[] expectedTokens)
    {
        var tokenizer = new TokenizationProcessor();
        var actualTokens = tokenizer.Tokenize(input);
        Assert.Equivalent(expectedTokens, actualTokens);
    }

    [Theory]
    [InlineData("10+-3", "10", "+", "-3")]
    public void PositiveAndNegative_IntNumbers_Success(string input, params string[] expectedTokens)
    {
        var tokenizer = new TokenizationProcessor();
        var actualTokens = tokenizer.Tokenize(input);
        Assert.Equivalent(expectedTokens, actualTokens);
    }

    [Theory]
    [InlineData("10.65+3.65", "10.65", "+", "3.65")]
    public void Positive_DoubleNumbers_Success(string input, params string[] expectedTokens)
    {
        var tokenizer = new TokenizationProcessor();
        var actualTokens = tokenizer.Tokenize(input);
        Assert.Equivalent(expectedTokens, actualTokens);
    }

    [Theory]
    [InlineData("-10.65+-3.65", "-10.65", "+", "-3.65")]
    public void Negative_DoubleNumbers_Success(string input, params string[] expectedTokens)
    {
        var tokenizer = new TokenizationProcessor();
        var actualTokens = tokenizer.Tokenize(input);
        Assert.Equivalent(expectedTokens, actualTokens);
    }

    [Theory]
    [InlineData("10.65+-3.22", "10.65", "+", "-3.22")]
    public void PositiveAndNegative_DoubleNumbers_Success(string input, params string[] expectedTokens)
    {
        var tokenizer = new TokenizationProcessor();
        var actualTokens = tokenizer.Tokenize(input);
        Assert.Equivalent(expectedTokens, actualTokens);
    }
}