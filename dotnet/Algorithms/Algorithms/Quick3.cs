using System;
using System.Collections;

namespace Algorithms {


    public static class Quick3 {

        public static void Sort<T>(T[] a) where T : IComparable {
            Sort(a, 0, a.Length - 1);
        }

        public static void Sort<T>(T[] a, IComparer c) {
            Sort(a, 0, a.Length - 1, c);
        }

        private static void Sort<T>(T[] a, int lo, int hi) where T : IComparable {
            if (hi <= lo) {
                return;
            }
            int lt = lo, gt = hi;
            var v = a[lo];
            int i = lo;
            while (i <= gt) {
                int c = a[i].CompareTo(v);
                if (c < 0) {
                    Exch(a, lt++, i++);
                }
                else if (c > 0) {
                    Exch(a, i, gt--);
                }
                else {
                    i++;
                }
            }

            Sort(a, lo, lt - 1);
            Sort(a, gt + 1, hi);
        }

        private static void Sort<T>(T[] a, int lo, int hi, IComparer comp) {
            if (hi <= lo) {
                return;
            }
            int lt = lo, gt = hi;
            var v = a[lo];
            int i = lo;
            while (i <= gt) {
                int c = comp.Compare(a[i], v);
                if (c < 0) {
                    Exch(a, lt++, i++);
                }
                else if (c > 0) {
                    Exch(a, i, gt--);
                }
                else {
                    i++;
                }
            }

            Sort(a, lo, lt - 1, comp);
            Sort(a, gt + 1, hi, comp);
        }

        private static void Exch<T>(T[] a, int i, int j) {
            var tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }
    }
}