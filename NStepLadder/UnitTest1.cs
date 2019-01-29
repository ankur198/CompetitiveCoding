using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NStepLadder
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Initial()
        {
            var array = new int[] { 1, 2 };
            var x = 4;

            System.Console.WriteLine("Yoo");
            Assert.AreEqual(5, NStepLadder.PossiblePaths(array, x));
        }

        [TestMethod]
        public void Test1()
        {
            var array = new int[] { 1, 2, 3 };
            var x = 4;

            System.Console.WriteLine("Yoo");
            Assert.AreEqual(7, NStepLadder.PossiblePaths(array, x));
        }

        [TestMethod]
        public void Test2()
        {
            var array = new int[] { 2,1 };
            var x = 4;

            System.Console.WriteLine("Yoo");
            Assert.AreEqual(5, NStepLadder.PossiblePaths(array, x));
        }
    }
}
