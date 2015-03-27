using System;
using System.IO;
using System.Xml;
using NHibernate;
using NHibernate.Cfg;

namespace NHibernateUnitOfWork {

    public interface IUnitOfWorkFactory {

        Configuration Configuration { get; }

        ISession CurrentSession { get; set; }

        ISessionFactory SessionFactory { get; }

        IUnitOfWork Create();

        void DisposeUnitOfWork(IUnitOfWork unitOfWork);

    }

    public class UnitOfWorkFactory : IUnitOfWorkFactory {

        private const string Default_HibernateConfig = "hibernate.cfg.xml";

        private Configuration _configuration;
        private ISession _currentSession;
        private ISessionFactory _sessionFactory;

        public Configuration Configuration {
            get {
                if (_configuration == null) {
                    _configuration = new Configuration();
                    string hibernateConfig = Default_HibernateConfig;
                    if (Path.IsPathRooted(hibernateConfig) == false) {
                        if (File.Exists(hibernateConfig)) {
                            _configuration.Configure(new XmlTextReader(hibernateConfig));
                        }
                    }
                }
                return _configuration;
            }
        }

        public ISession CurrentSession {
            get {
                if (_currentSession == null) { 
                    throw new InvalidOperationException("You are not in a unit of work.");
                }
                return _currentSession;
            }
            set {
                _currentSession = value;
            }
        }

        public ISessionFactory SessionFactory {
            get {
                if (_sessionFactory == null) {
                    _sessionFactory = Configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        internal UnitOfWorkFactory() {
        }

        public IUnitOfWork Create() {
            ISession session = CreateSession();
            session.FlushMode = FlushMode.Commit;
            _currentSession = session;
            return new UnitOfWorkImplementor(this, session);
        }

        private ISession CreateSession() {
            return SessionFactory.OpenSession();
        }

        public void DisposeUnitOfWork(IUnitOfWork unitOfWork) {
            CurrentSession = null;
            UnitOfWork.DisposeUnitOfWork(unitOfWork);
        }
    }

}