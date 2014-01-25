using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListLibrary
{
    public interface ILinkedListNode<T> where T: IComparable
    {
        T Value { get; set; }
    }
}
