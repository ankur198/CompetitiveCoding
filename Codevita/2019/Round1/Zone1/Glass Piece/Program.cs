using System;
using System.Collections.Generic;

namespace Glass_Piece
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Matrix matrix = new Matrix(40);

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
            matrix.AddShape(shape3);

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
            foreach (var item in x)
            {
                Console.WriteLine($"{item.X} {item.Y}");
            }

            matrix.VisualiseInConsole();
        }
    }
}
