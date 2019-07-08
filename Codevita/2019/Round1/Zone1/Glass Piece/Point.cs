using System;

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
    }
}