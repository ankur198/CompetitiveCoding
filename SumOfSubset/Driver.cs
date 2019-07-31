using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SumOfSubset
{
    class Driver
    {
        int ReqSum;
        int[] GivenArray;
        List<int[]> Subset = new List<int[]>();

        public Driver(int Sum, int[] Array)
        {
            ReqSum = Sum;
            GivenArray = Array;
        }

        public async Task<List<int[]>> GetSubset()
        {
            await FindAllSubset(new Node() { CurrentSubset = new List<int>(), Index = 0 });
            return Subset;
        }

        private Task FindAllSubset(Node Node)
        {
            return Task.Factory.StartNew(() =>
            {
                if (isNodeFeasible(Node))
                {
                    Task[] newNodesTask = new Task[2];
                    newNodesTask[0] = FindAllSubset(Node.CreateChildNode(null));
                    newNodesTask[1] = FindAllSubset(Node.CreateChildNode(GivenArray[Node.Index]));

                    Task.WaitAll(newNodesTask);
                }
                if (isNodeCompleted(Node))
                {
                    Subset.Add(Node.CurrentSubset.ToArray());
                }
            });

        }

        bool isNodeFeasible(Node node) => node.CurrentSubset.Sum() <= ReqSum && node.Index < GivenArray.Length;

        bool isNodeCompleted(Node node) => node.CurrentSubset.Sum() == ReqSum;
    }
}
