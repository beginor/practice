using System;
using System.Collections;

namespace Algorithms {

    public class Shell {

        public static void Sort<T>(T[] a) where T : IComparable {
            int n = a.Length;
            int h = 1;
            while (h < n / 3) {
                h = 3 * h + 1;
            }

            while (h >= 1) {
                for (int i = h; i < n; i++) {
                    for (int j = i; j >= h && Less(a[j], a[j - h]); j -= h) {
                        Exch(a, j, j - h);
                    }
                }
                h /= 3;
            }
        }

        public static void Sort<T>(T[] a, IComparer c) {
            int n = a.Length;
            int h = 1;
            while (h < n / 3) {
                h = 3 * h + 1;
            }

            while (h >= 1) {
                for (int i = h; i < n; i++) {
                    for (int j = i; j >= h; j -= h) {
                        if (Less(c, a[j], a[j - 1])) {
                            Exch(a, j, j - h);
                            break;
                        }
                    }
                }
                h /= 3;
            }
        }

        private static bool Less(IComparable v, IComparable w) {
            return v.CompareTo(w) < 0;
        }

        private static bool Less(IComparer c, object v, object w) {
            return c.Compare(v, w) < 0;
        }

        private static void Exch<T>(T[] a, int i, int j) {
            var tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }
    }
}