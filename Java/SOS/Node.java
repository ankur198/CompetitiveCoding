import java.util.ArrayList;
import java.util.List;

/**
 * Node
 */
public class Node {

    public List<Integer> CurrentSubset;
    public int Index;
    public int Sum;

    public Node CreateChildNode() {
        Node child = new Node();
        child.CurrentSubset = new ArrayList<Integer>(CurrentSubset);
        child.Index = Index + 1;
        child.Sum = Sum;
        return child;
    }

    public Node CreateChildNode(int Element) {
        Node child = CreateChildNode();
        child.CurrentSubset.add(Element);
        child.Sum += Element;
        return child;
    }
}