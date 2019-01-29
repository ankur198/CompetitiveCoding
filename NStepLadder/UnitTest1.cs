using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NStepLadder
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Initial()
        {
            var array = new int[]{1,2};
            var x = 4;

            Assert.AreEqual(5, SumOfSubset.isSumOfSubset(array,x));
        }
    }
}
