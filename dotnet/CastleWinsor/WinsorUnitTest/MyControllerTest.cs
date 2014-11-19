using CastleWinsor;
using NUnit.Framework;

namespace WinsorUnitTest {

    [TestFixture]
    public class MyControllerTest : WindsorTest<MyController> {

        [Test]
        public void TestDoAction() {
            Target.DoAction();
        }

        [Test]
        public void TestDatabase() {
            Assert.IsNotNull(Target.Database);
        }
    }
}
