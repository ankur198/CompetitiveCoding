using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnyPairSum
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void InitialCase()
        {
            int[] array = { 10, 15, 3, 7 };
            int k = 17;
            var result = AnyPairSum.CanFindAnyPairSum(array, k);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test2()
        {
            int[] array = { 10, 15, 3, 7 };
            int k = 19;
            var result = AnyPairSum.CanFindAnyPairSum(array, k);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Test3()
        {
            int[] array = { 11, 15, 3, 17 };
            int k = 28;
            var result = AnyPairSum.CanFindAnyPairSum(array, k);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test4()
        {
            int[] array = { 11, 15, 3, 17 };
            int k = 29;
            var result = AnyPairSum.CanFindAnyPairSum(array, k);
            Assert.IsFalse(result);
        }
    }
}
