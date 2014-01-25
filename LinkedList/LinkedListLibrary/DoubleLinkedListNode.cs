using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedListLibrary
{
    public class DoubleLinkedListNode<T> : IDoubleLinkedListNode<T> where T : IComparable
    {

        public T Value { get; set; }

        public IDoubleLinkedListNode<T> Next { get; set; }

        public IDoubleLinkedListNode<T> Previous { get; set; }

        public DoubleLinkedListNode(T value)
        {
            this.Value = value;
        }
    }
}
