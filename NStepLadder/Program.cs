using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NStepLadder
{
    //internal class NStepLadder
    //{
    //    private readonly int[] Climbs; //this stores x

    //    private List<int[]> PossibleWays = new List<int[]>();
    //    private int Sum;

    //    public NStepLadder(int[] climbs, int sum)
    //    {
    //        Climbs = climbs;
    //        Sum = sum;
    //    }

    //    private bool CanMakeToN(int sum)
    //    {
    //        return SumOfSubset.isSumOfSubset(Climbs.ToArray(), Sum);
    //    }

    //    private void Node(List<int> stepsTaken)
    //    {

    //    }
    //}



    internal class SumOfSubset
    {
        private int Sum;
        private int[] Set;
        private int counter = 0;

        private struct NodeData
        {
            internal int CurrentSum;
            internal int index;
            internal List<int> path;
        }

        private List<NodeData> possibleCombinationOfNodes = new List<NodeData>();

        public static int isSumOfSubset(int[] array, int sum)
        {
            var x = new SumOfSubset();
            x.Sum = sum;
            x.Set = array;
            var node = new NodeData() { CurrentSum = 0, index = 0, path = new List<int>() };
            x.Node(node);
            return x.counter;
        }

        private void Node(NodeData node)
        {
            Console.WriteLine($"{node.CurrentSum} {node.index} {node.path.ToArray()}");

            //failed
            if (node.CurrentSum > Sum)
            {
                return;
            }
            //pass condition
            if (node.CurrentSum == Sum)
            {
                counter++;
                return;
            }

            possibleCombinationOfNodes.Add(node);


            //make branch
            if (node.index + 1 < Set.Length)
            {
                var nodeInc = new NodeData()
                {
                    CurrentSum = node.CurrentSum + Set[node.index],
                    index = node.index + 1,
                    path = node.path.ToList()
                };
                nodeInc.path.Add(node.index);


                var nodeExc = new NodeData()
                {
                    CurrentSum = node.CurrentSum,
                    index = node.index + 1,
                    path = node.path.ToList()
                };

                Node(nodeInc); //include
                Node(nodeExc); //exclude 
            }

            //this branch to check recursively
            var nodeIncR = new NodeData()
            {
                CurrentSum = node.CurrentSum + Set[node.index],
                index = 0,
                path = node.path.ToList()
            };
            nodeIncR.path.Add(node.index);


            var nodeExcR = new NodeData()
            {
                CurrentSum = node.CurrentSum,
                index = 0,
                path = node.path.ToList()
            };

            CallRecursive(nodeIncR);
            CallRecursive(nodeExcR);

        }

        private void CallRecursive(NodeData nodeData)
        {
            var c = possibleCombinationOfNodes.Where(x => x.CurrentSum == nodeData.CurrentSum && x.index == nodeData.index && x.path.ToArray() == nodeData.path.ToArray()).Count();
            if (c == 0)
            {
                Node(nodeData);
            }
        }
    }
}
