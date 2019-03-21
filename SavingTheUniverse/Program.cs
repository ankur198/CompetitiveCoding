using System;

namespace SavingTheUniverse
{
    class Program
    {
        internal static CaseSenario[] TestCases;

        #region Uncomment to run as normal program
        //static void Main(string[] args)
        //{
        //    RealInput();

        //    for (int i = 0; i < TestCases.Length; i++)
        //    {
        //        CaseSenario item = TestCases[i];
        //        Console.WriteLine($"Case #{i + 1}: {item.ToString()}");
        //    }
        //}
        #endregion


        internal static string InitializeFromInputArray(string[] inputArray)
        {
            Program.TestCases = new CaseSenario[int.Parse(inputArray[0])];
            for (int i = 0; i < Program.TestCases.Length; i++)
            {
                Program.TestCases[i] = new CaseSenario(inputArray[i + 1]);
            }

            string ComputedOutput = "";

            for (int i = 0; i < Program.TestCases.Length; i++)
            {
                CaseSenario item = Program.TestCases[i];
                ComputedOutput += $"Case #{i + 1}: {item.ToString()}\n";
            }

            return ComputedOutput;
        }

        private static void RealInput()
        {
            int nTestCases = int.Parse(Console.ReadLine());
            TestCases = new CaseSenario[nTestCases];

            for (int i = 0; i < nTestCases; i++)
            {
                TestCases[i] = new CaseSenario(Console.ReadLine());
            }
        }
    }
}
