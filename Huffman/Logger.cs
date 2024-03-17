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

    public static void PrintTree(BinTreeNode node, string indent, bool last = false)
    {
        Console.Write(indent);
        if (last)
        {
            Console.Write("└─");
            indent += "  ";
        }
        else
        {
            Console.Write("├─");
            indent += "| ";
        }

        Console.WriteLine(node.Value
            .Replace("\n", "\\n")
            .Replace("\r", "\\r")
            .Replace("\t", "\\t")
        );

        var children = new[] { node.Left, node.Right }.Where(n => n != null).ToList();
        for (var i = 0; i < children.Count; i++)
        {
            PrintTree(children[i]!, indent, i == children.Count - 1);
        }
    }
}