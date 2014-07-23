using System;

namespace Algorithms {

    public static class Heap<T> where T : IComparable {

        public static void Sort(T[] a) {
            var n = a.Length;
            for (var k = n / 2; k >= 1; k--) {
                Sink(a, k, n);
            }
            while (n > 1) {
                Exch(a, 1, n--);
                Sink(a, 1, n);
            }
        }

        private static void Sink(T[] a, int k, int n) {
            while (k * 2 <= n) {
                int j = k * 2;
                if (j < n && Less(a, j, j + 1)) {
                    j++;
                }
                if (!Less(a, k, j)) {
                    break;
                }
                Exch(a, k, j);
                k = j;
            }
        }

        private static bool Less(T[] a, int i, int j) {
            return a[i - 1].CompareTo(a[j - 1]) < 0;
        }

        private static void Exch(T[] a, int i, int j) {
            var tmp = a[i - 1];
            a[i - 1] = a[j - 1];
            a[j - 1] = tmp;
        }
    }
}