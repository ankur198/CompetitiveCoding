using System;
using System.Collections.Generic;

namespace OverlappingBoxes
{
    class Program
    {
        static void MainMy(string[] args)
        {
            //var inputs = new string[] { "1 1 3 6 5", "2 2 4 4 8" };
            var inputs = new string[] { "21 46 38 56 13", "26 28 47 38 8", "18 32 38 38 5", "31 35 42 51 8","39 31 45 38 5" };
            Builder b = new Builder(inputs);
            Console.WriteLine(b.getMaxBoxsCount());
            Console.WriteLine("Hello World!");
        }

        static void Main(string[] args)
        {
            //var inputs = new string[] { "1 1 3 6 5", "2 2 4 4 8" };
            var regionsCount = int.Parse(Console.ReadLine());
            List<string> rawRegions = new List<string>();
            for (int i = 0; i < regionsCount; i++)
            {
                rawRegions.Add(Console.ReadLine());
            }

            var inputs = rawRegions.ToArray();
            Builder b = new Builder(inputs);
            Console.Write(b.getMaxBoxsCount());
        }

    }
}
