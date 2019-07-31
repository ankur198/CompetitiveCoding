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

            #region Make Shape
            List<Point> shape1 = new List<Point>();
            shape1.Add(new Point(0, 0));
            shape1.Add(new Point(40,0));
            shape1.Add(new Point(40,10));
            shape1.Add(new Point(30, 15));
            shape1.Add(new Point(20, 20));
            shape1.Add(new Point(0, 20));
            matrix.AddShape(shape1);

            List<Point> shape2 = new List<Point>();
            shape2.Add(new Point(0, 20));
            shape2.Add(new Point(10,20));
            shape2.Add(new Point(20,30));
            shape2.Add(new Point(20,40));
            shape2.Add(new Point(0,40));
            matrix.AddShape(shape2);

            List<Point> shape3 = new List<Point>();
            shape3.Add(new Point(2000,2500));
            shape3.Add(new Point(3000,1500));
            shape3.Add(new Point(4000,1000));
            shape3.Add(new Point(4000,4000));
            shape3.Add(new Point(2000,4000));
            //matrix.AddShape(shape3);

            List<Point> shape4 = new List<Point>();
            shape4.Add(new Point(20, 40));
            shape4.Add(new Point(20, 35));
            shape4.Add(new Point(30, 10));
            shape4.Add(new Point(40, 10));
            shape4.Add(new Point(40, 30));
            shape4.Add(new Point(40, 40));
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
