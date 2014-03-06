package algorithms;

import static algorithms.HelperMethods.*;

public class Insertion {

    public static void sort(Comparable[] a) {
        printArr(a);
        int N = a.length;
        for (int i = 0; i < N; i++) {
            for (int j = i; j > 0; j--) {
                if (less(a[j],a[j-1])) {
                    exch(a, j, j - 1);
                    printArr(a);
                }
                else {
                    break;
                }
            }
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
