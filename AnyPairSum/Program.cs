using System;
using System.Linq;
using System.Threading;

namespace AnyPairSum
{
    internal class AnyPairSum
    {
        private int[] Array;
        private int Sum; //result we want

        public static bool CanFindAnyPairSum(int[] array, int k)
        {
            //uncomment for linear
            //return new AnyPairSum(array, k).CanFindSum;

            //more optimized solution
            return new AnyPairSum(array, k).CanFindSumBacktracking;
        }

        public AnyPairSum(int[] array, int sum)
        {
            Array = array;
            Sum = sum;
        }

        private bool CanFindSumLinearAlgo
        {
            get
            {
                for (int i = 0; i < Array.Length; i++)
                {
                    var remainingSum = Sum - Array[i];

                    //contains works as a second loop, making time complexity O(n^2)
                    if (Array.Skip(i + 1).Contains(remainingSum))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        private bool CanFindSumBacktracking
        {
            get
            {
                CreateNode(Array[0], 1, Array.Skip(1).Sum());
                return Result;
            }
        }

        private bool CanSum(int selected, int remSum)
        {
            return selected + remSum >= Sum;
        }

        private bool Result = false;

        private void CreateNode(int selected, int index, int remSum)
        {
            //to kill all other running threads
            if (Result)
            {
                return;
            }

            //if ans is found
            if (selected + Array[index] == Sum)
            {
                Result = true;
            }

            //if not found
            remSum -= Array[index];
            MakeInnerBranched(selected, index, remSum);
        }

        private void MakeInnerBranched(int selected, int index, int remSum)
        {
            //if and can be found INCLUDING selected item
            //then create a new thread to find it
            Thread include = null, exclude = null;
            if (CanSum(selected, remSum))
            {
                include = new Thread(() =>
                {
                    CreateNode(selected, index + 1, remSum);
                });
            }

            //if and can be found EXCLUDING selected item
            //then create a new thread to find it
            if (CanSum(Array[index], remSum))
            {
                exclude = new Thread(() =>
                {
                    CreateNode(Array[index], index + 1, remSum);
                });
            }

            include?.Start();
            exclude?.Start();
            include?.Join();
            exclude?.Join();
        }
    }
}