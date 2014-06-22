using System;
using Algorithms;
using NUnit.Framework;

namespace AlgorithmsTest {

    [TestFixture]
    public class ResizingArrayTest {

        [Test]
        public void TestResizingArrayBag() {
            var bag = new ResizingArrayBag<string> {
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
        public void TestResizingArrayQueue() {
            var queue = new ResizingArrayQueue<string>();
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
        public void TestResizingStack() {
            var stack = new ResizingArrayStack<string>();
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