using System;
using System.Collections;
using System.Diagnostics;

namespace Algorithms {

    public static class Merge<T> where T : IComparable {

        public static void Sort(T[] a) {
            var aux = new T[a.Length];
            for (int i = 0; i < a.Length; i++) {
                aux[i] = a[i];
            }
            Sort(a, aux, 0, a.Length - 1);
        }

        public static void Sort(T[] a, IComparer c) {
            var aux = new T[a.Length];
            Sort(a, aux, 0, a.Length - 1, c);
        }

        private static void Sort(T[] a, T[] aux, int lo, int hi) {
            if (hi <= lo) {
                return;
            }
            int mid = (lo + hi) / 2;
            Sort(a, aux, lo, mid);
            Sort(a, aux, mid + 1, hi);
            MergeArray(a, aux, lo, mid, hi);
        }

        private static void Sort(T[] a, T[] aux, int lo, int hi, IComparer c) {
            if (hi <= lo) {
                return;
            }
            int mid = (lo + hi) / 2;
            Sort(a, aux, lo, mid, c);
            Sort(a, aux, mid + 1, hi, c);
            MergeArray(a, aux, lo, mid, hi, c);
        }

        private static void MergeArray(T[] a, T[] aux, int lo, int mid, int hi) {
            Debug.Assert(IsSorted(a, lo, mid));
            Debug.Assert(IsSorted(a, mid + 1, hi));

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
                else if (Less(aux[j], aux[i])) {
                    a[k] = aux[j++];
                }
                else {
                    a[k] = aux[i++];
                }
            }
            Debug.Assert(IsSorted(a, lo, hi));
        }

        private static void MergeArray(T[] a, T[] aux, int lo, int mid, int hi, IComparer c) {
            Debug.Assert(IsSorted(a, lo, mid, c));
            Debug.Assert(IsSorted(a, mid + 1, hi, c));

            for (var k = lo; k <= hi; k++) {
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
                else if (Less(aux[j], aux[i], c)) {
                    a[k] = aux[j++];
                }
                else {
                    a[k] = aux[i++];
                }
            }
            Debug.Assert(IsSorted(a, lo, hi, c));
        }

        public static void SortBottomUp(T[] a) {
            int length = a.Length;
            T[] aux = new T[length];
            for (int n = 1; n < length; n = n + n) {
                for (int i = 0; i < length - n; i += n + n) {
                    int lo = i;
                    int mid = i + n - 1;
                    int hi = Math.Min(i + n + n - 1, length - 1);
                    MergeArray(a, aux, lo, mid, hi);
                }
            }
            Debug.Assert(IsSorted(a));
        }

        private static bool IsSorted(T[] a) {
            return IsSorted(a, 0, a.Length - 1);
        }

        private static bool IsSorted(T[] a, int lo, int hi) {
            for (var i = lo + 1; i <= hi; i++) {
                if (Less(a[i], a[i - 1])) {
                    return false;
                }
            }
            return true;
        }

        private static bool IsSorted(T[] a, int lo, int hi, IComparer c) {
            for (var i = lo + 1; i <= hi; i++) {
                if (Less(a[i], a[i - 1], c)) {
                    return false;
                }
            }
            return true;
        }

        private static bool Less(IComparable v, IComparable w) {
            return v.CompareTo(w) < 0;
        }

        private static bool Less(object v, object w, IComparer c) {
            return c.Compare(v, w) < 0;
        }
    }
}