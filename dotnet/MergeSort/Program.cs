using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort {

	class Program {
		
		static string[] MergeSort(string[] arr) {
			if (arr.Length == 1) {
				return arr;
			}
			
			var middle = arr.Length / 2;
			var left = new string[middle];
			Array.Copy(arr, 0, left, 0, left.Length);
			
			var right = new string[arr.Length - middle];
			Array.Copy(arr, middle, right, 0, right.Length);

			left = MergeSort(left);
			right = MergeSort(right);
			
			var result = Merge(left, right);
			
			return result;
		}

		static string[] Merge(string[] left, string[] right) {
			var result = new string[left.Length + right.Length];
			int leftIndex = 0, rightIndex = 0, i = 0;
			while (leftIndex < left.Length && rightIndex < right.Length) {
				string leftItem = left[leftIndex];
				string rightItem = right[rightIndex];
				if (string.CompareOrdinal(leftItem, rightItem) < 0) {
					result[i] = leftItem;
					leftIndex++;
				}
				else {
					result[i] = rightItem;
					rightIndex++;
				}
				i++;
			}
			
			if (leftIndex == left.Length) {
				Array.Copy(right, rightIndex, result,i, right.Length - rightIndex);
			}
			else {
				Array.Copy(left, leftIndex, result,i, left.Length - leftIndex);
			}

			return result;
		}

		static void Main(string[] args) {
			var arr = new[] {
				"aa", "cc", "xx", "uu", "gg", "ff", "nn"
			};

			Console.WriteLine("Before sort: {0}", string.Join(",", arr));
			var result = MergeSort(arr);
			Console.WriteLine("After sort: {0}", string.Join(",", result));
			
			//Console.ReadKey();
		}
	}
}
