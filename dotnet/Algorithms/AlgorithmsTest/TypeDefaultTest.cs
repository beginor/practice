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
    }
}