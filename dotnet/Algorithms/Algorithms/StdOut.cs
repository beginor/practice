using System;

namespace Algorithms {

    public static class StdOut {

        public static void WriteLine<T>(T[] array) {
            for (int i = 0; i < array.Length; i++) {
                var item = array[i];
                if (i < array.Length - 1) {
                    Console.Write(item + " ");
                }
                else {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();
        }

        public static void WriteLine(string format, params object[] args) {
            Console.WriteLine(format, args);
        }
    }
}