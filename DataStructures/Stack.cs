namespace DataStructures;

public class Stack<T>(int defaultCapacity)
{
    private T[] _array = new T[defaultCapacity];
    public int Count { get; private set; }

    public void Push(T value)
    {
        ArgumentNullException.ThrowIfNull(value);

        Array.Resize(ref _array, _array.Length * 2);
        _array[Count] = value;
        Count++;
    }

    public T? Pop()
    {
        Count--;
        return _array[Count];
    }

    public T? Peek() => _array[Count - 1];
}