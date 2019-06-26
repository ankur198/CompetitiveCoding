using System;

namespace hopGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Builder builder = new Builder(new int[] { 4, 5, 6, 7, 4, 5 });
            //Builder builder = new Builder(new int[] { 4, 2, 3 });
            builder.start();
            Console.WriteLine(builder.max);
            Console.WriteLine("Hello World!");
        }
    }
}
