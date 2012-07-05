using System;
using System.Threading;
using System.Threading.Tasks;


namespace TaskExceptions {

	class Program {

		static void Main(string[] args) {

			TaskScheduler.UnobservedTaskException += (s, e) => {
				Console.WriteLine(e.Exception);
			};

			TestAsync(5, -10);

			//testTask.ContinueWith(task => {
			//   if (task.IsFaulted) {
			//      Console.WriteLine(task.Exception.GetBaseException());
			//   }
			//   else {
			//      Console.WriteLine(task.Result);
			//   }
			//});

			//try {
			//   t.Wait();
			//}
			//catch(Exception ex) {
			//   Console.WriteLine(ex);
			//}

			Thread.Sleep(TimeSpan.FromMilliseconds(3000));

			GC.Collect();

			Console.WriteLine("Completed.");
			//Console.ReadLine();
		}

		static Task<int> TestAsync(int a, int b) {
			var tcs = new TaskCompletionSource<int>();
			Task.Factory.StartNew(() => {
				if (a + b < 0) {
					tcs.TrySetException(new InvalidOperationException("a + b < 0"));
				}
				else {
					tcs.TrySetResult(a + b);
				}
			});
			return tcs.Task;
		}
	}
}
