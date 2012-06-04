using System;
using MonoTouch.UIKit;

namespace StoryboardDemo {

	public class ProductTableViewSource : UITableViewSource {
		
		private Product[] _data = new Product[0];

		public Product[] Data {
			get {
				return this._data;
			}
		}
		
		public override int NumberOfSections(UITableView tableView) {
			return 1;
		}
		
		public override int RowsInSection(UITableView tableview, int section) {
			return _data.Length;
		}
		
		public override UITableViewCell GetCell(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath) {
			var id = "ProductCell";
			var cell = tableView.DequeueReusableCell(id);
			if (cell == null) {
				cell = new UITableViewCell(UITableViewCellStyle.Default, id);
			}
			var p = this._data[indexPath.Row];
			cell.TextLabel.Text = p.ProductName;
			cell.DetailTextLabel.Text = p.QuantityPerUnit;
			return cell;
		}
		
		public void LoadDataAsync(long categoryId, Action callback) {
			var task = Northwind.LoadProducts(categoryId);
			task.ContinueWith((t) => {
				this._data = t.Result;
				callback();
			});
		}
	}
}

