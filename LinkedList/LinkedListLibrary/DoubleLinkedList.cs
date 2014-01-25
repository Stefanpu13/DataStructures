using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListLibrary
{
    public class DoubleLinkedList<T>: IDoubleLinkedList<T> where  T: IComparable
    {
        public int Count { get; set; }

        public IDoubleLinkedListNode<T> First { get; set; }

        public IDoubleLinkedListNode<T> Last { get; set; }

        public DoubleLinkedList()
        {
            this.First = this.Last = null;
        }

        public DoubleLinkedList(T value)
        {
            this.First = this.Last = new DoubleLinkedListNode<T>(value);
        }

        public void AddFirst(T value) 
        {

            if (value != null)
            {
                var newNode = new DoubleLinkedListNode<T>(value);

                if (this.First == null)
                {
                    this.First = this.Last = newNode;
                }                                    
                else
                {
                    AddFirstNode(newNode);
                }
            }
        }

        public void AddAfter(IDoubleLinkedListNode<T> node, IDoubleLinkedListNode<T> newNode) 
        {
            if (this.Find(newNode)!= null)
            {
                throw new InvalidOperationException("Can add node that is already in the list.");
            }

            node = this.Find(node);
            if (node == null)
            {
               throw new ArgumentNullException("Node not found in list"); 
            }
            else
            {
                if (node == this.Last)
                {
                    this.AddLastNode(newNode);
                }
                else
                {
                    AddBeforeNode(node.Next, newNode); 
                }
            }
        }

        private void AddFirstNode(IDoubleLinkedListNode<T> newNode)
        {
            this.First.Previous = newNode;
            newNode.Next = this.First;
            this.First = newNode;
        }

        public void AddLast(T value) 
        {
            if (value != null)
            {
                var newNode = new DoubleLinkedListNode<T>(value);
                if (this.First == null)
                {
                    this.First = this.Last = newNode;
                }
                else
                {
                    AddLastNode(newNode);
                }
                
            }
        }

        private void AddLastNode(IDoubleLinkedListNode<T> newNode)
        {
            this.Last.Next = newNode;
            newNode.Previous = this.Last;
            this.Last = newNode;
        }

        public void AddBefore(IDoubleLinkedListNode<T> node, IDoubleLinkedListNode<T> newNode) 
        {
            if (this.Find(newNode)!= null)
            {
                throw new InvalidOperationException("Can add node that is already in the list.");
            }

            node = this.Find(node);
            if (node == null)
            {
                throw new ArgumentNullException("Node not found in list");
            }
            else
            {
                if (node == this.First)
                {
                    AddFirstNode(newNode); 
                }
                else
                {
                    AddBeforeNode(node, newNode);                    
                }
            }
        }

        private static void AddBeforeNode(IDoubleLinkedListNode<T> node, IDoubleLinkedListNode<T> newNode)
        {
            newNode.Next = node;
            newNode.Previous = node.Previous;
            node.Previous.Next = newNode;
            node.Previous = newNode;
        }

        public IDoubleLinkedListNode<T> Find(IDoubleLinkedListNode<T> node) 
        {
            IDoubleLinkedListNode<T> foundNode = null;
            IDoubleLinkedListNode<T> current = this.First;

            if (node == null)
            {
                return null;
            }
            while (current != null)
            {
                if (current == node)
                {
                    foundNode = node;
                    break;
                }

                current = current.Next;
            }

            return foundNode;
        }

    }
}
