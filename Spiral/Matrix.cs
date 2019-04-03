using System;
using System.Collections.Generic;

namespace Spiral
{
    class Matrix<T>
    {
        List<Row<T>> list = new List<Row<T>>();
        public readonly int RowSize;
        public readonly int ColSize;

        public Matrix(int RowSize, int ColSize)
        {
            for (int i = 0; i < RowSize; i++)
            {
                list.Add(new Row<T>(ColSize));
            }

            this.RowSize = RowSize;
            this.ColSize = ColSize;
        }

        public Row<T> this[int index] => list[index];

        public Element<T> this[int Row, int Col] => list[Row][Col];


        enum PathDirection
        {
            LTR, RTL, TTB, BTT
        };

        public IList<T> GetSpiral()
        {
            List<T> Result = new List<T>();
            int row = 0;
            int col = -1;
            PathDirection direction = PathDirection.LTR;         

            while (RowSize * ColSize > Result.Count)
            {
                switch (direction)
                {
                    case PathDirection.LTR:
                        visit(false, true, true);
                        direction = PathDirection.TTB;
                        break;
                    case PathDirection.RTL:
                        visit(false, true, false);
                        direction = PathDirection.BTT;
                        break;
                    case PathDirection.TTB:
                        visit(true, false, true);
                        direction = PathDirection.RTL;
                        break;
                    case PathDirection.BTT:
                        visit(true, false, false);
                        direction = PathDirection.LTR;
                        break;
                    default:
                        break;
                }



            }

            return Result;

            void visit(bool movRow, bool movCol, bool positiveDir)
            {
                int trow = row, tcol = col;

                while (true)
                {
                    //try new position
                    GetNextPos();
                    if (!isPositionFeasable())
                    {
                        break;
                    }

                    var element = this[trow, tcol];
                    if (element.Visited == false)
                    {
                        Result.Add(element.Value);
                        element.Visited = true;

                        //update in original
                        row = trow;
                        col = tcol;
                    }

                    else { break; }
                }
                void GetNextPos()
                {
                    if (positiveDir)
                    {
                        if (movRow)
                        {
                            trow++;
                        }
                        else if (movCol)
                        {
                            tcol++;
                        }
                    }

                    else
                    {
                        if (movRow)
                        {
                            trow--;
                        }
                        else if (movCol)
                        {
                            tcol--;
                        }
                    }
                }
                bool isPositionFeasable() => (trow < RowSize && trow > -1) && (tcol < ColSize && tcol > -1);
            }
        }
    }
}
