using System.Text;

namespace ShuntingYard;

internal class TokenizationProcessor
{
    public List<string> Tokenize(string input)
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
}