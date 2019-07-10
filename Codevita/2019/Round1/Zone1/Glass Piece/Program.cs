using System;
using System.Collections.Generic;

namespace Glass_Piece
{
    internal class Program
    {
        static Matrix matrix;
        private static void Main(string[] args)
        {
            matrix = new Matrix(50);

            #region Make Shape
            List<Point> shape1 = new List<Point>();
            shape1.Add(new Point(0, 0));
            shape1.Add(new Point(25, 0));
            shape1.Add(new Point(50, 25));
            shape1.Add(new Point(10, 30));
            shape1.Add(new Point(0, 30));
            matrix.AddShape(shape1);

            List<Point> shape2 = new List<Point>();
            shape2.Add(new Point(25, 0));
            shape2.Add(new Point(50, 0));
            shape2.Add(new Point(50, 25));
            shape2.Add(new Point(25, 0));
            matrix.AddShape(shape2);


            List<Point> shape3 = new List<Point>();
            shape3.Add(new Point(10, 30));
            shape3.Add(new Point(50, 25));
            shape3.Add(new Point(50, 50));
            shape3.Add(new Point(25, 50));
            matrix.AddShape(shape3);

            List<Point> shape4 = new List<Point>();
            shape4.Add(new Point(0, 30));
            shape4.Add(new Point(10, 30));
            shape4.Add(new Point(10, 50));
            shape4.Add(new Point(0, 50));
            //matrix.AddShape(shape4);

            List<Point> shape5 = new List<Point>();
            shape5.Add(new Point(0, 40));
            shape5.Add(new Point(5, 35));
            shape5.Add(new Point(10, 40));
            //matrix.AddShape(shape5);
            #endregion

            var points = matrix.MissingPoints;
            matrix.VisualiseInConsole();

            foreach (var item in points)
            {
                Console.WriteLine(item);
            }
        }
    }
}
