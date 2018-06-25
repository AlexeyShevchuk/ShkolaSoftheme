using System;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Queue");
            var queue = new Queue<int>();

            queue.Enqueue(15);
            queue.Enqueue(25);
            queue.Enqueue(35);
            queue.Enqueue(12);
            queue.Enqueue(64);
            queue.Enqueue(12);

            Console.WriteLine(queue);
            Console.WriteLine("Dequeue {0}", queue.Dequeue());
            Console.WriteLine("Peek {0}", queue.Peek());
            Console.WriteLine(queue);

            Console.WriteLine("Stack");
            var stack = new Stack<int>();

            stack.Push(15);
            stack.Push(25);
            stack.Push(35);
            stack.Push(12);
            stack.Push(64);
            stack.Push(12);

            Console.WriteLine(stack);
            Console.WriteLine("Pop {0}", stack.Pop());
            Console.WriteLine("Peek {0}", stack.Peek());
            Console.WriteLine(stack);

            Console.WriteLine("Dictionary");
            var dictionary = new Dictionary<int, int>();

            dictionary.Add(1, 15);
            dictionary.Add(2, 25);
            dictionary.Add(3, 35);
            dictionary.Add(4, 12);
            dictionary.Add(5, 64);
            dictionary.Add(6, 12);

            Console.WriteLine(dictionary);
            dictionary.Remove(3, 35);
            dictionary.Remove(6, 12);
            Console.WriteLine(dictionary);

            Console.ReadLine();
        }
    }
}
