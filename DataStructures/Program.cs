using DataStructures;

var queue = new ArrayQueue<string>();

queue.Enqueue("1");
queue.Enqueue("2");
queue.Enqueue("3");

Console.WriteLine("Count before peek: " + queue.Count);

Console.WriteLine(queue.Peek());
Console.WriteLine(queue.Peek());

Console.WriteLine("Count before dequeue: " + queue.Count);

Console.WriteLine(queue.Dequeue());
Console.WriteLine(queue.Dequeue());
Console.WriteLine(queue.Dequeue());

Console.WriteLine("Count after dequeue: " + queue.Count);
