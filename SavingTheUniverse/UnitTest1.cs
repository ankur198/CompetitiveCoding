using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SavingTheUniverse
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ProgramStrengthTest()
        {
            var x = new CaseSenario("6 SCSSCC");
            Assert.AreEqual(5, x.ProgramStrength);

            x.Program = "SCCSSC".ToCharArray();
            Assert.AreEqual(9, x.ProgramStrength);

            x.Program = "CC".ToCharArray();
            Assert.AreEqual(0, x.ProgramStrength);
        }

        [TestMethod]
        public void Optimize1()
        {
            var x = new CaseSenario("6 SCCSSC");
            x.Optimize();
            Assert.IsTrue(x.ProgramStrength <= x.ShieldStrength);
            Console.WriteLine(x.Program);
            Console.WriteLine(x.SwapCount);
        }

        [TestMethod]
        public void Optimize2()
        {
            var x = new CaseSenario("3 CSCSS");
            x.Optimize();
            Console.WriteLine(x.Program);
            Console.WriteLine(x.SwapCount);
            Assert.IsTrue(x.ProgramStrength <= x.ShieldStrength);
        }

        [TestMethod]
        public void FullTest()
        {
            var input = "6\n" +
                        "1 CS\n" +
                        "2 CS\n" +
                        "1 SS\n" +
                        "6 SCCSSC\n" +
                        "2 CC\n" +
                        "3 CSCSS\n";

            string ComputedOutput = Program.InitializeFromInputArray(input.Split('\n'));

            Console.WriteLine(ComputedOutput);

            var ExpectedOutput = "Case #1: 1\n" +
                                    "Case #2: 0\n" +
                                    "Case #3: IMPOSSIBLE\n" +
                                    "Case #4: 2\n" +
                                    "Case #5: 0\n" +
                                    "Case #6: 5\n";

            Console.WriteLine(ExpectedOutput);
            var a = "aaa";
            Assert.IsTrue("aaa"==a);

            Assert.AreEqual(ComputedOutput , ExpectedOutput);
        }


    }
}
