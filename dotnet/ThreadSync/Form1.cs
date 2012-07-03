using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace ThreadSync {

	internal delegate void DoWork();

	public partial class Form1 : Form {

		public Form1() {
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e) {
			Debug.WriteLine("Window Form Method.ThreadId:#{0}", Thread.CurrentThread.ManagedThreadId);
			this.AddValue("Asynchronous Start.");

			DoWork work = DoWorkMethod;
			work.BeginInvoke(OnWorkCallback, work);
		}

		private void OnWorkCallback(IAsyncResult ar) {
			Debug.WriteLine("Asyncronous Callback Method.Thread: #{0}", Thread.CurrentThread.ManagedThreadId);
			DoWork work = ar.AsyncState as DoWork;
			if (work != null) {
				work.EndInvoke(ar);
			}
			this.UpdateStatus("Asyncronous End");
		}

		void UpdateStatus(string input) {
			ISynchronizeInvoke async = this.listBox1;
			if (async.InvokeRequired) {
				Action<string> action = this.AddValue;
				async.Invoke(action, new object[] { input });
			}
			else {
				this.AddValue(input);
			}
		}

		void AddValue(string input) {
			var item = string.Format("[(#{2}){0}]Context is null:{1}", input, Thread.CurrentContext == null, Thread.CurrentThread.ManagedThreadId);
			this.listBox1.Items.Add(item);
		}

		private void DoWorkMethod() {
			Thread.Sleep(3000);
		}
	}
}
