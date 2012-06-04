using System;
using MonoTouch.UIKit;

namespace StoryboardDemo {

	public class ProductDetailTableViewSource : UITableViewSource {
		
		public override int RowsInSection(UITableView tableview, int section) {
			return 10;
		}

		public override UITableViewCell GetCell(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath) {
			var id = "ProductDetailCell";
			var cell = tableView.DequeueReusableCell(id);
			if (cell == null) {
				cell = new UITableViewCell(UITableViewCellStyle.Default, id);
			}
			cell.TextLabel.Text = "a";
			cell.DetailTextLabel.Text = "b";
			return cell;
		}
		
	}
}

