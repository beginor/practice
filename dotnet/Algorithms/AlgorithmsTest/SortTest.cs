﻿using Algorithms;
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
    }
}