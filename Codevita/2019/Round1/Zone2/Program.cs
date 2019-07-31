using System;
using System.Collections.Generic;

namespace Zone2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            string[] rawinput = Console.ReadLine().Split(' ');
            List<cap> caps = new List<cap>();
            foreach (var item in rawinput)
            {
                caps.Add(new cap(int.Parse(item)));
            }
            while (minimize(caps)) ;
            //foreach (var item in caps)
            //{
            //    Console.Write($"{item.Value}, ");
            //}
            //Console.WriteLine();
            Console.WriteLine(caps.Count);
        }

        static bool minimize(List<cap> caps)
        {
            var min = getMinCap(caps);
            caps.Remove(min);
            var parent = getParent(caps, min);


            if (parent != null)
            {
                parent.Inside = min;
                return true;
            }
            else
            {
                caps.Add(min);
                return false;
            }


        }

        static cap getMinCap(List<cap> caps)
        {
            cap min = caps[0];
            for (int i = 1; i < caps.Count; i++)
            {
                if (caps[i].Value < min.Value)
                {
                    min = caps[i];
                }
            }
            return min;
        }

        static cap getParent(List<cap> caps, cap min)
        {
            cap parent = null;
            for (int i = 0; i < caps.Count; i++)
            {
                if (caps[i].Inside == null && min.Value < caps[i].Value)
                {
                    if (parent == null)
                    {
                        parent = caps[i];
                    }
                    else if (parent.Value > caps[i].Value)
                    {
                        parent = caps[i];
                    }
                }
            }
            return parent;
        }
    }

    class cap
    {
        public int Value { get; set; }
        public cap Inside { get; set; }

        public cap(int value)
        {
            Value = value;
        }
    }
}
