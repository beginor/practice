using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Algorithms {

    public static class StdOut {

        public static void WriteLine<T>(T[] array) {
            var s = new StringBuilder();
            foreach (var t in array) {
                s.AppendFormat("{0} ", t);
            }
            Console.WriteLine(s);
        }

        public static void WriteLine(IEnumerable enumerable) {
            var s = new StringBuilder();
            foreach (var o in enumerable) {
                s.AppendFormat("{0} ", o);
            }
            Console.Out.WriteLine(s.ToString(0, s.Length - 1));
        }

        public static void WriteLine(string format, params object[] args) {
            Console.WriteLine(format, args);
        }
    }
}