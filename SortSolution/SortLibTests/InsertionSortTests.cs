using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLib.Tests
{
    [TestClass()]
    public class InsertionSortTests
    {
        InsertionSort TestInstance { get; set; }

        readonly int[] UnsortedArray = new int[] { 5, 1, 3, 9, 5, 0, 7, 8, 9, 7, 11 };
        readonly int[] ArrayTest = new int[] { 0, 1, 3, 5, 5, 7, 7, 8, 9, 9, 11 };

        [TestInitialize]
        public void Prepare()
        {
            TestInstance = new InsertionSort();
        }

        [TestMethod()]
        public void SortTest()
        {
            var array_result = TestInstance.Sort<int>(UnsortedArray);

            for (int i = 0; i < ArrayTest.Count(); i++)
            {
                Assert.IsTrue(array_result[i] == ArrayTest[i]);
            }
        }
    }
}