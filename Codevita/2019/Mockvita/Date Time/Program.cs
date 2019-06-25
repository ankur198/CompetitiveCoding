using System;
using System.Collections.Generic;

namespace Date_Time
{
    class Program
    {
        static void MainMy(string[] args)
        {
            builder builder = new builder(new int[] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 });
            //builder builder = new builder(new int[] { 0, 0, 1, 2, 2, 2, 3, 5, 9, 9, 9, 9 });
            builder.start();
            if (builder.selectedDates.Count == 0)
            {
                Console.Write("0");
            }
            else
            {
                var item = builder.selectedDates[0];
                Console.Write($"{item.Month}/{item.Date} {item.Hour}:{item.Minute}");
            }
        }
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(',');
            var arr = new List<int>();
            foreach (var item in input)
            {
                arr.Add(int.Parse(item));
            }
            builder builder = new builder(arr.ToArray());
            //builder builder = new builder(new int[] { 0, 0, 1, 2, 2, 2, 3, 5, 9, 9, 9, 9 });
            builder.start();
            if (builder.selectedDates.Count == 0)
            {
                Console.Write("0");
            }
            else
            {
                var item = builder.selectedDates[0];
                Console.Write($"{item.Month}/{item.Date} {item.Hour}:{item.Minute}");
            }
        }
    }
}
