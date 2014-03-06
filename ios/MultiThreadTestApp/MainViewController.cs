
using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Threading;
using GDEIC.AppFx.Http;
using Mono.Data.Sqlite;
using System.IO;

namespace MultiThreadTestApp {

	public partial class MainViewController : UIViewController {

		private Thread[] _workThreads;
		private int _requestCount = 100;
		private volatile int _completeCount;

		public MainViewController() : base ("MainViewController", null) {
		}
		
		public override void DidReceiveMemoryWarning() {
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad() {
			base.ViewDidLoad();
			this.Title = "Multi Thread Test";
			// Perform any additional setup after loading the view, typically from a nib.
			this.SwithchButton.TouchUpInside += SwitchButtonOnClick;
			this.OpenSqliteButton.TouchUpInside += OpenSqliteButtonOnClick;
		}

		void OpenSqliteButtonOnClick(object sender, EventArgs e) {
			var dbPath = Path.Combine(Environment.CurrentDirectory, "dbdemos.db3");
			var connStr = string.Format("Data Source={0};Password=123456;", dbPath);
			var conn = new SqliteConnection(connStr);
			try {
				//conn.SetPassword("123456");
				conn.Open();
			}
			catch (Exception ex) {
				Console.WriteLine(ex.ToString());
			}
			finally {
				conn.Close();
			}
		}

		void SwitchButtonOnClick(object sender, EventArgs e) {
			if (this.SwithchButton.Title(UIControlState.Normal) == "Start") {
				DisableUI();
				this._completeCount = 0;
				this._requestCount = int.Parse(this.RequestCountLabel.Text);
				// start work threads
				var threadCount = int.Parse(this.ThreadCountTextField.Text);

				var totalCount = threadCount * _requestCount;
				this.UpdateProgress(this._completeCount, totalCount);

				this.StartWorkThreads(threadCount);
			}
			else {
				// stop work threads
				this.StopWorkThreads();
				EnableUI();
			}
		}

		void DisableUI() {
			this.SwithchButton.SetTitle("Stop", UIControlState.Normal);
			this.ThreadCountTextField.Enabled = false;
			this.RequestCountLabel.Enabled = false;
		}

		void EnableUI() {
			this.ThreadCountTextField.Enabled = true;
			this.RequestCountLabel.Enabled = true;
			this.SwithchButton.SetTitle("Start", UIControlState.Normal);
		}

		private void UpdateProgress(int completed, int total) {
			float progress = completed / (float)total;
			var msg = string.Format("{0} of {1} completed", completed, total);
			this.InvokeOnMainThread(() => {
				this.CompleteProgressView.Progress = progress;
				this.ProgressMessageLabel.Text = msg;
				if (completed == total) {
					this.EnableUI();
				}
			});
		}

		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations() {
			return UIInterfaceOrientationMask.Portrait;
		}

		private void StartWorkThreads(int count) {
			this._workThreads = new Thread[count];
			for (var i = 0; i < count; i++) {
				this._workThreads[i] = new Thread(this.ThreadStart);
				this._workThreads[i].Start();
			}
		}

		private void StopWorkThreads() {
			if (this._workThreads == null) {
				return;
			}
			for (var i = 0; i < this._workThreads.Length; i++) {
				try {
					this._workThreads[i].Abort();
				}
				catch (Exception ex) {
					Console.WriteLine(ex.ToString());
				}
			}
		}

		private HttpClient _httpClient = new HttpClient() {
			BaseUri = new Uri("http://zhang.gdepb.gov.cn/AppFxTest/", UriKind.Absolute) 
		};
		private Random _random = new Random();

		private void ThreadStart() {
			for (var i = 0; i < _requestCount; i++) {
				var id = _random.Next(1, 77);

				try {
					var request = this._httpClient.GetAsync("Northwind.mvc/GetProduct/" + id);
					request.Wait();
					var response = request.Result;
					var content = response.Content.ReadAsStringAsync();
					content.Wait();
					Console.WriteLine(content.Result);
					this._completeCount += 1;
					this.UpdateProgress(this._completeCount, this._workThreads.Length * _requestCount);
				}
				catch (Exception ex) {
					Console.WriteLine(ex.ToString());
				}
			}
		}
	}
}

