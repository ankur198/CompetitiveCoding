using System;

namespace PhilalandCoin
{
    class Program
    {
        static void MainMy(string[] args)
        {
            Builder builder = new Builder();
            var x = builder.MinimizeCoins(16);
            //foreach (var item in x)
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine(x.Count);
        }
        static void Main(string[] args)
        {
            var cases = int.Parse(Console.ReadLine());
            for (int i = 0; i < cases; i++)
            {
                Builder builder = new Builder();
                var x = builder.MinimizeCoins(int.Parse(Console.ReadLine()));
                Console.WriteLine(x.Count);
            }
        }
    }
}
