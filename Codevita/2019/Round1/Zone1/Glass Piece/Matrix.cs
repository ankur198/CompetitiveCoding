using System;
using System.Collections.Generic;
using System.Linq;

namespace Glass_Piece
{
    internal class Matrix
    {
        public int[,] Grid;

        public List<Point> MissingPoints => FindMissingShapePoints();

        public Matrix(int size)
        {
            size += 1;
            Grid = new int[size, size];
            this.size = size;
        }

        public void AddShape(List<Point> points)
        {
            Shapes.Add(points);
        }

        public void VisualiseInConsole()
        {
            Console.ResetColor();
            for (int rows = 0; rows < Grid.GetLength(0); rows++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(rows + "\t");
                for (int cols = 0; cols < Grid.GetLength(1); cols++)
                {
                    if (Grid[rows, cols] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(Grid[rows, cols]);
                    }
                    else if (Grid[rows, cols] == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Grid[rows, cols]);
                    }
                    else if (Grid[rows, cols] == 9)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(Grid[rows, cols]);
                    }
                    else if (Grid[rows, cols] == 6)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Grid[rows, cols]);
                    }
                    else if (Grid[rows, cols] == 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(Grid[rows, cols]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(Grid[rows, cols]);
                    }
                    Console.Write("");
                }
                Console.WriteLine();
            }
        }

        private List<Point> boundaryPoints = new List<Point>();

        private List<Point> GivenPoints = new List<Point>();

        private bool isBoundaryPointsComputed = false;

        private List<List<Point>> Shapes = new List<List<Point>>();

        private int size;

        private void FillShape()
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                List<int> oneCols = new List<int>();
                for (int col = 0; col < size; col++)
                {
                    if (Grid[i, col] == 1)
                    {
                        oneCols.Add(col);
                    }
                }
                foreach (int col in oneCols)
                {
                    Grid[i, col] = 0;
                }
                if (oneCols.Count > 1)
                {
                    Grid[i, oneCols[0]] = 1;
                    Grid[i, oneCols[^1]] = 1;
                }

                bool isStarted = false;
                for (int cols = 0; cols < size; cols++)
                {
                    if (Grid[i, cols] == 1 && isStarted)
                    {
                        isStarted = false;
                        Grid[i, cols] = 9;
                    }
                    else if (Grid[i, cols] == 1)
                    {
                        isStarted = true;
                        Grid[i, cols] = 9;
                    }
                    if (isStarted)
                    {
                        Grid[i, cols] = 9;
                    }
                }
                foreach (int col in oneCols)
                {
                    Grid[i, col] = 2;
                }
            }
        }

        private List<Point> FindMissingShapePoints()
        {
            ResetGrid();
            MakeShape();
            SetBoundaryLine();
            var corners = GetBoundaryCornerPoints();
            PutGivenPoints();
            PutBoundaryPoints(corners);
            corners.Sort();
            var path = GetPath(corners);
            SortClockwise(path);
            return path;
        }

        private void SortClockwise(List<Point> points)
        {
            GetLeftmostOnTop();
            SetDirection();

            void SetDirection()
            {
                var leftmost = points[0];
                points.RemoveAt(0);

                if ((points[0].Y < points[^1].Y) || (points[0].X > points[^1].X && points[0].Y == points[^1].Y))
                {
                    // nothing
                }
                else
                {
                    //acw
                    points.Reverse();
                }

                points.Insert(0, leftmost);
            }

            void GetLeftmostOnTop()
            {
                int minTopIndex = 0;
                for (int i = 1; i < points.Count; i++)
                {
                    if (points[i].X < points[minTopIndex].X)
                    {
                        minTopIndex = i;
                    }
                    else if (points[i].X == points[minTopIndex].X && points[i].Y < points[minTopIndex].Y)
                    {
                        minTopIndex = i;
                    }
                }

                while (minTopIndex != 0)
                {
                    var t = points[0];
                    points.Add(t);
                    points.RemoveAt(0);
                    minTopIndex--;
                }
            }
        }
        private void PutBoundaryPoints(List<Point> corners)
        {
            foreach (var corner in corners)
            {
                Grid[corner.X, corner.Y] = 7;
            }
        }

        private void PutGivenPoints()
        {
            foreach (Point b in GivenPoints)
            {
                Grid[b.X, b.Y] = 6;
            }
        }

        private List<Point> GetBoundaryCornerPoints()
        {
            List<Point> FinalPoints = new List<Point>();
            GivenPoints = GivenPoints.Distinct().ToList();

            foreach (var item in GivenPoints)
            {
                bool status = false;

                // top
                if (item.X > 0)
                {
                    if (Grid[item.X - 1, item.Y] == 5)
                    {
                        status = true;
                    }
                    else if (item.Y > 0 && Grid[item.X - 1, item.Y - 1] == 5)
                    {
                        status = true;
                    }
                    else if (item.Y < size - 1 && Grid[item.X - 1, item.Y + 1] == 5)
                    {
                        status = true;
                    }
                }
                //line
                if (status == false)
                {
                    if (item.Y > 0 && Grid[item.X, item.Y - 1] == 5)
                    {
                        status = true;
                    }
                    else if (item.Y < size - 1 && Grid[item.X, item.Y + 1] == 5)
                    {
                        status = true;
                    }
                }

                //bottom
                if (status == false)
                {
                    if (item.X < size - 1)
                    {
                        if (Grid[item.X + 1, item.Y] == 5)
                        {
                            status = true;
                        }
                        else if (item.Y > 0 && Grid[item.X + 1, item.Y - 1] == 5)
                        {
                            status = true;
                        }
                        else if (item.Y < size - 1 && Grid[item.X + 1, item.Y + 1] == 5)
                        {
                            status = true;
                        }
                    }
                }

                if (status)
                {
                    FinalPoints.Add(item);
                    FinalPoints = FinalPoints.Distinct().ToList();
                }
            }

            //corners
            foreach (var x in new int[] { 0, size - 1 })
            {
                foreach (var y in new int[] { 0, size - 1 })
                {
                    if (Grid[x, y] == 5)
                    {
                        FinalPoints.Add(new Point(x, y));
                    }
                }
            }

            return FinalPoints;
        }

        private void MakeShape()
        {
            foreach (var points in Shapes)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    points[i] = new Point(points[i].Y, points[i].X);
                }

                GivenPoints.AddRange(points);
                for (int i = 0; i < points.Count - 1; i++)
                {
                    PutLine(points[i], points[i + 1]);
                }
                PutLine(points[^1], points[0]);
                FillShape();
            }
        }

        private void PutLine(Point point1, Point point2)
        {
            IList<Point> pos = Point.DDA(point1, point2);
            foreach (Point item in pos)
            {
                Grid[item.X, item.Y] = 1;
            }
        }

        private void ResetGrid()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Grid[i, j] = 0;
                }
            }
        }

        private List<Point> SetBoundaryLine()
        {
            if (isBoundaryPointsComputed == false)
            {
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        bool status = false;

                        if (col == 0 && Grid[row, col] == 0)
                        {
                            status = true;
                        }
                        else if (col == size - 1 && Grid[row, col] == 0)
                        {
                            status = true;
                        }
                        else if (row == size - 1)
                        {
                            if (Grid[row, col] == 0)
                            {
                                status = true;
                            }
                        }
                        else if (Grid[row, col] == 2)
                        {
                            if (row > 0 && Grid[row - 1, col] == 0)
                            {
                                status = true;
                            }
                            else if (row < size - 1 && Grid[row + 1, col] == 0)
                            {
                                status = true;
                            }
                            else if (col > 0 && Grid[row, col - 1] == 0)
                            {
                                status = true;
                            }
                            else if (col < size - 1 && Grid[row, col + 1] == 0)
                            {
                                status = true;
                            }
                        }

                        if (status)
                        {
                            boundaryPoints.Add(new Point(row, col));
                            Grid[row, col] = 5;
                        }
                    }
                }

                boundaryPoints.Sort();
                isBoundaryPointsComputed = true;
            }
            return boundaryPoints;
        }

        private bool? IsBorder(List<Point> ddaPoints)
        {
            int two = 0, five = 0;
            foreach (var item in ddaPoints)
            {
                if (Grid[item.X, item.Y] == 5 || Grid[item.X, item.Y] == 7)
                {
                    five++;
                }
                else if (Grid[item.X, item.Y] == 2)
                {
                    two++;
                }
                else return false;

                //if (Grid[item.X, item.Y] == 0 || Grid[item.X, item.Y] == 9)
                //{
                //    return false;
                //}
            }
            return two > 0 ? (bool?)null : true;
            //return null;
        }

        private List<Point> GetPath(List<Point> Points)
        {
            //x.Reverse();
            List<Point[]> MaybeList = new List<Point[]>();
            var sortedPoints = new List<Point>();
            sortedPoints.Add(Points[0]);
            Points.RemoveAt(0);
            while (Points.Count != 0)
            {
                bool isInMaybeList = false;

                foreach (var item in MaybeList)
                {
                    if (item[0] == sortedPoints[^1] && item[1] == Points[0])
                    {
                        isInMaybeList = true;
                        break;
                    }
                }


                List<Point> DdaPoints = Point.DDA(sortedPoints[^1], Points[0]);
                List<Point> DdaPointsRev = Point.DDA(Points[0], sortedPoints[^1]);

                if (IsBorder(DdaPoints) == true || IsBorder(DdaPointsRev) == true || isInMaybeList)
                {
                    sortedPoints.Add(Points[0]);
                    Points.RemoveAt(0);

                    if (sortedPoints.Count > 2)
                    {
                        if (Point.GetSlope(sortedPoints[^3], sortedPoints[^2]) == Point.GetSlope(sortedPoints[^2], sortedPoints[^1]))
                        {
                            sortedPoints.RemoveAt(sortedPoints.Count - 2);
                        }
                    }
                }
                else if (IsBorder(DdaPoints) == null)
                {
                    MaybeList.Add(new Point[] { sortedPoints[^1], Points[0] });
                    Points.Add(Points[0]);
                    Points.RemoveAt(0);
                }
                else
                {
                    Points.Add(Points[0]);
                    Points.RemoveAt(0);
                }
            }

            if (Point.GetSlope(sortedPoints[^1], sortedPoints[0]) == Point.GetSlope(sortedPoints[^1], sortedPoints[^2]))
            {
                sortedPoints.RemoveAt(sortedPoints.Count - 1);
            }

            //invert to make graph friendly
            for (int i = 0; i < sortedPoints.Count; i++)
            {
                sortedPoints[i] = sortedPoints[i].Invert();
            }
            return sortedPoints;
        }
    }
}