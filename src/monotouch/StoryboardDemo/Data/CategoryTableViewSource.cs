using System;
using MonoTouch.UIKit;
using Mono.Data.Sqlite;
using MonoTouch.Foundation;

namespace StoryboardDemo {

	public class CategoryTableViewSource : UITableViewSource {
		
		private Category[] _data = new Category[0];

		public Category[] Data {
			get {
				return this._data;
			}
		}		
		
		public override int NumberOfSections(UITableView tableView) {
			return 1;
		}
		
		public override int RowsInSection(UITableView tableview, int section) {
			return this._data.Length;
		}
		
		public void LoadDataAsync(Action callback) {
			var task = Northwind.LoadCategories();
			task.ContinueWith(t => {
				this._data = task.Result;
				callback();
			});
		}

		#region implemented abstract members of MonoTouch.UIKit.UITableViewSource
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath) {
			var id = "CategoryCell";
			var cell = tableView.DequeueReusableCell(id);
			if (cell == null) {
				cell = new UITableViewCell(UITableViewCellStyle.Default, id);
			}
			var category = this._data[indexPath.Row];
			var imageView = cell.ViewWithTag(1) as UIImageView;
			imageView.Image = UIImage.LoadFromData(NSData.FromArray(category.Picture));
			var nameLabel = cell.ViewWithTag(2) as UILabel;
			nameLabel.Text = category.CategoryName;
			var descLabel = cell.ViewWithTag(3) as UILabel;
			descLabel.Text = category.Description;
			
			return cell;
		}
		#endregion
	}
}

