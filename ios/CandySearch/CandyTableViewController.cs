using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace CandySearch {

    partial class CandyTableViewController : UITableViewController {

        private IList<Candy> candies;

        public CandyTableViewController(IntPtr handle) : base(handle) {
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            candies = new List<Candy> {
                new Candy("chocolate", "chocolate bar"),
                new Candy("chocolate", "chocolate chip"),
                new Candy("chocolate", "dark chocolate"),
                new Candy("hard", "lollipop"),
                new Candy("hard", "candy cane"),
                new Candy("hard", "jaw breaker"),
                new Candy("other", "caramel"),
                new Candy("other", "sour chew"),
                new Candy("other", "peanut butter cup"),
                new Candy("other", "gummi bear")
            };
        }

        public override int RowsInSection(UITableView tableview, int section) {
            return candies.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath) {
            var cellId = "CandyCell";
            var cell = tableView.DequeueReusableCell(cellId);
            if (cell == null) {
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellId) {
                    Accessory = UITableViewCellAccessory.DisclosureIndicator
                };
            }
            var candy = candies[indexPath.Row];
            cell.TextLabel.Text = candy.Name;
            return cell;
        }
    }
}
