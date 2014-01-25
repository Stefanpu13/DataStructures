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
    }

}
