using System;

namespace Date_Time
{
    class Program
    {
        static void Main(string[] args)
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
    }
}
