using System;
using Algorithms;
using NUnit.Framework;

namespace AlgorithmsTest {

    [TestFixture]
    public class BstTest {

        [Test]
        public void TestBst() {
            var bst = new BST<string, string>();
            bst.Put("A", "A");
            bst.Put("B", "B");
            bst.Put("C", "C");
            bst.Put("D", "D");
            bst.Put("E", "E");
            bst.Put("F", "F");
            bst.Put("G", "G");
            bst.Put("H", "H");
            bst.Put("I", "I");
            bst.Put("J", "J");

            Assert.IsFalse(bst.IsEmpty);
            Assert.AreEqual(10, bst.Count);
            Assert.AreEqual(9, bst.Height);

            StdOut.WriteLine(bst.LevelOrder());
        }

        [Test]
        public void TestRedBlackBst() {
            var bst = new RedBlackBST<string, string>();
            bst.Put("A", "A");
            bst.Put("B", "B");
            bst.Put("C", "C");
            bst.Put("D", "D");
            bst.Put("E", "E");
            bst.Put("F", "F");
            bst.Put("G", "G");
            bst.Put("H", "H");
            bst.Put("I", "I");
            bst.Put("J", "J");

            Assert.IsFalse(bst.IsEmpty);
            Assert.AreEqual(10, bst.Count);
            Assert.AreEqual(3, bst.Height);

            StdOut.WriteLine(bst.LevelOrder());

            //bst.DeleteMax();
            //StdOut.WriteLine(bst.LevelOrder());

            while (bst.Count > 1) {
                bst.DeleteMin();
                StdOut.WriteLine(bst.LevelOrder()); 
            }

            bst.DeleteMin();
        }
    }
}