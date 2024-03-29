﻿namespace DataStructures;

public class ArrayQueue<T>(int capacity = 4)
{
    private T[] _queue = new T[capacity];
    private int _head;
    private int _tail = -1;

    public int Count { get; private set; }

    public void Enqueue(T item)
    {
        EnsureCapacity();

        _tail = (_tail + 1) % capacity;
        _queue[_tail] = item;
        Count++;
    }

    private void EnsureCapacity()
    {
        if (Count != capacity)
        {
            return;
        }

        capacity = _queue.Length * 2;
        var arr = new T[_queue.Length * 2]; 
        Array.Copy(_queue, arr, _queue.Length);

        _queue = arr;
    }

    public T? Dequeue()
    {
        if (IsEmpty())
        {
            return default;
        }

        var item = _queue[_head];
        _head = (_head + 1) % capacity;
        Count--;
        return item;
    }

    public T? Peek()
    {
        return IsEmpty() ? default : _queue[_head];
    }

    private bool IsEmpty() => Count == 0;
}
