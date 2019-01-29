using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
            var goodNodes = x.possibleCombinationOfNodes.Where(y => y.CurrentSum == x.Sum).ToList();
            var goodPaths = new List<string>();

            foreach (var item in goodNodes)
            {
                goodPaths.Add(x.ArrayToString(item.path.ToArray()));
            }

            var uniquegoodPath = goodPaths.Distinct();
            foreach (var item in uniquegoodPath)
            {
                System.Console.WriteLine(item);
            }


            return uniquegoodPath.Count();
        }

        private void Node(NodeData node)
        {
            //Console.WriteLine($"{node.CurrentSum} {node.index} - {ArrayToString(node.path.ToArray())}");
            possibleCombinationOfNodes.Add(node);

            if (CheckFeasability(node) == false)
            {
                return;
            }


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

                MakeBranchThread(nodeInc); //include
                MakeBranchThread(nodeExc); //exclude 
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

        private void MakeBranchThread(NodeData node)
        {
            var t = new Thread(() =>
            {
                Node(node);
            });
            t.Start();
            t.Join();

        }

        private bool CheckFeasability(NodeData node)
        {
            //failed
            if (node.CurrentSum > Sum)
            {
                return false;
            }
            //pass condition
            if (node.CurrentSum == Sum)
            {
                counter++;
                return false;
            }
            return true;
        }

        private void CallRecursive(NodeData nodeData)
        {
            var c = possibleCombinationOfNodes.Where(x =>
            x.CurrentSum == nodeData.CurrentSum &&
              x.index == nodeData.index &&
              ArrayToString(x.path.ToArray()) == ArrayToString(nodeData.path.ToArray())).Count();
            if (c == 0)
            {
                MakeBranchThread(nodeData);
            }
        }

        private string ArrayToString(int[] arr)
        {
            var s = "";
            foreach (var item in arr)
            {
                s += Set[item].ToString() + ",";
            }
            s.TrimEnd(',');
            return s;
        }
    }
}
