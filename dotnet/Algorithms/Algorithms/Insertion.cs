using System;
using System.Collections;

namespace Algorithms {

    public static class Insertion {

        public static void Sort<T>(T[] a) where T : IComparable {
            int n = a.Length;
            for (int i = 0; i < n; i++) {
                for (int j = i; j > 0; j--) {
                    if (Less(a[j], a[j - 1])) {
                        Exch(a, j, j - 1);
                    }
                    else {
                        break;
                    }
                }
            }
        }

        public static void Sort<T>(T[] a, IComparer c) {
            int n = a.Length;
            for (int i = 0; i < n; i++) {
                for (int j = i; j > 0 && Less(a[j], a[j - 1], c); j--) {
                    Exch(a, j, j - 1);
                }
            }
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