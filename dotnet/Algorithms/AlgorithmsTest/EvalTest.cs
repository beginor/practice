using Algorithms;
using NUnit.Framework;

namespace AlgorithmsTest {

    [TestFixture]
    public class EvalTest {

        [Test]
        public void Test1() {
            var ops = new LinkedStack<string>();
            var vals = new LinkedStack<double>();
            var formula = "( 1 + ( ( 2 + 3 ) * ( 4 * 5 ) ) )".Split(' ');
            foreach (var s in formula) {
                if (s.Equals("(")) { }
                else if (s.Equals("+")) { ops.Push(s); }
                else if (s.Equals("*")) {  ops.Push(s); }
                else if (s.Equals(")")) {
                    var op = ops.Pop();
                    if (op.Equals("+")) {
                        vals.Push(vals.Pop() + vals.Pop());
                    }
                    if (op.Equals("*")) {
                        vals.Push(vals.Pop() * vals.Pop());
                    }
                }
                else {
                    vals.Push(double.Parse(s));
                }
            }
            Assert.AreEqual(101d, vals.Pop());
        }
    }
}