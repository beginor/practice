using System;
using System.Collections;

namespace Algorithms {

    public static class Selection {

        public static void Sort<T>(T[] array) where T : IComparable {
            var n = array.Length;
            for (var i = 0; i < n; i++) {
                var min = i;
                for (var j = i + 1; j < n; j++) {
                    if (Less(array[j], array[min])) {
                        min = j;
                    }
                }
                Exch(array, i, min);
            }
        }

        public static void Sort<T>(T[] array, IComparer c) {
            var n = array.Length;
            for (var i = 0; i < n; i++) {
                var min = i;
                for (var j = i + 1; j < n; j++) {
                    if (Less(c, array[j], array[min])) {
                        min = j;
                    }
                }
                Exch(array, i, min);
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
