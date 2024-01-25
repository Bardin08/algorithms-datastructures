using System.Collections;

namespace DataStructures;

public class LinkedQueue : IEnumerable
{
    private Node? _head;
    private Node? _tail;

    public int Count { get; private set; }

    public void Enqueue(string value)
    {
        var node = new Node
        {
            Value = value
        };

        if (_tail != null)
        {
            _tail.Next = node;
        }

        if (_head == null &&
            _tail == null)
        {
            _head = _tail = node;
        }

        _tail = node;
        Count++;
    }

    public string? Dequeue()
    {
        var head = _head;
        _head = _head?.Next;

        Count--;
        return head?.Value;
    }

    public string? Peek()
    {
        return _head?.Value;
    }

    public void Clear()
    {
        _head = _tail = null;
        Count = 0;
    }

    public IEnumerator GetEnumerator()
    {
        while (_head != null)
        {
            var head = _head;
            _head = _head.Next;

            yield return head.Value;
        }
    }
}