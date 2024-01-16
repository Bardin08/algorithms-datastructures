namespace ShuntingYard;

internal static class Helpers
{
    public static readonly Dictionary<char, int> Priority = new()
    {
        { '+', 1 },
        { '-', 1 },
        { '*', 2 },
        { '/', 2 },
        { '^', 3 },
        { '(', 0 }
    };

    private static readonly HashSet<char> Operators =
    [
        '+',
        '-',
        '*',
        '/',
        '^',
    ];

    public static bool IsOperator(this char @char) => Operators.Contains(@char);
    public static bool IsOperator(this string token) => token.Length is 1 && Operators.Contains(token[0]);

    public static bool IsNumber(this string input) => double.TryParse(input, out _);
}