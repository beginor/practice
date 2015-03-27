using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace NHibernateUnitOfWork {

    public static class UnitOfWork {

        private static IUnitOfWorkFactory _unitOfWorkFactory;
        private static IUnitOfWork _innerUnitOfwork;

        public static IUnitOfWork Start() {
            if (_innerUnitOfwork != null) {
                throw new InvalidOperationException("You can not start more then one unit of work at the same time.");
            }
            _innerUnitOfwork = _unitOfWorkFactory.Create();
            return _innerUnitOfwork;
        }

        public static IUnitOfWork Current {
            get {
                if (_innerUnitOfwork == null) {
                    throw new InvalidOperationException("You are not in aunit of work.");
                }
                return _innerUnitOfwork;
            }
        }

        public static bool IsStarted {
            get {
                return _innerUnitOfwork != null;
            }
        }

        public static ISession CurrentSession {
            get {
                return _unitOfWorkFactory.CurrentSession;
            }
            internal set {
                _unitOfWorkFactory.CurrentSession = value;
            }
        }

        public static void DisposeUnitOfWork(IUnitOfWork unitOfWork) {
            throw new NotImplementedException();
        }
    }
}
