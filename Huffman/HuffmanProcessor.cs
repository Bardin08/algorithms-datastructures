namespace Huffman;

public class HuffmanProcessor
{
    public BinTreeNode BuildBinaryTree(Dictionary<char, int> charsDistribution)
    {
        var treeNodes = new PriorityQueue<BinTreeNode, int>();
        foreach (var kvp in charsDistribution)
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

    private void BuildBinaryTree(PriorityQueue<BinTreeNode, int> nodes)
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

    public void TraverseTree(BinTreeNode? root, string identifier,
        IDictionary<char, string> huffmanTable)
    {
        if (root is null) return;
        if (root.Value.Length is 1)
        {
            huffmanTable[root.Value[0]] = identifier;
        }

        TraverseTree(root.Left, identifier + "0", huffmanTable);
        TraverseTree(root.Right, identifier + "1", huffmanTable);
    }
}