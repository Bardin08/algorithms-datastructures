using System.Diagnostics;
using System.Text;

namespace Huffman;

internal static class Program
{
    public static void Main()
    {
        const string filePath = "./Resources/sherlock (1).txt";
        const string encodedFilePath = "./Resources/encoded.txt";

        Executor.ExecuteWithStopwatch(
            FullFlow, "Assignment 4, the Full Flow!",
            throwException: false, args: [filePath, encodedFilePath]);
    }

    private static void FullFlow(string filePath, string encodedFilePath)
    {
        var charsDistribution = Executor.ExecuteWithStopwatch(
            action: GetCharsDistribution,
            operationName: nameof(GetCharsDistribution),
            throwException:false,
            args: filePath)!;

        var huffmanTable = Executor.ExecuteWithStopwatch(
            action: GetHuffmanTable,
            operationName: nameof(GetHuffmanTable),
            throwException:false,
            args: [charsDistribution, false])!;

        var encodedContent = Executor.ExecuteWithStopwatch(
            action: EncodeFile,
            operationName: nameof(EncodeFile),
            throwException:false,
            args: [filePath, huffmanTable])!;

        Executor.ExecuteWithStopwatch(
            action: StreamExtensions.WriteStreamToFile,
            operationName: nameof(StreamExtensions.WriteStreamToFile),
            throwException:false,
            args: [encodedContent, encodedFilePath]);
    }


    private static Dictionary<char, int> GetCharsDistribution(string s)
    {
        var fileReader = new HuffmanFileReader();
        var dictionary = fileReader.GetCharactersDistribution(s);
        return dictionary;
    }

    private static Dictionary<char, string> GetHuffmanTable(Dictionary<char, int> ints, bool printTable)
    {
        var huffmanProcessor = new HuffmanProcessor();
        var treeRoot = huffmanProcessor.BuildBinaryTree(ints);

        var table = new Dictionary<char, string>();
        huffmanProcessor.TraverseTree(treeRoot, string.Empty, table);

        if (printTable)
        {
            Logger.LogHuffmanTable(table);
        }

        return table;
    }

    private static MemoryStream EncodeFile(string filePath1, Dictionary<char, string> huffmanTable1) =>
        new HuffmanEncoder().EncodeFile(filePath1, huffmanTable1);
}




// using var decodedStream = new HuffmanEncoder().DecodeFile(encodedFilePath, huffmanTable);

// var totalRead = 0;
// var buffer = new byte[1024 * 4];
// while (totalRead < decodedStream.Length)
// {
// var readBytes = decodedStream.Read(buffer, 0, buffer.Length);
// totalRead += readBytes;

// Console.Write(Encoding.UTF8.GetString(buffer[..readBytes]));
// }

// Console.ReadLine();