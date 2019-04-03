using System;
using System.Collections;

namespace Spiral
{
    class Program
    {
        static void Main(string[] args)
        {
            Spiral.doSomething();
        }
    }

    class Spiral
    {
        public static void doSomething()
        {
            var mat = new Matrix<string>(5, 5);
            for (int i = 0; i < mat.RowSize; i++)
            {
                for (int j = 0; j < mat[i].Size; j++)
                {
                    mat[i][j] = (i.ToString() + j.ToString());
                }
            }

            var res = mat.GetSpiral();

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
    }
}
