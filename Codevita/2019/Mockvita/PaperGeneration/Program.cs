using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperGeneration
{
    class Program
    {
        static void MainMy(string[] args)
        {
            Builder b = new Builder(new int[] { 3, 4, 3 }, new int[] { 2, 3, 2 }, new char[] { 'A', 'D' }, 'G');
            b.GetPossibleCombinations();
            PrintPossibleCombinations(b);

            Console.WriteLine();

            Builder b1 = new Builder(new int[] { 3, 3, 3 }, new int[] { 2, 2, 2 }, new char[] { 'A', 'C' }, 'D');
            b1.GetPossibleCombinations();
            PrintPossibleCombinations(b1);
        }

        static void Main(string[] args)
        {
            int[] Total = new int[3];
            int[] Count = new int[3];
            Total[0] = int.Parse(Console.ReadLine());
            Count[0] = int.Parse(Console.ReadLine());
            Total[1] = int.Parse(Console.ReadLine());
            Count[1] = int.Parse(Console.ReadLine());
            Total[2] = int.Parse(Console.ReadLine());
            Count[2] = int.Parse(Console.ReadLine());
            string[] AllergicS = Console.ReadLine().Split(' ');
            char Once = Convert.ToChar(Console.ReadLine());
            char[] Allergic = new char[2];
            for (int i = 0; i < AllergicS.Length; i++)
            {
                Allergic[i] = Convert.ToChar(AllergicS[i]);
            }
            Builder builder = new Builder(Total, Count, Allergic, Once);
            builder.GetPossibleCombinations();
            int t = 1;
            foreach (var item in Total)
            {
                t *= item;
            }
            Console.WriteLine(t);
            Console.WriteLine(builder.SelectedNodes.Count());
        }

        private static void PrintPossibleCombinations(Builder b)
        {
            foreach (var item in b.SelectedNodes)
            {
                foreach (var n in item.Questions)
                {
                    Console.Write(n.Name.ToString() + ' ');
                }
                Console.WriteLine();
            }
        }
    }
}
