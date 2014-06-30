using System;
using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Algorithms {

    public static class Merge {

        public static void Sort<T>(T[] a) where T : IComparable {
            var aux = new T[a.Length];
            for (int i = 0; i < a.Length; i++) {
                aux[i] = a[i];
            }
            Sort(a, aux, 0, a.Length - 1);
        }

        public static void Sort<T>(T[] a, IComparer c) {
            var aux = new T[a.Length];
            Sort(a, aux, 0, a.Length - 1, c);
        }

        private static void Sort<T>(T[] a, T[] aux, int lo, int hi) where T : IComparable {
            if (hi <= lo) {
                return;
            }
            int mid = (lo + hi) / 2;
            Sort(a, aux, lo, mid);
            Sort(a, aux, mid + 1, hi);
            MergeArray(a, aux, lo, mid, hi);
        }

        private static void Sort<T>(T[] a, T[] aux, int lo, int hi, IComparer c) {
            if (hi <= lo) {
                return;
            }
            int mid = (lo + hi) / 2;
            Sort(a, aux, lo, mid, c);
            Sort(a, aux, mid + 1, hi, c);
            MergeArray(a, aux, lo, mid, hi, c);
        }

        private static void MergeArray<T>(T[] a, T[] aux, int lo, int mid, int hi) where T : IComparable {
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

        private static void MergeArray<T>(T[] a, T[] aux, int lo, int mid, int hi, IComparer c) {
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

        public static void SortBU<T>(T[] a) where T : IComparable {
            int N = a.Length;
            T[] aux = new T[N];
            for (int n = 1; n < N; n = n + n) {
                for (int i = 0; i < N - n; i += n + n) {
                    int lo = i;
                    int mid = i + n - 1;
                    int hi = Math.Min(i + n + n - 1, N - 1);
                    MergeArray(a, aux, lo, mid, hi);
                }
            }
            Debug.Assert(IsSorted(a));
        }

        private static bool IsSorted<T>(T[] a) where T : IComparable {
            return IsSorted(a, 0, a.Length - 1);
        }

        private static bool IsSorted<T>(T[] a, int lo, int hi) where T : IComparable {
            for (var i = lo; i < hi; i++) {
                if (!Less(a[i], a[i + 1])) {
                    return false;
                }
            }
            return true;
        }

        private static bool IsSorted<T>(T[] a, int lo, int hi, IComparer c) {
            for (var i = lo; i < hi; i++) {
                if (!Less(a[i], a[i + 1], c)) {
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