namespace DataStructures.Tests;

public class ArrayQueueTests
{
    [Fact]
    public void Enqueue_ThreeElements_Valid()
    {
        var queue = new ArrayQueue<string>();

        queue.Enqueue("1");
        queue.Enqueue("2");
        queue.Enqueue("3");
        queue.Enqueue("3");
        queue.Enqueue("3");

        Assert.Equal(3, queue.Count);
    }

    [Fact]
    public void Dequeue_ThreeElements_Valid()
    {
        var queue = new ArrayQueue<string>();
        queue.Enqueue("1");
        queue.Enqueue("2");
        queue.Enqueue("3");

        queue.Dequeue();
        queue.Dequeue();
        queue.Dequeue();
        queue.Dequeue();
        queue.Dequeue();

        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void Peek_ThreeElements_Valid()
    {
        var queue = new ArrayQueue<string>();
        queue.Enqueue("1");
        queue.Enqueue("2");
        queue.Enqueue("3");

        Assert.Equal(3, queue.Count);

        queue.Peek();
        queue.Peek();
        queue.Peek();

        Assert.Equal(3, queue.Count);
    }
}