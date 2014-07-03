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
            Selection.Sort(a);
            StdOut.WriteLine(a);
        }

        [Test]
        public void TestInsertionSort() {
            var a = new int[10];
            for (int i = 0; i < a.Length; i++) {
                a[i] = StdRandom.Uniform(10);
            }
            StdOut.WriteLine(a);
            Insertion.Sort(a);
            StdOut.WriteLine(a);
        }

        [Test]
        public void TestShellSort() {
            var a = new int[10];
            for (int i = 0; i < a.Length; i++) {
                a[i] = StdRandom.Uniform(10);
            }
            StdOut.WriteLine(a);
            Shell.Sort(a);
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
            Merge.Sort(a);
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
            Merge.SortBU(a);
            StdOut.WriteLine(a);
        }

        [Test]
        public void TestQuickSort() {
            var a = new int[16];
            for (int i = 0; i < a.Length; i++) {
                a[i] = StdRandom.Uniform(100);
            }
            StdOut.WriteLine(a);
            Quick.Sort(a);
            StdOut.WriteLine(a);

            var item4 = Quick.Select(a, 9);
            StdOut.WriteLine("item7 = {0}", item4);
        }
    }
}