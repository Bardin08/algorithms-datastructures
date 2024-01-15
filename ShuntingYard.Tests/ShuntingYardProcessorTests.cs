namespace ShuntingYard.Tests;

public class ShuntingYardProcessorTests
{
    private readonly ShuntingYardProcessor _sut = new();

    [Theory]
    [InlineData("( ( 10 + 3 - 7 ) * 18 ) / 9", "10 3 + 7 - 18 * 9 /")]
    [InlineData("( ( 10 * -3 + 7 ) * 1.8 ) / 9.112", "10 -3 * 7 + 1.8 * 9.112 /")]
    [InlineData("( ( 10 * -3 + ( -7 ) ) * 1.8 ) / 9.112", "10 -3 * -7 + 1.8 * 9.112 /")]
    public void ExpressionValid_Successful(string input, string expectedTokens)
    {
        var tokens = input.Split(' ').ToList();
        var expected = expectedTokens.Split(' ');

        var actual = _sut.Parse(tokens);

        Assert.Equivalent(expected, actual);
    }
}