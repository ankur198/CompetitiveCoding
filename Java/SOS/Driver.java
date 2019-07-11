import java.util.ArrayList;
import java.util.List;

/**
 * Driver
 */
public class Driver {

    private int ReqSum;
    private int[] GivenArray;
    private List<Integer[]> Subset = new ArrayList<Integer[]>();

    public Driver(int Sum, int[] Array) {
        ReqSum = Sum;
        GivenArray = Array;
    }

    public List<Integer[]> GetSubset() {
        Node start = new Node();
        start.CurrentSubset = new ArrayList<Integer>();
        start.Index = 0;
        start.Sum = 0;

        FindAllSubset(start);
        return Subset;
    }

    private void FindAllSubset(Node node) {
        try {
            if (isNodeFeasible(node)) {
                Thread[] newNodesTask = new Thread[2];
                newNodesTask[0] = new Thread(() -> FindAllSubset(node.CreateChildNode()));
                newNodesTask[1] = new Thread(() -> FindAllSubset(node.CreateChildNode(GivenArray[node.Index])));

                for (Thread work : newNodesTask) {
                    work.start();
                }
                // not proper way to wait but other are ugly
                newNodesTask[0].join();
                newNodesTask[1].join();
            }

            if (isNodeCompleted(node)) {
                Subset.add((node.CurrentSubset.toArray(new Integer[node.CurrentSubset.size()])));
            }
        } catch (Exception e) {
            // Kuki ye zyada smjhaar language h
        }
    }

    private boolean isNodeFeasible(Node node) {
        return node.Sum <= ReqSum && node.Index < GivenArray.length;
    }

    private boolean isNodeCompleted(Node node) {
        return node.Sum == ReqSum;
    }
}