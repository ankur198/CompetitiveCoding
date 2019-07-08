using System;
using System.Collections.Generic;

namespace Glass_Piece
{
    internal class Program
    {
        static Matrix matrix;
        private static void Main(string[] args)
        {
            matrix = new Matrix(40);

            List<Point> shape1 = new List<Point>();
            shape1.Add(new Point(0, 0));
            shape1.Add(new Point(20, 0));
            shape1.Add(new Point(40, 20));
            shape1.Add(new Point(10, 25));
            shape1.Add(new Point(0, 25));
            matrix.AddShape(shape1);

            List<Point> shape2 = new List<Point>();
            shape2.Add(new Point(20, 0));
            shape2.Add(new Point(40, 0));
            shape2.Add(new Point(40, 20));
            shape2.Add(new Point(20, 0));
            matrix.AddShape(shape2);


            List<Point> shape3 = new List<Point>();
            shape3.Add(new Point(10, 25));
            shape3.Add(new Point(40, 20));
            shape3.Add(new Point(40, 40));
            shape3.Add(new Point(20, 40));
            //matrix.AddShape(shape3);

            List<Point> shape4 = new List<Point>();
            shape4.Add(new Point(0, 25));
            shape4.Add(new Point(10, 40));
            shape4.Add(new Point(0, 40));
            //matrix.AddShape(shape4);

            List<Point> shape5 = new List<Point>();
            shape5.Add(new Point(0, 40));
            shape5.Add(new Point(20, 35));
            shape5.Add(new Point(20, 40));
            //matrix.AddShape(shape5);

            var x = matrix.MissingPoints;
            x.Sort();
            //x.Reverse();

            matrix.VisualiseInConsole();


            foreach (var item in x)
            {
                Console.WriteLine($"{item.X} {item.Y}");
            }
            Console.WriteLine();

            List<Point> sortedPoints = GetPath(x);

            foreach (var item in sortedPoints)
            {
                Console.WriteLine($"{item.X} {item.Y}");
            }

            for (int i = 0; i < sortedPoints.Count - 1; i++)
            {
                Console.WriteLine($"{sortedPoints[i]} {sortedPoints[i + 1]} {Point.GetSlope(sortedPoints[i], sortedPoints[i + 1])}");
            }
            Console.WriteLine($"{sortedPoints[^1]} {sortedPoints[0]} {Point.GetSlope(sortedPoints[^1], sortedPoints[0])}");

            Console.WriteLine();


            #region DDA Check
            //foreach (var item in Point.DDA(new Point(40, 20), new Point(25, 10)))
            //{
            //    Console.Write($"{item}, ");
            //}
            //Console.WriteLine();

            //var y = Point.DDA(new Point(25, 10), new Point(40, 20))
            //    ;
            //y.Reverse();
            //foreach (var item in y)
            //{
            //    Console.Write($"{item}, ");
            //}
            //Console.WriteLine();
            #endregion

        }

        private static List<Point> GetPath(List<Point> x)
        {
            var sortedPoints = new List<Point>();
            sortedPoints.Add(x[0]);
            x.RemoveAt(0);

            while (x.Count != 0)
            {
                List<Point> DdaPoints = Point.DDA(sortedPoints[^1], x[0]);

                if (IsBorder(DdaPoints))
                {
                    sortedPoints.Add(x[0]);
                    x.RemoveAt(0);
                }
                else
                {
                    x.Add(x[0]);
                    x.RemoveAt(0);
                }

                if (sortedPoints.Count > 2)
                {
                    if (Point.GetSlope(sortedPoints[^3], sortedPoints[^2]) == Point.GetSlope(sortedPoints[^2], sortedPoints[^1]))
                    {
                        sortedPoints.RemoveAt(sortedPoints.Count - 1);
                    }
                }
            }

            return sortedPoints;
        }

        private static bool IsBorder(List<Point> ddaPoints)
        {
            foreach (var item in ddaPoints)
            {
                if (matrix.Grid[item.X, item.Y] == 0 || matrix.Grid[item.X, item.Y] == 9)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
