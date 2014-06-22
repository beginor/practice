using System;

namespace Algorithms {

    public static class StdRandom {
         
        private static Random random = new Random((int)Seed);
        private static double seed = DateTime.Now.Millisecond;

        public static double Seed {
            get {
                return seed;
            }
            set {
                seed = value;
                random = new Random((int)Seed);
            }
        }

        public static double Uniform() {
            return random.NextDouble();
        }

        public static int Uniform(int n) {
            if (n <= 0) {
                throw new ArgumentException("Parameter N must be positive");
            }
            return random.Next(n);
        }

        public static double Random() {
            return Uniform();
        }

        public static int Uniform(int a, int b) {
            if (b <= a) {
                throw new ArgumentException("Invalid range");
            }
            if ((long)b - a >= int.MaxValue) {
                throw new ArgumentException("Invalid range");
            }
            return a + Uniform(b - a);
        }

        public static double Uniform(double a, double b) {
            if (b <= a) {
                throw new ArgumentException("Invalid range");
            }
            return a + Uniform() * (b - a);
        }

        public static void Shuffle<T>(T[] a) {
            int n = a.Length;
            for (int i = 0; i < n; i++) {
                int r = i + Uniform(n - i);
                T tmp = a[i];
                a[i] = a[r];
                a[r] = tmp;
            }
        }
    }
}