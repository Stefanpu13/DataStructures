using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedListLibrary
{
   public interface ILinkedList<T> where T : IComparable
    {
        int Count { get; set; }

        void AddFirst(T Value);

        void AddLast(T value);

    }
}
