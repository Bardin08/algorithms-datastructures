namespace ShuntingYard;

public class ShuntingYardProcessor
{
    public List<string> Parse(List<string> tokens)
    {
        var operators = new Stack<string>();
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
                       Helpers.Priority[operators.Peek()] >= Helpers.Priority[token])
                {
                    var op = operators.Pop();
                    if (op is "(")
                    {
                        continue;
                    }

                    queue.Enqueue(op);
                }

                operators.Push(token);
            }
            else if (token is "(")
            {
                operators.Push(token);
            }
            else if (token is ")" && operators.Count > 0)
            {
                while (operators.TryPop(out var op))
                {
                    if (op is "(")
                    {
                        continue;
                    }

                    queue.Enqueue(op);
                }
            }
        }

        if (operators.Count > 0)
        {
            while (operators.TryPop(out var op))
            {
                if (op is "(")
                {
                    continue;
                }

                queue.Enqueue(op);
            }
        } 

        return queue.ToList();
    }
}