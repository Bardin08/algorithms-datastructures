namespace DataStructures.Tests;

public class StackTests
{
    [Fact]
    public void Count_FiveElements_Valid()
    {
        var stack = new Stack<int>(defaultCapacity: 2);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);

        Assert.Equal(5, stack.Count);
    }

    [Fact]
    public void Push_FiveElements_Valid()
    {
        var stack = new Stack<int>(defaultCapacity: 2);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);

        Assert.Equal(5, stack.Pop());
        Assert.Equal(4, stack.Pop());

        Assert.Equal(3, stack.Peek());
    }
}