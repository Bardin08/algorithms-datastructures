using System.Text;

namespace Huffman;

public class HuffmanFileReader
{
    public Dictionary<char, int> GetCharactersDistribution(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Logger.LogError($"File path {Path.GetFileName(filePath)} not exists");
            return new Dictionary<char, int>();
        }

        return GetCharactersDistributionInternal(filePath);
    }

    private Dictionary<char, int> GetCharactersDistributionInternal(string filePath)
    {
        using var fileStream = new FileStream(filePath, FileMode.Open);
        using var streamReader = new StreamReader(fileStream);

        var charsDistribution = new Dictionary<char, int>();

        var buffer = new char[1024 * 4];
        while (!streamReader.EndOfStream)
        {
            var charsRead = streamReader.ReadBlock(buffer, 0, buffer.Length);
            
            foreach (var ch in buffer[..charsRead])
            {
                if (!charsDistribution.TryAdd(ch, 1))
                    charsDistribution[ch]++;
            }
        }

        return charsDistribution;
    }
}