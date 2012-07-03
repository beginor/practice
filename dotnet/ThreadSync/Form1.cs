using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
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

			var context = SynchronizationContext.Current;

			DoWork work = DoWorkMethod;
			work.BeginInvoke(OnWorkCallback, context);
		}

		private void OnWorkCallback(IAsyncResult ar) {
			Debug.WriteLine("Asyncronous Callback Method.Thread: #{0}", Thread.CurrentThread.ManagedThreadId);
			AsyncResult async = (AsyncResult)ar;

			DoWork work = (DoWork)async.AsyncDelegate;
			if (work != null) {
				work.EndInvoke(ar);
			}
			this.UpdateStatus("Asyncronous End", ar.AsyncState);
		}

		void UpdateStatus(string input, object syncContext) {
			var context = syncContext as SynchronizationContext;
			var callback = new SendOrPostCallback(p => this.AddValue(p.ToString()));
			context.Post(callback, input);
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
