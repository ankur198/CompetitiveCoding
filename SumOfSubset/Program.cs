using System;

namespace SumOfSubset
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Driver driver = new Driver(5, new int[] { 1, 2, 3, 4, 5 });
            foreach (var subset in await driver.GetSubset())
            {
                foreach (var item in subset)
                {
                    Console.Write($"{item}, ");
                }
                Console.WriteLine();
            }
            //Console.WriteLine("Hello World!");
        }
    }
}
