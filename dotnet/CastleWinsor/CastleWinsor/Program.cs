using System;
using System.Linq;
using Castle.Windsor;
using Castle.Windsor.Configuration;
using Castle.Windsor.Installer;

namespace CastleWinsor {

    class MainClass {

        public static void Main(string[] args) {
            IWindsorContainer container = new WindsorContainer();
            var xmlInstaller = Configuration.FromXmlFile("windsor.xml");
            container.Install(xmlInstaller);
            var log = container.Resolve<ILog>("debug");
            log.Log("Hello, Castle Windsor!");

            var logs = container.ResolveAll<ILog>();
            foreach (var l in logs) {
                l.Log("Hello, Castle Windsor!");
            }

            var controller = container.Resolve<TestController>();
            controller.DoAction();

            container.Dispose();
        }
    }

    public interface ILog {

        void Log(string message);

    }

    public class ConsoleLog : ILog {

        public void Log(string message) {
            Console.WriteLine(message);
        }

    }

    public class DebugLog : ILog {

        public void Log(string message) {
            System.Diagnostics.Debug.Print(message);
        }

    }
}
