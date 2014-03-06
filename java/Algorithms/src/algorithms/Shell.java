package algorithms;

import static algorithms.HelperMethods.*;

/**
 * shell sort.
 * Created by beginor on 13-11-29.
 */
public class Shell {

    public static void sort(Comparable[] a) {
        printArr(a);
        int N = a.length;

        int h = 1;
        while (h < N / 3) {
            h = 3 * h + 1;
        }

        while (h >= 1) {
            for (int i = h; i < N; i++) {
                for (int j = i; j >= h && less(a[j],a[j-h]); j -= h) {
                    exch(a, j, j - h);
                    printArr(a);
                }
            }
            h = h / 3;
        }

    }

    public static void main(String[] args) {
        int N = 10;
        Integer[] a = generateRandomArray(N, 100);
        //printArr(a);
        sort(a);
        //printArr(a);
    }
}
