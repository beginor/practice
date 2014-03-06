package algorithms;

import java.util.Arrays;

/**
 * Created by beginor on 13-11-20.
 */
public class ThreeSum {

    public static int count(int[] a) {
        int n = a.length;
        int count = 0;
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                Arrays.sort(a);
                if (BinarySearch.search(a, -a[i] - a[j]) > -1) {
                    count++;
                }
            }
        }
        return count;
    }

    public static void main(String[] args) {
        int[] a = {30, -40, -20, -10, 40, 0, 10, 5};
        int c = count(a);
        System.out.println(c);
    }
}
