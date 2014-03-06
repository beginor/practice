package algorithms;

import static algorithms.HelperMethods.*;

public class Selection {

    public static void sort(Comparable[] a) {
        int N = a.length;
        for (int i = 0; i < N; i++) {
            int min = i;
            for (int j = i + 1; j < N; j++) {
                if (less(a[j], a[min])) {
                    min = j;
                }
            }
            exch(a, i, min);
            printArr(a);
        }
    }

    public static void main(String[] args) {
        int N = 10;
        Integer[] a = generateRandomArray(N, 100);
        printArr(a);
        sort(a);
        printArr(a);
    }
}
