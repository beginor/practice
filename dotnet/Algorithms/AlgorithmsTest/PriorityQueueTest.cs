using System;
using NUnit.Framework;
using Algorithms;

namespace AlgorithmsTest {

    [TestFixture]
    public class PriorityQueueTest {
    
        [Test]
        public void TestMinPQ() {
            var arr = CreateRandomArray(10);
            Insertion<int>.Sort(arr);
            StdOut.WriteLine(arr);

            var pq = new MinPQ<int>();
            foreach (int i in arr) {
                pq.Insert(i);
            }

            while (!pq.IsEmpty) {
                StdOut.WriteLine("delete min: {0}", pq.DelMin());
            }
        }

        [Test]
        public void TestMaxPQ() {
            var arr = CreateRandomArray(10);
            Insertion<int>.Sort(arr);
            StdOut.WriteLine(arr);

            var pq = new MaxPQ<int>();
            foreach (int i in arr) {
                pq.Insert(i);
            }

            while (!pq.IsEmpty) {
                StdOut.WriteLine("delete max: {0}", pq.DelMax());
            }
        }

        private static int[] CreateRandomArray(int n) {
            var a = new int[n];
            for (int i = 0; i < a.Length; i++) {
                a[i] = StdRandom.Uniform(100);
            }
            return a;
        }
    }
}

