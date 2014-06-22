using System;
using Algorithms;
using NUnit.Framework;

namespace AlgorithmsTest {

    [TestFixture]
    public class LinkedTest {

        [Test]
        public void TestLinkedBag() {
            var bag = new LinkedBag<string> {
                "Hello",
                "World",
                "how",
                "are",
                "you"
            };
            foreach (var item in bag) {
                Console.WriteLine(item);
            }
        }

        [Test]
        public void TestLinkedQueue() {
            var queue = new LinkedQueue<string>();
            queue.Enqueue("Hello");
            queue.Enqueue("World");
            queue.Enqueue("how");
            queue.Enqueue("are");
            queue.Enqueue("you");
            foreach (var item in queue) {
                Console.WriteLine(item);
            }
        }

        [Test]
        public void TestLinkedStack() {
            var stack = new LinkedStack<string>();
            stack.Push("Hello");
            stack.Push("World");
            stack.Push("how");
            stack.Push("are");
            stack.Push("you");
            foreach (var item in stack) {
                Console.WriteLine(item);
            }
        }
    }
}