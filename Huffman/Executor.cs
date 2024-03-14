using System.Diagnostics;
using System.Text;

namespace Huffman;

public static class Executor
{
    private const int MaxExceptionMessageLength = 100;
    private static int _currentRunnerLevel = -1;

    public static dynamic? ExecuteWithStopwatch(
        Delegate action,
        string operationName,
        bool throwException = false,
        params object[] args)
    {
        Interlocked.Add(ref _currentRunnerLevel, 1);
        var prefix = new string('\t', _currentRunnerLevel);

        var opId = Guid.NewGuid().ToString("N")[..6];
        var stopwatch = new Stopwatch();

        Logger.LogInfo($"{prefix}Operation '{operationName}' started. Operation ID is: {opId}");

        dynamic? result = null;
        stopwatch.Start();
        try
        {
            try
            {
                if (action.Method.ReturnType == typeof(void))
                {
                    action.DynamicInvoke(args);
                }
                else
                {
                    result = action.DynamicInvoke(args) ?? null;
                }

                stopwatch.Stop();
                var message = new StringBuilder()
                    .Append(prefix).AppendLine($"{operationName} complete!")
                    .Append(prefix).Append("Elapsed time: ").AppendLine(
                        TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds).ToString("c"));

                Logger.LogInfo(message.ToString());

                Interlocked.Add(ref _currentRunnerLevel, -1);
            }
            catch (Exception e)
            {
                throw new AggregateException(e);
            }
        }
        catch (AggregateException ex)
        {
            stopwatch.Stop();
            var message = new StringBuilder()
                .Append(prefix).AppendLine($"One or more errors occurred while running the {operationName}")
                .Append(prefix).Append("Elapsed time: ").AppendLine(
                    TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds).ToString("c"))
                .Append(prefix).AppendLine("Errors:");

            foreach (var e in ex.InnerExceptions)
            {
                message.Append(prefix).Append("\t ")
                    .Append(e.Message.Length > MaxExceptionMessageLength
                        ? e.Message[..MaxExceptionMessageLength]
                        : e.Message).AppendLine("...");
            }

            Logger.LogError(prefix + message);

            Interlocked.Add(ref _currentRunnerLevel, -1);

            if (throwException)
            {
                throw;
            }
        }

        return result;
    }
}