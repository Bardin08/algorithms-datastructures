namespace ShuntingYard;

internal static class Helpers
{
    public static readonly Dictionary<string, int> Priority = new()
    {
        { "+", 1 },
        { "-", 1 },
        { "*", 2 },
        { "/", 2 },
        { "^", 3 },
        { "(", 0 },
        { "sin", 3 },
        { "cos", 3 },
    };

    private static readonly HashSet<char> Operators =
    [
        '+',
        '-',
        '*',
        '/',
        '^',
    ];

    private static readonly HashSet<string> Functions =
    [
        "sin", "cos"
    ];

    public static bool IsOperator(this char @char) => Operators.Contains(@char);
    public static bool IsOperator(this string token) => token.Length is 1 &&
                                                        Operators.Contains(token[0]);

    public static bool IsFunction(this string token) => Functions.Contains(token);

    public static bool IsNumber(this string input) => double.TryParse(input, out _);
}