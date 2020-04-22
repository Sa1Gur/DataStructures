using DataStructures;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var heap = new Heap<int>((x, y) => x < y);

            heap.Push(0);
            Console.WriteLine(heap.Peek());
            heap.Push(-3);
            Console.WriteLine(heap.Peek());
            heap.Push(20);
            Console.WriteLine(heap.Peek());
            heap.Push(330);
            Console.WriteLine(heap.Peek());
            heap.Push(10);
            Console.WriteLine(heap.Peek());
            heap.Push(1110);
            Console.WriteLine(heap.Peek());

        }
    }
}
