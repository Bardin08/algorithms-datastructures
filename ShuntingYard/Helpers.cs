namespace ShuntingYard;

internal static class Helpers
{
    public static readonly Dictionary<char, int> Priority = new()
    {
        { '+', 1 },
        { '-', 1 },
        { '*', 2 },
        { '/', 2 },
    };

    public static bool IsOperator(this char @char) => Priority.ContainsKey(@char);
    public static bool IsOperator(this string token) => token.Length is 1 && Priority.ContainsKey(token[0]);

    public static bool IsNumber(this string input) => double.TryParse(input, out _);
}