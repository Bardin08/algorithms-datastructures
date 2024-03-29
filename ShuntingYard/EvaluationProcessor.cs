﻿namespace ShuntingYard;

public class EvaluationProcessor
{
    public double Evaluate(List<string> rpnTokens)
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
                var num2 = stack.Pop();
                var num1 = stack.Pop();

                var localResult = token switch
                {
                    "+" => num1 + num2,
                    "-" => num1 - num2,
                    "*" => num1 * num2,
                    "/" => num1 / num2,
                    "^" => Math.Pow(num1, num2),
                    _ => throw new ArgumentOutOfRangeException()
                };
                stack.Push(localResult);
            }
            else if (token.IsFunction())
            {
                var num = stack.Pop();

                var localResult = token switch
                {
                    "sin" => Math.Sin(num),
                    "cos" => Math.Cos(num),
                    _ => throw new ArgumentOutOfRangeException()
                };

                stack.Push(localResult);
            }
        }

        return stack.Pop();
    }
}