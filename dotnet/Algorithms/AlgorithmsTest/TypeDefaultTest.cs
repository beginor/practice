using System;
using NUnit.Framework;

namespace AlgorithmsTest {

    [TestFixture]
    public class TypeDefaultTest {

        [Test]
        public void Test1() {
            Console.WriteLine("default(int) = {0}", default(int));
            Console.WriteLine("default(float) = {0}", default(float));
            Console.WriteLine("default(double) = {0}", default(double));
            Console.WriteLine("default(TypeDefaultTest) = {0}", default(TypeDefaultTest));
        }

        [Test]
        public void TestTuple() {
            var a = GetCategory();
        }

        private Tuple<int, string, DateTime> GetCategory() {
            return Tuple.Create(1, "Category", DateTime.Now);
        }
    }
}