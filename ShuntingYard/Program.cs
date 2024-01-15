using System.Text;

Console.WriteLine("Shunting Yard Demo");

const string inputString = "3+4+22-111*12-11/23+10";
Console.WriteLine(inputString);

var allTokens = Tokenize(inputString);
Console.WriteLine(string.Join(" ", allTokens));

var rpnInput = ShuntingYard(allTokens);
Console.WriteLine(string.Join(" ", rpnInput));

var result = Calculate(rpnInput);
Console.WriteLine(result);

return;

List<string> Tokenize(string input)
{
    var tokens = new List<string>();

    var token = new StringBuilder();
    foreach (var ch in input)
    {
        if (char.IsDigit(ch))
        {
            token.Append(ch);
        }
        else if (ch.IsOperator())
        {
            if (token.Length > 0)
            {
                tokens.Add(token.ToString());
                token.Clear();
            }

            tokens.Add(ch.ToString());
        }
    }

    if (token.Length > 0)
    {
        tokens.Add(token.ToString());
    }

    return tokens;
}

List<string> ShuntingYard(List<string> tokens)
{
    var operators = new Stack<char>();
    var queue = new Queue<string>();

    foreach (var token in tokens)
    {
        if (token.IsNumber())
        {
            queue.Enqueue(token);
        }
        else if (token.IsOperator())
        {
            while (operators.Count > 0 &&
                   Helpers.Priority[operators.Peek()] >= Helpers.Priority[token[0]])
            {
                queue.Enqueue(operators.Pop().ToString());
            }

            operators.Push(token[0]);
        }
    }

    if (operators.Count > 0)
    {
        queue.Enqueue(operators.Pop().ToString());
    }

    return queue.ToList();
}

double Calculate(List<string> rpnTokens)
{
    var stack = new Stack<double>();

    foreach (var token in rpnTokens)
    {
        if (token.IsNumber())
        {
            stack.Push(double.Parse(token));
        }
        else if (token.IsOperator())
        {
            Console.WriteLine(string.Join(" ", stack));

            var num2 = stack.Pop();
            var num1 = stack.Pop();

            var localResult = token switch
            {
                "+" => num1 + num2,
                "-" => num1 - num2,
                "*" => num1 * num2,
                "/" => num1 / num2,
                _ => throw new ArgumentOutOfRangeException()
            };
            stack.Push(localResult);

            switch (token)
            {
                case "+":
                    Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
                    break;
                case "-":
                    Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
                    break;
                case "*":
                    Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
                    break;
                case "/":
                    Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
                    break;
            }
            
            Console.WriteLine(string.Join(" ", stack));
            Console.WriteLine();
        }
    }

    return stack.Pop();
}


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