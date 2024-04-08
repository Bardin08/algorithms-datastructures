using System.Text;
using Bardin08.ProgressBar;

namespace Huffman;

internal interface IEncoder
{
    MemoryStream EncodeFile(string filePath, Dictionary<char, string> huffmanMap);
    MemoryStream DecodeFile(string filePath, Dictionary<char, string> huffmanMap);
}

public class HuffmanEncoder : IEncoder
{
    public MemoryStream EncodeFile(string filePath, Dictionary<char, string> huffmanMap)
    {
        if (!File.Exists(filePath))
        {
            Logger.LogError($"File path {Path.GetFileName(filePath)} not exists");
            return (MemoryStream)Stream.Null;
        }

        using var fileStream = File.OpenRead(filePath);

        var resultStream = fileStream.WriteStreamToFileWithTransformation(
            huffmanMap, MapCharWithHuffmanCode);

        resultStream.Flush();
        resultStream.BaseStream.Seek(0, SeekOrigin.Begin);
        return (resultStream.BaseStream as MemoryStream)!;
    }

    private static void MapCharWithHuffmanCode(
        TextWriter resultStream,
        byte[] buffer,
        int bytesRead,
        Dictionary<char, string> huffmanMap)
    {
        foreach (var ch in buffer[..bytesRead])
        {
            resultStream.Write(huffmanMap[(char)ch]);
        }
    }

    public MemoryStream DecodeFile(string filePath, Dictionary<char, string> huffmanMap)
    {
        if (!File.Exists(filePath))
        {
            Logger.LogError($"File path {Path.GetFileName(filePath)} not exists");
            return (MemoryStream)Stream.Null;
        }

        using var fileStream = new FileStream(filePath, FileMode.Open);
        using var streamReader = new StreamReader(fileStream);

        return DecodeFileInternal(streamReader, huffmanMap);
    }

    private MemoryStream DecodeFileInternal(
        StreamReader streamReader,
        Dictionary<char, string> huffmanMap)
    {
        var progressBar = new ProgressBar(streamReader.BaseStream.Length, new ProgressBarOptions());
        var streamWriter = new StreamWriter(new MemoryStream());

        var invertedHuffmanMap = huffmanMap.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

        var buffer = new char[1024 * 1024 * 4];
        var sb = new StringBuilder(16);
        while (!streamReader.EndOfStream)
        {
            var charsRead = streamReader.ReadBlock(buffer, 0, buffer.Length);

            for (var i = 0; i < charsRead; i++)
            {
                sb.Append(buffer[i]);
                if (invertedHuffmanMap.TryGetValue(sb.ToString(), out var value))
                {
                    streamWriter.Write(value);
                    sb.Clear();
                }
            }

            progressBar.Update(charsRead);
        }

        progressBar.Finish();
        streamWriter.Flush();
        streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
        return (MemoryStream)streamWriter.BaseStream;
    }
}