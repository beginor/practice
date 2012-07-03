using System;
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
			this.label1.Text = "Asynchronous Start.";

			DoWork work = DoWorkMethod;
			work.BeginInvoke(OnWorkCallback, work);
		}

		private void OnWorkCallback(IAsyncResult ar) {
			Debug.WriteLine("Asyncronous Callback Method.Thread: #{0}", Thread.CurrentThread.ManagedThreadId);
			DoWork work = ar.AsyncState as DoWork;
			if (work != null) {
				work.EndInvoke(ar);
			}
			this.label1.Text = "Asyncronous End";
		}

		private void DoWorkMethod() {
			Thread.Sleep(3000);
		}
	}
}
