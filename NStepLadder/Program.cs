using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NStepLadder
{
    internal class NStepLadder
    {
        private int Sum;
        private int[] Set;
        public NStepLadder(int[] set, int sum)
        {
            Sum = sum;
            Set = set;
        }

        private struct NodeData
        {
            internal int CurrentSum;
            internal int index;
            internal List<int> path;

            internal bool Compare(NodeData node) =>
                ArrayToString(this.path) == ArrayToString(node.path) &&
                this.index == node.index;
        }

        private List<NodeData> TravelledCombination = new List<NodeData>();

        public static int PossiblePaths(int[] array, int sum)
        {
            var x = new NStepLadder(array, sum);

            //start calculation
            x.StartNStep();
            //caluclation ended

            return x.GetCombination().Count();
        }

        public IEnumerable<string> GetCombination()
        {
            var goodPaths = new List<string>();

            foreach (var item in TravelledCombination.Where(y => y.CurrentSum == Sum))
            {
                goodPaths.Add(ArrayToString(item.path, Set));
            }

            //because index can be different so we have to refilter
            //should work without distint if lock enabled below
            var uniquegoodPath = goodPaths.Distinct();

            PrintCombinations();

            return uniquegoodPath;

            void PrintCombinations()
            {
                foreach (var item in uniquegoodPath)
                {
                    System.Console.WriteLine(item);
                }
            }
        }

        public void StartNStep()
        {
            //initial node
            var node = new NodeData() { CurrentSum = 0, index = 0, path = new List<int>() };
            NewBranch(node);
        }

        private void Node(NodeData node)
        {
            if (CheckFeasability(node) == false)
            {
                return;
            }
            MakeBranches(node);
        }

        private void MakeBranches(NodeData node)
        {
            MakeForwardBranch(node);
            MakeBranchFromZero(node);
        }

        private void MakeBranchFromZero(NodeData node)
        {
            //this branch to start from index zero
            var nodeZero = new NodeData()
            {
                CurrentSum = node.CurrentSum + Set[node.index], //include
                index = 0,
                path = node.path.ToList()
            };
            nodeZero.path.Add(node.index);

            NewBranch(nodeZero);
        }

        private void MakeForwardBranch(NodeData node)
        {
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

                NewBranch(nodeInc);
                NewBranch(nodeExc);
            }
        }

        private void NewBranch(NodeData node)
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
            //already travelled
            if (isNodeExecuted(node))
            {
                return false;
            }

            //Console.WriteLine($"{node.CurrentSum} {node.index} - {ArrayToString(node.path.ToArray())}");
            TravelledCombination.Add(node);

            //fail condition
            if (node.CurrentSum > Sum)
            {
                return false;
            }

            //pass condition
            if (node.CurrentSum == Sum)
            {
                return false;
            }
            return true;
        }

        private bool isNodeExecuted(NodeData node)
        {
            var c = TravelledCombination.Where(x => x.Compare(node));
            if (c.Count() > 0)
            {
                //if combination found
                return true;
            }
            return false;
        }

        private static string ArrayToString(IEnumerable<int> arr, int[] set = null)
        {
            var s = "";
            foreach (var item in arr)
            {
                s += (set != null ? set[item] : item) + ",";
            }
            s = s.TrimEnd(',');
            return s;
        }
    }
}
