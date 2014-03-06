package algorithms;

import static algorithms.HelperMethods.*;

public class Merge {

    private static final int CUTOFF = 7;

    private static void merge(Comparable[] a, Comparable[] aux, int lo, int mid, int hi) {

        assert isSorted(a, lo, mid);
        assert isSorted(a, mid, hi);

        for (int k = lo; k <= hi; k++) {
            aux[k] = a[k];
        }

        int i = lo, j = mid + 1;
        for (int k = lo; k <= hi; k++) {
            if (i > mid) {
                a[k] = aux[j++];
            }
            else if (j > hi) {
                a[k] = aux[i++];
            }
            else if (less(aux[j], aux[i])) {
                a[k] = aux[j++];
            }
            else {
                a[k] = aux[i++];
            }
        }

        assert isSorted(a, lo, hi);

        printArr(a);
    }

    private static void sort(Comparable[] a, Comparable[] aux, int lo, int hi) {
        if (hi <= lo) {
            return;
        }

        /*
        if (hi <= lo + CUTOFF -1) {
            Insertion.sort(a, lo, hi);
            return;
        }
        */
        int mid = lo + (hi - lo) / 2;
        sort(a, aux, lo, mid);
        sort(a, aux, mid + 1, hi);

        if (less(a[mid + 1], a[mid])) {
            merge(a, aux, lo, mid, hi);
        }
    }

    public static void sort(Comparable[] a) {
        int N = a.length;
        Comparable[] aux = new Comparable[N];
        sort(a, aux, 0, N - 1);
    }

    public static void main(String[] args) {
        Integer[] a = generateRandomArray(100, 100);
        sort(a);
    }
}
