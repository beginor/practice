using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Input;
using WinForms = System.Windows.Forms;
using IO = System.IO;

namespace HttpDownloader {

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow {

		public MainWindow() {
			InitializeComponent();

			this.LocalDirectoryBrowsButton.Click += LocalDirectoryBrowsButtonOnClick;
			this.StartDownloadButton.Click += StartDownloadButtonOnClick;

			this.DownloadProgressBar.Value = 0;
		}

		private void StartDownloadButtonOnClick(object sender, RoutedEventArgs routedEventArgs) {
			if (string.IsNullOrWhiteSpace(this.UrlsTextBox.Text)) {
				MessageBox.Show("请输入要下载的URL！", "错误：", MessageBoxButton.OK, MessageBoxImage.Error);
				this.UrlsTextBox.Focus();
				return;
			}
			if (string.IsNullOrWhiteSpace(this.LocalDirectoryTextBox.Text)) {
				MessageBox.Show("请选择保存目录！", "错误：", MessageBoxButton.OK, MessageBoxImage.Error);
				this.LocalDirectoryTextBox.Focus();
				return;
			}
			var urls = this.UrlsTextBox.Text.Split(new[] {
				Environment.NewLine
			}, StringSplitOptions.RemoveEmptyEntries);

			this.SaveUrlsToLocal(urls.Distinct(StringComparer.OrdinalIgnoreCase).ToArray(), this.LocalDirectoryTextBox.Text);
		}

		private void SaveUrlsToLocal(string[] urls, string rootDirectory) {
			var cursor = this.Cursor;
			var urlCount = urls.Length;
			// disable the ui
			this.Cursor = Cursors.Wait;
			this.DownloadProgressBar.Maximum = urlCount;
			this.DownloadProgressBar.Value = 0;
			this.StartDownloadButton.Content = "下载中……";
			this.StartDownloadButton.IsEnabled = false;
			this.UrlsTextBox.IsEnabled = false;
			this.LocalDirectoryTextBox.IsEnabled = false;
			this.LocalDirectoryBrowsButton.IsEnabled = false;

			var tasks = new Task[urlCount];
			var uiSyncContext = System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext();
			Task.Factory.StartNew(() => {
				for (int i = 0; i < urlCount; i++) {
					var uri = new Uri(urls[i]);
					tasks[i] = Task.Factory.StartNew(() => this.SaveUri(uri, rootDirectory)).ContinueWith(t => this.DownloadProgressBar.Value += 1, uiSyncContext);
				}
				Task.WaitAll(tasks);
			}).ContinueWith(t => {
				// enable ui
				this.Cursor = cursor;
				this.StartDownloadButton.Content = "开始下载";
				this.StartDownloadButton.IsEnabled = true;
				this.UrlsTextBox.IsEnabled = true;
				this.LocalDirectoryTextBox.IsEnabled = true;
				this.LocalDirectoryBrowsButton.IsEnabled = true;
			}, uiSyncContext);
		}

		private void SaveUri(Uri uri, string rootDirectory) {
			try {
				var filePath = GetFilePath(uri);
				var fullPath = IO.Path.Combine(rootDirectory, filePath);
				var dir = IO.Path.GetDirectoryName(fullPath);
				if (!IO.Directory.Exists(dir)) {
					IO.Directory.CreateDirectory(dir);
				}
				else if (IO.File.Exists(fullPath)) {
					return;
				}
				var webClient = new WebClient();
				webClient.DownloadFile(uri, fullPath);
				webClient.Dispose();
			}
			catch (Exception ex) {
				//
			}
		}

		private static string GetFilePath(Uri uri) {
			var host = uri.DnsSafeHost;
			var filePath = host + uri.AbsolutePath;
			filePath = filePath.Replace(IO.Path.AltDirectorySeparatorChar, IO.Path.DirectorySeparatorChar);
			if (filePath.LastIndexOf(IO.Path.DirectorySeparatorChar) == filePath.Length - 1) {
				filePath = filePath + "default.htm";
			}
			return filePath;
		}

		private void LocalDirectoryBrowsButtonOnClick(object sender, RoutedEventArgs routedEventArgs) {
			var dialog = new WinForms.FolderBrowserDialog {
				Description = @"选择一个目录进行保存：",
				ShowNewFolderButton = true
			};
			if (!string.IsNullOrWhiteSpace(this.LocalDirectoryTextBox.Text)) {
				dialog.SelectedPath = this.LocalDirectoryTextBox.Text;
			}
			var dialogResult = dialog.ShowDialog();
			if (dialogResult == WinForms.DialogResult.OK) {
				this.LocalDirectoryTextBox.Text = dialog.SelectedPath;
			}

		}
	}
}
