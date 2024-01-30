namespace ShuntingYard.Tests;

public class ShuntingYardProcessorTests
{
    private readonly ShuntingYardProcessor _sut = new();

    [Theory]
    [InlineData("( ( 10 + 3 - 7 ) * 18 ) / 9", "10 3 + 7 - 18 * 9 /")]
    [InlineData("( ( 10 * -3 + 7 ) * 1.8 ) / 9.112", "10 -3 * 7 + 1.8 * 9.112 /")]
    [InlineData("( ( 10 * -3 + ( -7 ) ) * 1.8 ) / 9.112", "10 -3 * -7 + 1.8 * 9.112 /")]
    [InlineData("( 2 ^ 10 + ( 9 + 6 ^ 2 ) ) ^ 3", "2 10 ^ 9 + 6 2 ^ + 3 ^")]
    [InlineData("2 ^ 10 + 6 ^ 2 - 22.5 / ( 10 * 99 ) ^ 83", "2 10 ^ 6 2 ^ + 22.5 10 / 99 * 83 ^ -")]
    [InlineData("( 2 + 5 * 8 ) * ( 4 - 2 / 9 )", "2 5 8 * + 4 2 9 / - *")]
    [InlineData("cos ( sin ( 1 ) - cos ( 35 + 34 - 67 ) ) + sin ( 34 )", "1 sin 35 34 + 67 - cos - cos 34 sin +")]
    public void ExpressionValid_Successful(string input, string expectedTokens)
    {
        var tokens = input.Split(' ').ToList();
        var expected = expectedTokens.Split(' ');

        var actual = _sut.Parse(tokens);

        Assert.Equivalent(expected, actual);
    }
}