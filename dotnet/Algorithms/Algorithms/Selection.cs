﻿using System;
using System.Collections;

namespace Algorithms {

    public static class Selection<T> where T : IComparable {

        public static void Sort(T[] array) {
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

        public static void Sort(T[] array, IComparer c) {
            var n = array.Length;
            for (var i = 0; i < n; i++) {
                var min = i;
                for (var j = i + 1; j < n; j++) {
                    if (Less(array[j], array[min], c)) {
                        min = j;
                    }
                }
                Exch(array, i, min);
            }
        }

        private static bool Less(IComparable v, IComparable w) {
            return v.CompareTo(w) < 0;
        }

        private static bool Less(object v, object w, IComparer c) {
            return c.Compare(v, w) < 0;
        }

        private static void Exch(T[] a, int i, int j) {
            var tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }
    }
}
