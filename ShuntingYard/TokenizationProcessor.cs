using System.Text;

namespace ShuntingYard;

public class TokenizationProcessor
{
    public List<string> Tokenize(string input)
    {
        var tokens = new List<string>();

        var decimalSeparatorSeen = false;
        var token = new StringBuilder();
        for (var index = 0; index < input.Length; index++)
        {
            var ch = input[index];

            var prevToken = tokens.LastOrDefault();
            var isNegationSignAllowed = prevToken != null &&
                                        token.Length is 0 &&
                                        (prevToken.IsOperator() || prevToken is "(");

            var isNumberNegation = ch is '-' && (index is 0 || isNegationSignAllowed);
            if (char.IsDigit(ch) || isNumberNegation)
            {
                token.Append(ch);
            }
            else if (ch is '.' or ',')
            {
                if (decimalSeparatorSeen)
                {
                    throw new Exception($"Invalid expression. Error at {index}");
                }

                token.Append(ch);
                decimalSeparatorSeen = true;
            }
            else if (ch.IsOperator())
            {
                if (token.Length > 0)
                {
                    tokens.Add(token.ToString());
                    token.Clear();
                    decimalSeparatorSeen = false;
                }

                tokens.Add(ch.ToString());
            }
            else if (ch is '(' or ')')
            {
                if (token.Length > 0)
                {
                    tokens.Add(token.ToString());
                    token.Clear();
                    decimalSeparatorSeen = false;
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