using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListLibrary
{
    public interface IDoubleLinkedListNode<T> : ILinkedListNode<T> where T : IComparable
    {
        IDoubleLinkedListNode<T> Previous { get; set; }

        IDoubleLinkedListNode<T> Next { get; set; }
    }
}
