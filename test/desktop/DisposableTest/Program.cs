using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DisposableTest {

	class Disposable : IDisposable {

		private bool _disposed;

		public void Dispose() {
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing) {
			if (disposing) {
				Console.WriteLine("Disposable.Dispose(disposing={0})", true);
			}
			this._disposed = true;
		}

		public virtual void Test() {
			Console.WriteLine("Disposable Test");
		}
	}

	class MyDisposable : Disposable {

		private bool _disposed;

		protected override void Dispose(bool disposing) {
			if (this._disposed) {
				return;
			}
			if (disposing) {
				Console.WriteLine("MyDisposable.Dispose(disposing={0})", disposing);
				this._disposed = true;
			}
			base.Dispose(disposing);
		}

		public override void Test() {
			Console.WriteLine("MyDisposable Test");
			base.Test();
		}
	}

	class Program {
		
		static void Main(string[] args) {

			Disposable d = new MyDisposable();
			d.Test();
			d.Dispose();

			Console.ReadLine();
		}
	}
}
