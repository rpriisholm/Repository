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
    public class AMergeTests
    {
        TestAMerge TestInstance { get; set; }

        readonly int[] Array1 = new int[] {0, 5, 7, 8, 9, 11 };
        readonly int[] Array2 = new int[] {1, 3, 5, 7, 9 };
        readonly int[] ArrayTest = new int[] { 0, 1, 3, 5, 5, 7, 7, 8, 9, 9, 11 };


        [TestClass]
        class TestAMerge : AMerge
        {

        }

        [TestInitialize]
        public void Prepare()
        {
            TestInstance = new TestAMerge();
        }

        [TestMethod()]
        public void MergeTest()
        {            
            var array_result = TestInstance.Merge<int>(Array1, Array2);

            for (int i = 0; i < ArrayTest.Count(); i++)
            {
                Assert.IsTrue(array_result[i] == ArrayTest[i]);
            }
        }
    }
}
