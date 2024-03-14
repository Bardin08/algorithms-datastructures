namespace Huffman;

public class BinTreeNode
{
    public required string Value { get; init; }
    public int Entries { get; init; }
    public BinTreeNode? Left { get; init; }
    public BinTreeNode? Right { get; init; }
}