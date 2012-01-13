using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Browser;
using Microsoft.Silverlight.Testing;

namespace SilverlightUnitTest {

	public partial class App {
		
		public App() {
			this.Startup += this.Application_Startup;
			this.Exit += this.Application_Exit;
			this.UnhandledException += this.Application_UnhandledException;

			this.InitializeComponent();
		}

		private void Application_Startup(object sender, StartupEventArgs e) {
			this.RootVisual = UnitTestSystem.CreateTestPage();
		}

		private void Application_Exit(object sender, EventArgs e) {
		}

		private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e) {
			if (!Debugger.IsAttached) {
				e.Handled = true;
				Deployment.Current.Dispatcher.BeginInvoke(() => this.ReportErrorToDOM(e));
			}
		}

		private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e) {
			try {
				string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
				errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

				HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
			}
			catch (Exception) {
			}
		}
	}
}
