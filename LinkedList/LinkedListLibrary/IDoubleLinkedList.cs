using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListLibrary
{
    public interface IDoubleLinkedList<T>: ILinkedList<T> where T: IComparable 
    {
        IDoubleLinkedListNode<T> First { get; set; }

        IDoubleLinkedListNode<T> Last { get; set; }


        void AddBefore(IDoubleLinkedListNode<T> node, IDoubleLinkedListNode<T> newNode);

        void AddAfter(IDoubleLinkedListNode<T> node, IDoubleLinkedListNode<T> newNode);

        IDoubleLinkedListNode<T> Find(IDoubleLinkedListNode<T> node);
    }
}
