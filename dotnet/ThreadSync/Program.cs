using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ThreadSync {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Console.WriteLine("0.ThreadID:#{1},Synchronization Context is null?{0}", SynchronizationContext.Current == null, Thread.CurrentThread.ManagedThreadId);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Test a = new Test();
			Console.WriteLine("1.ThreadID:#{1},Synchronization Context is null?{0}", SynchronizationContext.Current == null, Thread.CurrentThread.ManagedThreadId);

			var form = new Form1();
			Console.WriteLine("2.ThreadID:#{1},Synchronization Context is null?{0}", SynchronizationContext.Current == null, Thread.CurrentThread.ManagedThreadId);
			Application.Run(form);

			//new Thread(Work).Start();

			//Console.Read();
		}

		static void Work() {
			Console.WriteLine("3.ThreadID:#{1},Synchronization Context is null?{0}",
			  SynchronizationContext.Current == null, Thread.CurrentThread.ManagedThreadId);
		}
	}

	public class Test {
	}
}
