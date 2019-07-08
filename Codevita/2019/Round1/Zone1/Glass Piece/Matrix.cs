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
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private List<Point> boundaryPoints = new List<Point>();

        private List<Point> GivenPoints = new List<Point>();

        private bool isBoundaryPointsComputed = false;

        private List<List<Point>> Shapes = new List<List<Point>>();

        private int size;

        private IList<Point> DDA(Point point1, Point point2)
        {
            List<Point> points = new List<Point>();

            int dx = point2.X - point1.X;
            int dy = point2.Y - point1.Y;
            int step = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) : Math.Abs(dy);

            double xinc = dx / (float)step;
            double yinc = dy / (float)step;
            double x = point1.X;
            double y = point1.Y;
            int i = 1;

            while (i <= step)
            {
                points.Add(new Point((int)Math.Round(x), (int)Math.Round(y)));
                x += xinc;
                y += yinc;
                i += 1;
            }

            return points;
        }

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
            foreach (Point b in GivenPoints)
            {
                Grid[b.X, b.Y] = 6;
            }
            foreach (var corner in corners)
            {
                Grid[corner.X, corner.Y] = 7;
            }
            return corners;
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
            IList<Point> pos = DDA(point1, point2);
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
    }
}