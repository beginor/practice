using System;
using System.Linq;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using NhCfgEnv = NHibernate.Cfg.Environment;
using NHibernateTest.Data;

namespace NHibernateTest {

    class MainClass {

        public static void Main(string[] args) {
            using (var factory = BuildSessionFactory()) {
                using (var session = factory.OpenSession()) {
                    var categories = session.Query<Category>();

                    foreach (var c in categories) {
                        Console.WriteLine("{0:D2} \t {1} \t {2}", c.CategoryID, c.CategoryName, c.Description);
                    }
                }
            }
        }

        static ISessionFactory BuildSessionFactory() {
            var cfg = new Configuration();
            cfg.SetProperty(NhCfgEnv.BatchSize, "0");
            cfg.SetProperty(NhCfgEnv.ConnectionProvider, "NHibernate.Connection.DriverConnectionProvider");
            cfg.SetProperty(NhCfgEnv.ConnectionDriver, "NHibernate.Driver.SqlClientDriver");
            cfg.SetProperty(NhCfgEnv.Dialect, "NHibernate.Dialect.MsSql2005Dialect");
            cfg.SetProperty(NhCfgEnv.ProxyFactoryFactoryClass, "NHibernate.Bytecode.DefaultProxyFactoryFactory, NHibernate");
            cfg.SetProperty(NhCfgEnv.FormatSql, bool.FalseString);
            cfg.SetProperty(NhCfgEnv.ShowSql, bool.TrueString);
            cfg.SetProperty(NhCfgEnv.ConnectionString, "Data Source=172.21.24.145;Initial Catalog=Northwind;User Id=udev;Password=devdev;Connect Timeout=15;");
            cfg.AddAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            return cfg.BuildSessionFactory();
        }
    }
}
