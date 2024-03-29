﻿namespace DataStructures.Tests;

public class LinkedQueueTests
{
    [Fact]
    public void Enqueue_ThreeElements_Valid()
    {
        var queue = new LinkedQueue();

        queue.Enqueue("1");
        queue.Enqueue("2");
        queue.Enqueue("3");

        Assert.Equal(3, queue.Count);
    }

    [Fact]
    public void Dequeue_ThreeElements_Valid()
    {
        var queue = new LinkedQueue();
        queue.Enqueue("1");
        queue.Enqueue("2");
        queue.Enqueue("3");

        queue.Dequeue();
        queue.Dequeue();
        queue.Dequeue();

        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void Peek_ThreeElements_Valid()
    {
        var queue = new LinkedQueue();
        queue.Enqueue("1");
        queue.Enqueue("2");
        queue.Enqueue("3");

        Assert.Equal(3, queue.Count);

        queue.Peek();
        queue.Peek();
        queue.Peek();

        Assert.Equal(3, queue.Count);
    }

    [Fact]
    public void Clear_ThreeElements_Valid()
    {
        var queue = new LinkedQueue();
        queue.Enqueue("1");
        queue.Enqueue("2");
        queue.Enqueue("3");

        queue.Clear();
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void GetEnumerator_ThreeElements_Valid()
    {
        var queue = new LinkedQueue();
        queue.Enqueue("1");
        queue.Enqueue("2");
        queue.Enqueue("3");

        var current = 1;

        // ReSharper disable once NotDisposedResource
        var enumerator = queue.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Assert.Equal(current.ToString(), enumerator.Current);
            current++;
        }
    }
}