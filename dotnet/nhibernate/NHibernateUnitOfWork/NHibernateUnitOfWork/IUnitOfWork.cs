using System;
using NHibernate;

namespace NHibernateUnitOfWork {

    public interface IUnitOfWork : IDisposable {
        
    }

    public class UnitOfWorkImplementor : IUnitOfWork {

        private readonly IUnitOfWorkFactory _factory;
        private readonly ISession _session;

        public UnitOfWorkImplementor(IUnitOfWorkFactory factory, ISession session) {
            _factory = factory;
            _session = session;
        }

        public void Dispose() {
            _factory.DisposeUnitOfWork(this);
            _session.Dispose();
        }
    }
}