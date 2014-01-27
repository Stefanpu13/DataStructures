using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedListLibrary;

namespace LinkedListTest
{
    [TestClass]
    public class DoubleLinkedListTester
    {
        #region 'AddFirst' method tests
        [TestMethod]
        public void AddFirst_EmptyList_FirstAndLastShouldBeNotNullAndEqual()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>();

            Assert.IsNull(list.First);

            list.AddFirst(2);

            Assert.IsNotNull(list.First);
            Assert.AreEqual(list.First, list.Last);
        }

        [TestMethod]
        public void AddFirst_FullList_FirstReferenceIsUpdated()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.AddFirst(2);

            var node = list.First;

            list.AddFirst(1);
            var newNode = list.First;
            
            Assert.AreSame(list.First, newNode);
            Assert.AreEqual(list.First.Value, 1);
            Assert.AreNotSame(list.First, node);            
        }

        [TestMethod]
        public void AddFirst_NullValue_FirstReferenceIsNotNull()
        {
            IDoubleLinkedList<string> list = new DoubleLinkedList<string>();
            list.AddFirst("2");
            list.AddFirst(null);           

            Assert.IsNotNull(list.First);
            
        }
        #endregion

        #region 'AddLast' method tests
        [TestMethod]
        public void AddLast_EmptyList_FirstAndLastShouldBeNotNullAndEqual()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>();

            Assert.IsNull(list.Last);

            list.AddLast(2);

            Assert.IsNotNull(list.First);
            Assert.AreEqual(list.First, list.Last);
        }

        [TestMethod]
        public void AddLast_FullList_LastReferenceIsUpdated()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.AddFirst(2);

            var node = list.Last;

            list.AddLast(3);
            var newNode = list.Last;

            Assert.AreSame(list.Last, newNode);
            Assert.AreEqual(list.Last.Value, 3);
            Assert.AreNotSame(list.Last, node);
        }

        [TestMethod]
        public void AddLast_NullValue_LastReferenceIsNotNull()
        {
            IDoubleLinkedList<string> list = new DoubleLinkedList<string>();
            list.AddLast("2");
            list.AddLast(null);

            Assert.IsNotNull(list.Last);
        }

        #endregion/

        #region 'RemoveFirst' method tests
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveFirst_EmptyList_ThrowsException()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.RemoveFirst();
        }

        [TestMethod]        
        public void RemoveFirst_OneItemInList_FirstAndLastAreNull_CountIsReduced()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>(4);
            var count = list.Count;
            list.RemoveFirst();

            Assert.IsNull(list.First);
            Assert.AreSame(list.First, list.Last);
            Assert.AreEqual(list.Count, count - 1);
        }

        [TestMethod]
        public void RemoveFirst_ManyItemsInList_FirstIsUpdated_CountIsReduced()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>(4);
            list.AddFirst(6);
            var newFirst = list.First;
            var count = list.Count;

            var removed = list.RemoveFirst();
            
            Assert.AreSame(newFirst, removed);
            Assert.AreNotSame(newFirst, list.First);            
            Assert.AreEqual(list.Count, count - 1);
            Assert.IsNull(removed.Next);
        }


        #endregion

        #region 'RemoveLast' method tests
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveLast_EmptyList_ThrowsException()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.RemoveLast();
        }

        [TestMethod]
        public void RemoveLast_OneItemInList_FirstAndLastAreNull_CountIsReduced()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>(4);
            var count = list.Count;

            list.RemoveLast();
            

            Assert.IsNull(list.Last);
            Assert.AreSame(list.First, list.Last);
            Assert.AreEqual(list.Count, count - 1);
        }

        [TestMethod]
        public void RemoveLast_ManyItemsInList_LastIsUpdated_CountIsReduced()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>(4);
            list.AddFirst(6);
            var newLast = list.Last;
            var count = list.Count;
            var removed = list.RemoveLast();

            Assert.AreSame(newLast, removed);
            Assert.AreNotSame(newLast, list.Last);
            Assert.AreEqual(list.Count , count - 1);
            Assert.IsNull(removed.Previous);
        }

        #endregion

        #region'RemoveBefore' tests

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveBefore_EmptyList_ThrowsException()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>();

            list.RemoveBefore(list.First);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveBefore_NodeNotInList_ThrowsException()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>(3);

            list.RemoveBefore(new DoubleLinkedListNode<int>(3));
        }

        [TestMethod]        
        public void RemoveBefore_NodeIsBeforeFirstInList_ReturnsNull_CountIsNotChanged()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>(3);
            var count = list.Count;

            var removed = list.RemoveBefore(list.First);

            Assert.IsNull(removed);
            Assert.AreEqual(list.Count, count);
        }

        [TestMethod]
        public void RemoveBefore_NodeIsFirstInList_ReturnsFirst_CountIsReduced()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>(3);
            list.AddFirst(5);
            var first = list.First;
            var count = list.Count;

            var removed = list.RemoveBefore(list.Last);

            Assert.AreSame(removed, first);
            Assert.AreEqual(list.Count, count - 1);
        }
        [TestMethod]
        public void RemoveBefore_NotFirst_PreviousAndNextNodesReferencesUpdated_CountReduces()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>(3);
            list.AddFirst(2);
            list.AddFirst(1);
            var previous = list.First;
            var next = list.Last;
            var count = list.Count;

            var removed = list.RemoveBefore(list.Last);

            Assert.AreSame(previous.Next, next);
            Assert.AreSame(next.Previous, previous);
            Assert.IsNull(removed.Next);
            Assert.IsNull(removed.Previous);
            Assert.AreEqual(list.Count, count - 1);


        }


        #endregion

        #region'RemoveAfter' tests

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveAfter_EmptyList_ThrowsException()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.RemoveAfter(list.First);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveAfter_NodeNotInList_ThrowsException()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>(3);
            list.RemoveAfter(new DoubleLinkedListNode<int>(3));
        }

        [TestMethod]
        public void RemoveAfter_NodeIsAfterLastInList_ReturnsNull_CountIsNotChanged()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>(3);
            var count = list.Count;

            var removed = list.RemoveBefore(list.Last);

            Assert.IsNull(removed);
            Assert.AreEqual(list.Count, count);
        }

        [TestMethod]
        public void RemoveAfter_NodeIsLastInList_ReturnsLast_CountIsReduced()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>(3);
            list.AddLast(5);
            var last = list.Last;
            var count = list.Count;

            var removed = list.RemoveAfter(list.Last.Previous);

            Assert.AreSame(removed, last);
            Assert.AreEqual(list.Count, count - 1);
        }

        [TestMethod]
        public void RemoveAfter_NotLast_PreviousAndNextNodesReferencesUpdated_CountReduces()
        {
            IDoubleLinkedList<int> list = new DoubleLinkedList<int>(3);
            list.AddFirst(2);
            list.AddFirst(1);
            var previous = list.First;
            var next = list.Last;
            var count = list.Count;

            var removed = list.RemoveAfter(list.First);

            Assert.AreSame(previous.Next, next);
            Assert.AreSame(next.Previous, previous);
            Assert.IsNull(removed.Next);
            Assert.IsNull(removed.Previous);
            Assert.AreEqual(list.Count, count - 1);
        }

        #endregion
    }
}
