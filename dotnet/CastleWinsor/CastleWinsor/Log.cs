using System;
using System.Linq;
using Castle.Windsor;
using Castle.Windsor.Configuration;
using Castle.Windsor.Installer;

namespace CastleWinsor {

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
