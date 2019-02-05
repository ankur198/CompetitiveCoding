using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MessageDecoding
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Initial()
        {
            var md = new MessegeDecoder();
            Assert.AreEqual(3, md.GetPossibleCombinations(111));
        }

        [TestMethod]
        public void TestMethod1()
        {
            var md = new MessegeDecoder();
            Assert.AreEqual(3, md.GetPossibleCombinations(111));
        }

        [TestMethod]
        public void TestMethod2()
        {
            var md = new MessegeDecoder();
            Assert.AreEqual(1, md.GetPossibleCombinations(110));
        }

        [TestMethod]
        public void TestMethod3()
        {
            var md = new MessegeDecoder();
            Assert.AreEqual(5, md.GetPossibleCombinations(1111));
        }
    }
}
