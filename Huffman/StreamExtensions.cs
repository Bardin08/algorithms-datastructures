namespace Huffman;

public static class StreamExtensions
{
    private const int Kb = 1024;
    private const int Mb = 1024 * Kb;
    private const int DefaultBufferSize = 4 * Mb;

    public static void WriteStreamToFile(this Stream stream, string filePath)
    {
        EnsureCanPerform(filePath);

        var fileWriter = File.OpenWrite(filePath);

        var totalProcessed = 0;
        var buffer = new byte[DefaultBufferSize].AsSpan();
        while (totalProcessed < stream.Length)
        {
            var readBytes = stream.Read(buffer);
            totalProcessed += readBytes;

            fileWriter.Write(buffer[..readBytes]);
        }

        fileWriter.Dispose();
    }

    private static void EnsureCanPerform(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            Logger.LogError("File path can't be null or empty");
            throw new ArgumentNullException(filePath);
        }

        var dirPath = Path.GetDirectoryName(filePath)!;
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}