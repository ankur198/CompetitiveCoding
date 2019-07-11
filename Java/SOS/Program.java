/**
 * Program
 */
public class Program {

    public static void main(String[] args) {
        Driver driver = new Driver(5, new int[]{1,2,3,4,5});

        for (Integer[] subset : driver.GetSubset()) {
            for (Integer item : subset) {
                System.out.print(item.toString()+", ");
            }
            System.out.println();
        }
    }
}