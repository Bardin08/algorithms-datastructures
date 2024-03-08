using System.Text;

const string filePath = "./Resources/sherlock.txt";
var charsDistribution = GetCharsDistribution(filePath);
var treeRoot = GetBinaryTreeRoot(charsDistribution);

var huffmanMapping = new Dictionary<string, string>();
TraverseTree(treeRoot, string.Empty, huffmanMapping);
PrintHuffmanTable(huffmanMapping);

var text = EncodeText(filePath, huffmanMapping);
Console.WriteLine(string.Join("", text.Take(100)));

string EncodeText(string srcFilePath, Dictionary<string, string> huffmanMap)
{
    var sb = new StringBuilder();
    var allText = File.ReadAllText(srcFilePath);
    foreach (var c in allText)
    {
        sb.Append(huffmanMap[c.ToString()]);
    }

    return sb.ToString();
}

return;


Dictionary<char, int> GetCharsDistribution(string srcFilePath)
{
    var fileText = File.ReadAllText(srcFilePath);

    var ints = new Dictionary<char, int>();
    foreach (var c in fileText)
    {
        if (!ints.TryAdd(c, 1))
            ints[c]++;
    }

    return ints;
}

BinTreeNode GetBinaryTreeRoot(Dictionary<char, int> distribution)
{
    var treeNodes = new PriorityQueue<BinTreeNode, int>();
    foreach (var kvp in distribution)
    {
        var node = new BinTreeNode
        {
            Value = kvp.Key.ToString(),
            Entries = kvp.Value
        };
        treeNodes.Enqueue(node, node.Entries);
    }

    BuildBinaryTree(treeNodes);

    var binTreeNode = treeNodes.Dequeue();
    return binTreeNode;
}

void BuildBinaryTree(PriorityQueue<BinTreeNode, int> nodes)
{
    while (nodes.Count > 1)
    {
        var node1 = nodes.Dequeue();
        var node2 = nodes.Dequeue();

        var node = new BinTreeNode
        {
            Value = node1.Value + node2.Value,
            Entries = node1.Entries + node2.Entries,
            Left = node1,
            Right = node2
        };
        nodes.Enqueue(node, node.Entries);
    }
}

void TraverseTree(
    BinTreeNode? root,
    string identifier,
    IDictionary<string, string> huffmanTable)
{
    if (root is not null)
    {
        if (root.Value.Length is 1)
        {
            huffmanTable[root.Value] = identifier;
        }

        TraverseTree(root.Left, identifier + "0", huffmanTable);
        TraverseTree(root.Right, identifier + "1", huffmanTable);
    }
}

void PrintHuffmanTable(Dictionary<string, string> dictionary)
{
    Console.WriteLine("Symbol\tHuffman Code");
    Console.WriteLine("--------------------");
    foreach (var item in dictionary)
    {
        Console.WriteLine($"{item.Key}\t{item.Value}");
    }
}

internal class BinTreeNode
{
    public required string Value { get; set; }
    public string Identifier { get; set; } = null!;
    public int Entries { get; set; }
    public BinTreeNode? Left { get; set; }
    public BinTreeNode? Right { get; set; }
}