using System;
using System.Collections;

namespace Algorithms {


    public static class Quick {

        public static void Sort<T>(T[] a) where T : IComparable {
            StdRandom.Shuffle(a);
            Sort(a, 0, a.Length - 1);
        }

        public static void Sort<T>(T[] a, IComparer c) {
            StdRandom.Shuffle(a);
            Sort(a, 0, a.Length - 1, c);
        }

        private static void Sort<T>(T[] a, int lo, int hi) where T : IComparable {
            if (lo >= hi) {
                return;
            }
            int j = Partition(a, lo, hi);
            Sort(a, lo, j - 1);
            Sort(a, j + 1, hi);
        }

        private static void Sort<T>(T[] a, int lo, int hi, IComparer c) {
            if (lo >= hi) {
                return;
            }
            int j = Partition(a, lo, hi, c);
            Sort(a, lo, j - 1, c);
            Sort(a, j + 1, hi, c);
        }

        private static int Partition<T>(T[] a, int lo, int hi) where T :　IComparable {
            int i = lo, j = hi + 1;
            while (true) {
                while (Less(a[++i], a[lo])) {
                    if (i == hi) {
                        break;
                    }
                }
                while (Less(a[lo], a[--j])) {
                    if (j == lo) {
                        break;
                    }
                }
                if (i >= j) {
                    break;
                }
                Exch(a, i, j);
            }
            Exch(a, lo, j);
            return j;
        }

        private static int Partition<T>(T[] a, int lo, int hi, IComparer c) {
            int i = lo, j = hi + 1;
            while (true) {
                while (Less(a[++i], a[lo], c)) {
                    if (i == hi) {
                        break;
                    }
                }
                while (Less(a[lo], a[--j], c)) {
                    if (j == lo) {
                        break;
                    }
                }
                if (i >= j) {
                    break;
                }
                Exch(a, i, j);
            }
            Exch(a, lo, j);
            return j;
        }

        public static T Select<T>(T[] a, int k) where T : IComparable {
            StdRandom.Shuffle(a);
            int lo = 0, hi = a.Length - 1;
            while (lo < hi) {
                int j = Partition(a, lo, hi);
                if (j < k) {
                    lo = j + 1;
                }
                else if (j > k) {
                    hi = j - 1;
                }
                else {
                    return a[k];
                }
            }
            return a[k];
        }

        public static T Select<T>(T[] a, int k, IComparer c) {
            StdRandom.Shuffle(a);
            int lo = 0, hi = a.Length - 1;
            while (lo < hi) {
                int j = Partition(a, lo, hi, c);
                if (j < k) {
                    lo = j + 1;
                }
                else if (j > k) {
                    hi = j - 1;
                }
                else {
                    return a[k];
                }
            }
            return a[k];
        }

        private static bool Less(IComparable v, IComparable w) {
            return v.CompareTo(w) < 0;
        }

        private static bool Less(object v, object w, IComparer c) {
            return c.Compare(v, w) < 0;
        }

        private static void Exch<T>(T[] a, int i, int j) {
            var tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }
    }
}