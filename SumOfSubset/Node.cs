using System.Collections.Generic;

namespace SumOfSubset
{
    class Node
    {
        public int Index { get; set; }
        public List<int> CurrentSubset { get; set; }

        public Node CreateChildNode(int? Element)
        {
            var child = new Node() { Index = this.Index + 1, CurrentSubset = new List<int>(this.CurrentSubset) };
            if (Element.HasValue)
            {
                child.CurrentSubset.Add(Element.Value);
            }
            return child;
        }
    }
}
