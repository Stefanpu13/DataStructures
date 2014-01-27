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
            this.Count = 1;
        }

        public void AddFirst(T value) 
        {
            if (value != null)
            {
                var newNode = new DoubleLinkedListNode<T>(value);

                if (this.Count == 0)
                {
                    this.First = this.Last = newNode;
                }                                    
                else
                {
                    AddFirstNode(newNode);                    
                }
                this.Count++;
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

                this.Count++;
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
                if (this.Count == 0)
                {
                    this.First = this.Last = newNode;
                }
                else
                {
                    AddLastNode(newNode);                    
                }
                this.Count++;
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

                this.Count++;
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

        public IDoubleLinkedListNode<T> RemoveBefore(IDoubleLinkedListNode<T> node)
        {
            IDoubleLinkedListNode<T> removed = null;
            node = this.Find(node);

            if (node == null)
            {
                throw new InvalidOperationException(
                    "Node not found in list");
            }
            if (node != this.First)
            {
                if (node.Previous == this.First)
                {
                    removed = RemoveFirst();
                }
                else
                {
                    removed = node.Previous;
                    node.Previous = node.Previous.Previous;
                    node.Previous.Next = node;

                    // Removed node might be added to other list
                    removed.Next = null;
                    removed.Previous = null;

                    this.Count--;
                }
            }

            return removed;
        }

        public IDoubleLinkedListNode<T> RemoveAfter(IDoubleLinkedListNode<T> node)
        {
            IDoubleLinkedListNode<T> removed = null;
            node = this.Find(node);

            if (node == null)
            {
                throw new InvalidOperationException(
                    "Node not found in list");
            }
            if (node != this.Last)
            {
                if (node.Next == this.Last)
                {
                   removed = this.RemoveLast();
                }
                else
                {
                    removed = node.Next;
                    node.Next = node.Next.Next;
                    node.Next.Previous = node;
                    removed.Previous = null;
                    removed.Next = null;

                    this.Count--;
                }
            }

            return removed;
        }

        public IDoubleLinkedListNode<T> RemoveFirst()
        {
            IDoubleLinkedListNode<T> removedNode = this.First;

            if (this.Count < 2)
            {
                this.HandleSmallCountRemoval();
            }
            else
            {
                this.First = this.First.Next;
                this.First.Previous = null;
            }            
            this.Count--;

            return removedNode;
        }

        public IDoubleLinkedListNode<T> RemoveLast()
        {
            IDoubleLinkedListNode<T> removedNode = this.Last;

            if (this.Count < 2)
            {
                this.HandleSmallCountRemoval();
            }
            else
            {
                this.Last = this.First.Previous;
                this.First.Next = null;
            }
            
            this.Count--;
            return removedNode;
        }

        private void HandleSmallCountRemoval()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Can not remove from empty list.");
            }
            
            this.First = this.Last = null;
        }
    }
}
