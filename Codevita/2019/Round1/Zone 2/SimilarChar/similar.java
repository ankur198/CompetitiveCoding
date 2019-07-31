import java.util.Scanner;

public class similar {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int L = Integer.parseInt(sc.nextLine());
        String s = sc.nextLine();
        int Q = sc.nextInt();

        int[] res = new int[Q];

        for (int i = 0; i < Q; i++) {
            int index = sc.nextInt();
            char ch = s.charAt(index - 1);
            int count = 0;

            for (int j = 0; j < index - 1; j++) {
                if (s.charAt(j) == ch) {
                    count++;
                }
            }
            res[i] = count;
        }
        sc.close();
        for (int i = 0; i < Q-1; i++) {
            System.out.println(res[i]);
        }
        System.out.print(res[Q-1]);
    }
}