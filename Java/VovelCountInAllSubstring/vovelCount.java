import java.util.HashMap;

/**
 * vovelCount
 */
public class vovelCount {

    public static void main(String[] args) {
        System.out.println(GetVowel("abc"));
    }

    public static int GetVowel(String s) {
        int count = 0;
        s += "asd";
        char[] vowel = new char[] { 'a', 'e', 'i', 'o', 'u' };
        for (int i = 0; i < s.length() - 1; i++) {
            for (int j = i + 1; j < s.length(); j++) {
                String sub = s.substring(i, j);
                System.out.println(sub);
                for (char v : vowel) {
                    if (sub.contains(Character.toString(v))) {
                        count++;
                    }
                }
            }
        }
        return count;
    }

    static String fix(String input){
        int ones = 0;
        HashMap<String,Float>
        String[] a = new String[2];
        for (int i =0;i<input.legth() ; i++) {
            if (input.charAt(i) == '1') ones++; 
        }
        String s = "";
        for (int i =0; i<ones+1; i++) s+="1";
        for (int i=0; i<input.length()-ones; i++) s+="0";
        return s;
    }
}