using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace OverlappingBoxes
{
    class Region
    {
        public static int maxRow;
        public static int maxCol;
        public int[] StartIndex { get; set; }
        public int[] EndIndex { get; set; }
        public int Power { get; set; }

        public Region(string rawInput)
        {
            var x = rawInput.Split(' ');
            var y = (from r in x select int.Parse(r)).ToArray();
            StartIndex = new int[] { y[0], y[1] };
            EndIndex = new int[] { y[2], y[3] };
            Power = y[4];

            if (maxRow < EndIndex[0])
            {
                maxRow = EndIndex[0];
            }
            if (maxCol < EndIndex[1])
            {
                maxCol = EndIndex[1];
            }
        }
    }

    class GridMaker
    {
        int[,] Grid;
        public int maxPow = 0;
        public int maxPowBoxesCount = 0;
        public GridMaker(List<Region> regions)
        {
            Grid = new int[Region.maxRow, Region.maxCol];

            UpdateRegions(regions);
        }

        private void UpdateRegions(List<Region> regions)
        {
            foreach (var region in regions)
            {
                for (int i = region.StartIndex[0]; i < region.EndIndex[0]; i++)
                {
                    for (int j = region.StartIndex[1]; j < region.EndIndex[1]; j++)
                    {
                        Grid[i, j] += region.Power;
                        //maxPow = Math.Max(maxPow, Grid[i, j]);
                        if (maxPow < Grid[i, j])
                        {
                            maxPow = Grid[i, j];
                            maxPowBoxesCount = 1;
                        }
                        else if (maxPow == Grid[i, j])
                        {
                            maxPowBoxesCount += 1;
                        }
                    }
                }
            }
        }
    }

    class Builder
    {
        GridMaker gridMaker;
        public Builder(string[] rawInputs)
        {
            var allRegions = new List<Region>();
            foreach (var rawInput in rawInputs)
            {
                allRegions.Add(new Region(rawInput));
            }
            gridMaker = new GridMaker(allRegions);
        }

        public int getMaxBoxsCount()
        {
            return gridMaker.maxPowBoxesCount;
        }
    }
}
