using System;

namespace hopGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Builder builder = new Builder(new int[] { 0,2,1,2 });
            //Builder builder = new Builder(new int[] { 4,2,5, 5, 6, 7, 4, 1,2,8 });
            //Builder builder = new Builder(new int[] { 4, 5, 6, 7, 4, 5 });
            //Builder builder = new Builder(new int[] { 4, 2, 3 });
            builder.start();
            var x = builder.maxp;
            Console.WriteLine(builder.max);
        }
    }
}
