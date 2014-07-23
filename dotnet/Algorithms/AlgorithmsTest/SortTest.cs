using Algorithms;
using NUnit.Framework;

namespace AlgorithmsTest {

    [TestFixture]
    public class SortTest {

        [Test]
        public void TestSelectionSort() {
            var a = new int[10];
            for (int i = 0; i < a.Length; i++) {
                a[i] = StdRandom.Uniform(10);
            }
            StdOut.WriteLine(a);
            Selection<int>.Sort(a);
            StdOut.WriteLine(a);
        }

        [Test]
        public void TestInsertionSort() {
            var a = new int[10];
            for (int i = 0; i < a.Length; i++) {
                a[i] = StdRandom.Uniform(10);
            }
            StdOut.WriteLine(a);
            Insertion<int>.Sort(a);
            StdOut.WriteLine(a);
        }

        [Test]
        public void TestShellSort() {
            var a = new int[10];
            for (int i = 0; i < a.Length; i++) {
                a[i] = StdRandom.Uniform(10);
            }
            StdOut.WriteLine(a);
            Shell<int>.Sort(a);
            StdOut.WriteLine(a);
        }

        [Test]
        public void TestShuffle() {
            var a = new int[10];
            for (int i = 0; i < a.Length; i++) {
                a[i] = StdRandom.Uniform(100);
            }
            StdOut.WriteLine(a);
            StdRandom.Shuffle(a);
            StdOut.WriteLine(a);
        }

        [Test]
        public void TestNormalMergeSort() {
            var a = new int[10];
            for (int i = 0; i < a.Length; i++) {
                a[i] = StdRandom.Uniform(10);
            }
            StdOut.WriteLine(a);
            Merge<int>.Sort(a);
            StdOut.WriteLine(a);

            for (int i = 0; i < a.Length; i++) {
                a[i] = StdRandom.Uniform(10);
            }

        }

        [Test]
        public void TestBottomUpMerge() {
            var a = new int[16];
            for (int i = 0; i < a.Length; i++) {
                a[i] = StdRandom.Uniform(100);
            }
            StdOut.WriteLine(a);
            Merge<int>.SortBottomUp(a);
            StdOut.WriteLine(a);
        }

        [Test]
        public void TestQuickSort() {
            var a = new int[16];
            for (int i = 0; i < a.Length; i++) {
                a[i] = StdRandom.Uniform(100);
            }
            StdOut.WriteLine(a);
            Quick<int>.Sort(a);
            StdOut.WriteLine(a);

            var item4 = Quick<int>.Select(a, 9);
            StdOut.WriteLine("item7 = {0}", item4);
        }

        [Test]
        public void TestQuick3Sort() {
            var a = CreateRandomArray(16);
            StdOut.WriteLine(a);
            Quick3<int>.Sort(a);
            StdOut.WriteLine(a);
        }

        [Test]
        public void TestHeapSort() {
            var a = CreateRandomArray(10);
            StdOut.WriteLine(a);
            Heap<int>.Sort(a);
            StdOut.WriteLine(a);
        }

        private static int[] CreateRandomArray(int n) {
            var a = new int[n];
            for (int i = 0; i < a.Length; i++) {
                a[i] = StdRandom.Uniform(10);
            }
            return a;
        }
    }
}