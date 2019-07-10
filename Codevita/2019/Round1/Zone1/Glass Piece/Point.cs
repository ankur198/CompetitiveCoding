using System;
using System.Collections.Generic;

namespace Glass_Piece
{
    internal struct Point : IComparable
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public int CompareTo(object obj)
        {
            if (obj is Point)
            {
                Point p = (Point)obj;
                int y = Y.CompareTo(p.Y);
                int x = X.CompareTo(p.X);

                return y + 90000000 * x;
            }

            throw new NotImplementedException("Other object is not a Point");
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.X == p2.X && p2.Y == p1.Y;
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }

        public Point Invert()
        {
            return new Point(Y, X);
        }
        public static double GetSlope(Point p1, Point p2)
        {
            try
            {
                var x = (p1.X - p2.X) / (float)(p1.Y - p2.Y);
                return x;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        public static List<Point> DDA(Point point1, Point point2)
        {
            List<Point> points = new List<Point>();

            int dx = point2.X - point1.X;
            int dy = point2.Y - point1.Y;
            int step = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) : Math.Abs(dy);

            double xinc = dx / (float)step;
            double yinc = dy / (float)step;
            double x = point1.X;
            double y = point1.Y;
            int i = 0;

            while (i <= step)
            {
                points.Add(new Point((int)Math.Round(x), (int)Math.Round(y)));
                x += xinc;
                y += yinc;
                i += 1;
            }

            return points;
        }

        public override string ToString()
        {
            return string.Format($"{X} {Y}");
        }
    }
}