using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NUnit.Framework;
using Rhino.Mocks;

namespace NHibernateUnitOfWork.Test {

    [TestFixture]
    public class UnitOfWork_Fixture {

        private readonly MockRepository _mocks = new MockRepository();
        private IUnitOfWorkFactory _factory;
        private IUnitOfWork _unitOfWork;
        private ISession _session;

        [SetUp]
        public void SetupContext() {
            _factory = _mocks.DynamicMock<IUnitOfWorkFactory>();
            _unitOfWork = _mocks.DynamicMock<IUnitOfWork>();
            _session = _mocks.DynamicMock<ISession>();

            var fieldInfo = typeof(UnitOfWork).GetField("_unitOfWorkFactory",
                BindingFlags.Static | BindingFlags.SetField | BindingFlags.NonPublic);
            fieldInfo.SetValue(null, _factory);

            _mocks.BackToRecordAll();
            SetupResult.For(_factory.Create()).Return(_unitOfWork);
            SetupResult.For(_factory.CurrentSession).Return(_session);
            _mocks.ReplayAll();
        }

        [TearDown]
        public void TearDownContext() {
            _mocks.VerifyAll();

            var fieldInfo = typeof(UnitOfWork).GetField("_innerUnitOfwork",
                BindingFlags.Static | BindingFlags.SetField | BindingFlags.NonPublic);
            fieldInfo.SetValue(null, null);
        }

        [Test]
        public void Starting_UnitOfWork_if_already_started_throws() {
            UnitOfWork.Start();
            try {
                UnitOfWork.Start();
            }
            catch (InvalidOperationException ex) {
                
            }
        }

        [Test]
        public void Can_access_current_unit_of_work() {
            var uow = UnitOfWork.Start();
            var current = UnitOfWork.Current;
            Assert.AreSame(uow, current);
        }

        [Test]
        public void Accessing_current_UnitOfWork_if_not_started_throws() {
            try {
                var current = UnitOfWork.Current;
            }
            catch (InvalidOperationException ex) { }
        }

        [Test]
        public void Can_test_if_UnitOfWork_Is_Started() {
            Assert.IsFalse(UnitOfWork.IsStarted);
            IUnitOfWork uow = UnitOfWork.Start();
            Assert.IsTrue(UnitOfWork.IsStarted);
        }

        [Test]
        public void Can_get_valid_current_session_if_UoW_is_started() {
            using (UnitOfWork.Start()) {
                ISession session = UnitOfWork.CurrentSession;
                Assert.IsNotNull(session);
            }
        }
    }
}
