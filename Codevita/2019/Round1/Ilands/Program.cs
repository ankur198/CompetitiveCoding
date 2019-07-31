using System;
using System.Collections.Generic;

namespace Islands
{
    class Program
    {
        static void Main(string[] args)
        {
            int IslandsCount = int.Parse(Console.ReadLine().Trim());
            List<String> IslandsCoord = new List<String>();
            List<Island> Islands = new List<Island>();
            for (int i = 0; i < IslandsCount; i++)
            {
                IslandsCoord.Add(Console.ReadLine().Trim());
            }
            Coordinates Ship = new Coordinates(Console.ReadLine().Trim());

            foreach (var island in IslandsCoord)
            {
                var t = island.Split(' ');
                var coords = new Coordinates[] { new Coordinates($"{t[0]} {t[1]}"), new Coordinates($"{t[2]} {t[3]}") };
                Islands.Add(new Island(coords, Ship));
            }

            Islands.Sort();
            string s = "";
            foreach (var item in Islands)
            {
                s += $"{item.Index.ToString()} ";
            }
            s = s.Trim();
            Console.WriteLine(s);
        }
    }

    class Island : IComparable
    {
        static int IndexCounter = 1;
        public int Distance { get; private set; }
        public int Index { get; }
        public Island(Coordinates[] Diagonal, Coordinates Ship)
        {
            var allCoords = new Coordinates[4];
            allCoords[0] = Diagonal[0];
            allCoords[1] = Diagonal[1];
            allCoords[2] = new Coordinates(Diagonal[0].X, Diagonal[1].Y);
            allCoords[3] = new Coordinates(Diagonal[1].X, Diagonal[0].Y);
            FindDistance(Ship, allCoords);
            Index = IndexCounter++;
        }

        private void FindDistance(Coordinates Ship, Coordinates[] allCoords)
        {
            Distance = int.MaxValue;
            foreach (var item in allCoords)
            {
                if (Ship.Distance(item) < Distance)
                {
                    Distance = Ship.Distance(item);
                }
            }
        }

        public int CompareTo(object obj)
        {

            if (obj is Island)
            {
                return Distance.CompareTo((obj as Island).Distance);
            }
            return 0;
        }
    }

    class Coordinates
    {
        public Coordinates(string rawCoord)
        {
            var t = rawCoord.Split(' ');
            X = int.Parse(t[0]);
            Y = int.Parse(t[1]);
        }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public int Distance(Coordinates coordinates)
        {
            var x = Math.Abs(X - coordinates.X);
            var y = Math.Abs(Y - coordinates.Y);
            return x + y;
        }

    }
}
