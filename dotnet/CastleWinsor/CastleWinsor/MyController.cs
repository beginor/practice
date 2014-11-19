using System;

namespace CastleWinsor {

    public class MyController {

        readonly ILog log;

        public string Database {
            get;
            set;
        }

        public MyController(ILog log) {
            this.log = log;
        }

        public void DoAction() {
            log.Log(string.Format("Do action with database: {0}", Database));
        }
    }
}

