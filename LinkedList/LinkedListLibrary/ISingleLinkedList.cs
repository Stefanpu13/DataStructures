using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListLibrary
{
    public interface ISingleLinkedList<T> :ILinkedList<T> where T : IComparable
    {
    }
}
