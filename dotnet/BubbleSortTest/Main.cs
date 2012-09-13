using System;

namespace BubbleSortTest {

	class MainClass {

		public static void Main(string[] args) {
			var random = new Random();
			var array = new string[10];
			for (int i = 0; i < array.Length; i++) {
				array[i] = random.NextDouble().ToString("f3");
			}
			Console.WriteLine("Before sort: {0}", string.Join(",", array));

			BubbleSort(array);

			Console.WriteLine(" After sort: {0}", string.Join(",", array));
		}

		static void Swap(ref string a, ref string b) {
			var tmp = a;
			a = b;
			b = tmp;
		}

		static void BubbleSort(string[] array) {
			if (array == null) {
				throw new ArgumentNullException("array");
			}
			if (array.Length <= 1) {
				return;
			}

			var swaped = false;
			do {
				for (var i = 0; i < array.Length - 1; i++) {
					if (array[i].CompareTo(array[i + 1]) > 0) {
						Swap(ref array[i], ref array[i + 1]);
						swaped = true;
					}
					Console.WriteLine("           : {0}", string.Join(",", array));
				}
			}
			while (!swaped);
		}
	}
}
