namespace ShuntingYard;

public class ShuntingYardProcessor
{
    public List<string> Parse(List<string> tokens)
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
                    var op = operators.Pop();
                    if (op is '(')
                    {
                        continue;
                    }

                    queue.Enqueue(op.ToString());
                }

                operators.Push(token[0]);
            }
            else if (token is "(")
            {
                operators.Push(token[0]);
            }
            else if (token is ")" && operators.Count > 0)
            {
                while (operators.TryPop(out var op))
                {
                    if (op is '(')
                    {
                        continue;
                    }

                    queue.Enqueue(op.ToString());
                }
            }
        }

        if (operators.Count > 0)
        {
            while (operators.TryPop(out var op))
            {
                if (op is '(')
                {
                    continue;
                }

                queue.Enqueue(op.ToString());
            }
        }

        return queue.ToList();
    }
}