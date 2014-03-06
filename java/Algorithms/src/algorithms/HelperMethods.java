package algorithms;

import stdlib.StdOut;
import stdlib.StdRandom;

public final class HelperMethods {

    public static boolean less(Comparable v, Comparable w) {
        return v.compareTo(w) < 0;
    }

    public static void printArr(Comparable[] a) {
        int N = a.length;
        for (int i = 0; i < N; i++) {
            StdOut.print(a[i]);
            if (i < N - 1) {
                StdOut.print(" ");
            }
        }
        StdOut.println();
    }

    public static boolean isSorted(Comparable[] a, int start, int end) {
        boolean result = true;
        return result;
    }

    public static void exch(Comparable[] a, int i, int j) {
        Comparable swap = a[i];
        a[i] = a[j];
        a[j] = swap;
    }

    public static Integer[] generateRandomArray(int count, int seed) {
        Integer[] result = new Integer[count];
        for (int i = 0; i < count; i++) {
            result[i] = StdRandom.uniform(seed);
        }
        return result;
    }
}
