using LinkedListLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IDoubleLinkedList<int> l = new DoubleLinkedList<int>();

            l.AddFirst(3);
            Console.WriteLine("Expected 3 -> " + l.First.Value);
            Console.WriteLine("Expected 3 -> " + l.Last.Value);

            l.AddFirst(2);

            Console.WriteLine("Expected 2 -> " + l.First.Value);
            Console.WriteLine("Expected 3 -> " + l.Last.Value);

            l.AddLast(4);
            Console.Write("Expected 2 3 4 -> " );
            Print(l);           

            l.AddBefore(l.First, new DoubleLinkedListNode<int>(1));
            Console.Write("Expected 1 2 3 4 -> ");
            Print(l);
            Console.WriteLine("Expected 1 -> " + l.First.Value);

            l.AddBefore(l.Last, new DoubleLinkedListNode<int>(0));
            Console.Write("Expected 1 2 3 0 4 -> ");
            Print(l);

            l.AddAfter(l.Last, new DoubleLinkedListNode<int>(6));
            Console.Write("Expected 1 2 3 0 4 6 -> ");
            Print(l);
            Console.WriteLine("Expected 6 -> " + l.Last.Value);

            l.AddAfter(l.Last.Previous, new DoubleLinkedListNode<int>(5));
            Console.Write("Expected 1 2 3 0 4 5 6 -> ");
            Print(l);

        }

        private static void Print(IDoubleLinkedList<int> l)
        {
            var current = l.First;
            StringBuilder list = new StringBuilder();

            while (current != null)
            {
                list.Append(current.Value.ToString() + " ");
                current = current.Next;
            }

            Console.WriteLine(list.ToString());
        }
    }
}
