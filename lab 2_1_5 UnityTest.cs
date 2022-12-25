using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary4;
using System.Collections.Generic;


namespace UnitTestProject1
{
    [TestClass]
    public class MyListUnitTest
    {
        private MyList<int> _list;
        [TestInitialize]
        public void Init()
        {
            _list = new MyList<int>();
        }

        [TestMethod]
        public void CountEqualsZeroAfterListCreation()
        {
            Assert.AreEqual(0, _list.Count);
        }
        [TestMethod]
        public void CountShouldIncreaseAfterAdding()
        {
            int n = 10;
            for (int i = 0; i < n; i++)
                _list.Add(i);
            Assert.AreEqual(n, _list.Count);
        }
        [TestMethod]
        public void CountShouldIncreaseAfterAddAfterValue()
        {
            MyList<int> list = new MyList<int>();
            List<int> list1 = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
                list1.Add(i);
            }
            int n = 3;
            MyList<int> list2 = new MyList<int>() { 1,3,5};
            MyList<int> list3 = new MyList<int>() { 1,3,4,5};
            list.AddAfterValue(n, 4);
            Assert.Equals(list2.Count, list3.Count);
            for(int i = 0; i < list2.Count; i++)
            {
                //Assert.Equals(list2., list3[i]); 
            }
        }
        [TestMethod]
        public void ItemsExistsAfterAdding()
        {
            int n = 10;
            for (int i = 0; i < n; i++)
                _list.Add(i);
            int item = 0;
            foreach (var value in _list)
            {
                Assert.AreEqual(item, value);
                item++;
            }
        }
        [TestMethod]
        public void ItemsExistsAfterCreation()
        {
            int[] ints = { 7, 0, 5, 4, 66 };
            _list = new MyList<int>(ints);
            int i = 0;
            foreach (var value in _list)
            {
                Assert.AreEqual(ints[i], value);
                i++;
            }
            Assert.AreEqual(ints.Length, _list.Count);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionAfterCreationWithNullSequences()
        {
            int[] ints = null;
            _list = new MyList<int>(ints);
        }
        [TestMethod]
        public void CountZeroAfterCreationByEmptySequences()
        {
            int[] ints = new int[0];
            _list = new MyList<int>(ints);
            Assert.AreEqual(ints.Length, _list.Count);
        }
    }
}
