using System.Text;

namespace ShuntingYard;

public class TokenizationProcessor
{
    public List<string> Tokenize(string input)
    {
        var tokens = new List<string>();

        var token = new StringBuilder();
        for (var index = 0; index < input.Length; index++)
        {
            var ch = input[index];

            var isNumberNegation = ch is '-' && (index is 0 || tokens.Last().IsOperator());
            if (char.IsDigit(ch) || isNumberNegation)
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