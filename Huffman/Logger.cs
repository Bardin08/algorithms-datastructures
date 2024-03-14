namespace Huffman;

public static class Logger
{
    public static void LogError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void LogInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void LogHuffmanTable(Dictionary<char, string> huffmanTable)
    {
        Console.WriteLine("Symbol\tHuffman Code");
        Console.WriteLine("--------------------");
        foreach (var item in huffmanTable)
        {
            Console.WriteLine($"{item.Key}\t{item.Value}");
        }
    }
}